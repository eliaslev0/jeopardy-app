using System.Text.Json;
using jeopardy.DTO;
using jeopardy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jeopardy.Controllers;

[ApiController]
[Route("[controller]")]
public class JeopardyController : ControllerBase
    
{
    private JeopardyService _service;
    public JeopardyController(JeopardyService service) {
        _service = service;
    }

    [HttpGet("FillDatabase")]
    public async Task<ActionResult> Get()
    {
        await _service.FillDatabase();
        
        return Ok("Database should now be full");
    }

    [HttpGet]
    [Route("ByCategory/{category}")]

    public ActionResult<JeopardyDTO> byCategory(string category)
    {
        var res = _service.getCluesByCategory(category);
        if (res.Count() < 1) { return NotFound("No clues found for given category"); }
        return Ok(res);
    }

    [HttpGet]
    [Route("ByValue/{value}")]
    public ActionResult<JeopardyDTO> byValue(short? value)
    {
        var res = _service.getCluesByValue(value);
        if (res.Count() < 1) { return NotFound("No clues found for given value"); }
        return Ok(res);
    }

    [HttpGet]
    [Route("ById/{id}")]
    public ActionResult<JeopardyDTO> byId(short? id)
    {
        var res = _service.getClueById(id);
        return Ok(res);
    }

    [HttpGet]
    [Route("ByCategoryAndValue/{category}/{value}")]
    public ActionResult<JeopardyDTO> byCategoryAndValue(string category, short? value)
    {
        var res = _service.getClueByCategoryAndValue(category, value);
        return Ok(res);
    }
    [HttpGet]
    [Route("ListHundred")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<JeopardyDTO> listHundred(int? year, int? month, int? day, short? value) {
        int yearToSend = year ?? default(int);
        int monthToSend = month ?? default(int);
        int dayToSend = day ?? default(int);
        
        var res = _service.listOneHundredClues(yearToSend, monthToSend, dayToSend, value);
        return Ok(res);
    }

    [HttpPost]
    [Route("AddNew")]

    public ActionResult<JeopardyDTO> AddNew(JeopardyDTO clueToAdd) {
        var res = _service.AddNewClue(clueToAdd);
        return Ok(res);
    }

    [HttpGet]
    [Route("Remove")]

    public ActionResult<Clue> RemoveFromDatabase(int id) {
        _service.RemoveFromDatabase(id);
        return Ok("item " + id + " has been removed from the database");
    }

    [HttpPost]
    [Route("UpdateClue")]
    public ActionResult<JeopardyDTO> UpdateClue(JeopardyDTO clueToUpdate) {
        
        JeopardyDTO res = _service.UpdateClueInDatabase(clueToUpdate);
        return Ok(res);
    }
}
