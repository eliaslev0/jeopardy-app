using jeopardy.DTO;
using System.Text.Json;

namespace jeopardy.Services {
    public class JeopardyService {
        private jeopardyContext _context; // dependency injection
        public JeopardyService(jeopardyContext context) {
            _context = context;
        }

        public List<JeopardyDTO> getCluesByCategory(string? category) {
            return(_context.Clues
            .Where(x => x.Category.ToLower() == category.ToLower())
            .Select(x => (JeopardyDTO)x)
            .ToList());
        }


        public List<JeopardyDTO> getCluesByValue(short? value) {
            return(_context.Clues
            .Where(x => x.Value == value)
            .Take(100)
            .Select(x => (JeopardyDTO)x)
            .ToList());
        }

        public JeopardyDTO getClueByCategoryAndValue(string? category, short? value) {
            return((JeopardyDTO) _context.Clues
            .FirstOrDefault(x => x.Value == value && x.Category.ToLower() == category.ToLower())
            );
        }

        public JeopardyDTO getClueById(short? id) {
            return((JeopardyDTO) _context.Clues
            .FirstOrDefault(x => x.Id == id)
            );
        }

        public async Task FillDatabase() {
            var client = new HttpClient();

            var response = await client.GetAsync("https://jservice.io/api/clues?offset=0");
            
            for (int i = 121568; i < 156700; i+=100) {
                response = await client.GetAsync("https://jservice.io/api/clues?offset=" + i);
                var resp = await response.Content.ReadAsStringAsync();
                var clues = JsonSerializer.Deserialize<List<JeopardyDTO>>(resp);
                _context.AddRange(clues.Select(x => (Clue)x ));
                _context.SaveChanges();
                
            }
        }

        public List<JeopardyDTO> listOneHundredClues(int year, int month, int day, short? value) {
            if (year == 0) year = 1985;
            if (month == 0) month = 1;
            if (day == 0) day = 1;

            DateOnly dateAired = new DateOnly(year, month, day);
            
            return(_context.Clues
            .Where(x => x.Airdate > dateAired && x.Value == value)
            .Take(100)
            .Select(x => (JeopardyDTO)x)
            .ToList());
        }

        public JeopardyDTO AddNewClue (JeopardyDTO clueToAdd) {
            Clue clue = (Clue) clueToAdd;
            
            _context.Add(clue);
            _context.SaveChanges();
            return (JeopardyDTO) clue;
        }
        
        public void RemoveFromDatabase(int id) {
            var itemToRemove = _context.Clues
            .FirstOrDefault(x => x.Id == id);
            
            _context.Clues
            .Remove(itemToRemove);
            _context.SaveChanges();

        }
        public JeopardyDTO UpdateClueInDatabase (JeopardyDTO clue) {
            var updatedClue = _context.Clues.FirstOrDefault(x => x.Id == clue.Id);

            updatedClue.Id = clue.Id;
            updatedClue.Answer = clue.Answer;
            updatedClue.Question = clue.Question;
            updatedClue.Value = clue.Value;
            updatedClue.Category = clue.Category.Title;
            updatedClue.Airdate = new DateOnly(clue.Airdate.Value.Year, clue.Airdate.Value.Month, clue.Airdate.Value.Day);
            _context.SaveChanges();

            return((JeopardyDTO) updatedClue);
        }
    }
}