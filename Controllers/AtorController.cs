using Entity_MySQL;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/[controller]")]
public class AtorController : ControllerBase
{

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateActor([FromBody] Ator actor)
    {
        using var context = new MyDbContext();

        try
        {
            await context.Atores.AddAsync(actor);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "O ator foi cadastrado corretamente");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível cadastrar o ator");
        }
    }

    [HttpGet]
    public List<Ator> GetActors()
    {
        using var context = new MyDbContext();

        List<Ator> atores = context.Atores.ToList();
        return atores;
    }

}