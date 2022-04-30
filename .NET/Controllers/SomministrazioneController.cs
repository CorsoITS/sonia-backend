using Microsoft.AspNetCore.Mvc;
using Esercizio.Services;
using Esercizio.Models;

namespace Esercizio.Controllers;

[ApiController]
[Route("[controller]")]
public class SomministrazioneController : ControllerBase
{
    private SomministrazioneService somministrazioneService = new SomministrazioneService();

    [HttpGet]
    public IEnumerable<Somministrazione> GetSomministrazioni()
    {
        return somministrazioneService.GetSomministrazioni();
    }

        [HttpGet("{id}")]
    public ActionResult<Somministrazione> GetSomministrazione(int id)
    {
        return somministrazioneService.GetSomministrazione(id);
    }

        [HttpPost]
    public IActionResult Create(Somministrazione somministrazione)
    {
        var created = somministrazioneService.Create(somministrazione);
        if (created){
            return Ok();
        }
        else{
            return BadRequest();
        }
    }

    [HttpPut]
    public IActionResult Update(Somministrazione somministrazione)
    {
        var updated = somministrazioneService.Update(somministrazione);
        if (updated){
            return Ok();
        }
        else{
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = somministrazioneService.Delete(id);
        if (deleted){
            return Ok();
        }
        else{
            return BadRequest();
        }
    
    }
}
