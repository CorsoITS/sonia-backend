using Microsoft.AspNetCore.Mvc;

namespace Esercizio.Controllers;

[ApiController]
[Route("[controller]")]
public class SedeController : ControllerBase
{
    private static Dictionary<int, Sede> dict = new Dictionary<int, Sede>();

    [HttpGet]
    public IEnumerable<Sede> GetSedi()
    {
        return dict.Values.ToArray();
    }

        [HttpGet("{id}")]
    public ActionResult<Sede> GetSede(int id)
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
    public IActionResult Create(Sede sede)
    {
        if (dict.ContainsKey(sede.Id))
        {
            return BadRequest();
        }
        else
        {
            dict.Add(sede.Id, sede);
            return Ok();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Sede sede)
    {
        if (!dict.ContainsKey(id))
        {
            return BadRequest();
        }
        else
        {
            dict[id] = sede;
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
