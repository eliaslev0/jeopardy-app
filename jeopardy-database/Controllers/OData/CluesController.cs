//ADD Controller Code in namespace

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class CluesController: ODataController
    {
        private readonly jeopardyContext _context;
        public CluesController(jeopardyContext context)
        {
            _context = context;
        }
 
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Clues);
        }
 
        [EnableQuery]
        public async Task<IActionResult> Get(int key)
        {
            var entity = await _context.Clues.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
 
            return Ok(entity);
        }
 
        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<Clue> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            var entity = await _context.Clues.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
 
            model.Patch(entity);
 
            await _context.SaveChangesAsync();
 
            return Updated(entity);
        }
 
 
        public async Task<IActionResult> Post([FromBody] Clue model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            _context.Clues.Add(model);
            await _context.SaveChangesAsync();
 
            return Created(model);
        }
 
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Clue update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            if (key != update.Id)
            {
                return BadRequest();
            }
 
            _context.Entry(update).State = EntityState.Modified;
 
            await _context.SaveChangesAsync();
 
            return Updated(update);
        }
 
 
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var entity = await _context.Clues.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
 
            _context.Clues.Remove(entity);
            await _context.SaveChangesAsync();
 
            return Ok();
        }
    }