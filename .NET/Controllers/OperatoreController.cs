using Microsoft.AspNetCore.Mvc;

namespace Esercizio.Controllers;

[ApiController]
[Route("[controller]")]
public class OperatoreController : ControllerBase
{
    private static Dictionary<int, Operatore> dict = new Dictionary<int, Operatore>();

    [HttpGet]
    public IEnumerable<Operatore> GetOperatori()
    {
        return dict.Values.ToArray();
    }

        [HttpGet("{id}")]
    public ActionResult<Operatore> GetOperatore(int id)
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
    public IActionResult Create(Operatore operatore)
    {
        if (dict.ContainsKey(operatore.Id))
        {
            return BadRequest();
        }
        else
        {
            dict.Add(operatore.Id, operatore);
            return Ok();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Operatore operatore)
    {
        if (!dict.ContainsKey(id))
        {
            return BadRequest();
        }
        else
        {
            dict[id] = operatore;
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
