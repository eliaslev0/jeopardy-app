namespace jeopardy.DTO {
    public class JeopardyDTO {    
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("answer")]
        public string? Answer { get; set; }
        [JsonPropertyName("question")]
        public string? Question { get; set; }
        [JsonPropertyName("value")]
        public int? Value { get; set; }
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        [JsonPropertyName("airdate")]
        public DateTime? Airdate { get; set; }

        public static explicit operator JeopardyDTO(Clue clue) {
            DateTime? incomingAirDate = null;
            if (clue.Airdate != null) {
                incomingAirDate = new DateTime(clue.Airdate.Value.Year, clue.Airdate.Value.Month, clue.Airdate.Value.Day);
            }
            return new JeopardyDTO() {
                Id = clue.Id,
                Answer = clue.Answer,
                Question = clue.Question,
                Value = clue.Value,
                Category = new Category() {
                    Title = clue.Category,
                },
                Airdate = incomingAirDate,
            };

        }
    }

    public class Category {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}