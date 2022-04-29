using Microsoft.AspNetCore.Mvc;

namespace Esercizio.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonaController : ControllerBase
{
    private static Dictionary<int, Persona> dict = new Dictionary<int, Persona>();

    [HttpGet]
    public IEnumerable<Persona> GetPeople()
    {
        return dict.Values.ToArray();
    }

        [HttpGet("{id}")]
    public ActionResult<Persona> GetPerson(int id)
    {
        if (dict.ContainsKey(id))
        {
            return dict[id];
        }
        else
        {
            return NotFound();
        }
    }

        [HttpPost]
    public IActionResult Create(Persona persona)
    {
        if (dict.ContainsKey(persona.Id))
        {
            return BadRequest();
        }
        else
        {
            dict.Add(persona.Id, persona);
            return Ok();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Persona persona)
    {
        if (!dict.ContainsKey(id))
        {
            return BadRequest();
        }
        else
        {
            dict[id] = persona;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!dict.ContainsKey(id))
        {
            return BadRequest();
        }
        else
        {
            dict.Remove(id);
            return Ok();
        }
    }
    
}
