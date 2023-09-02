using System.Reflection.Metadata.Ecma335;
using Entity_MySQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/[controller]/")]
public class FilmeController : ControllerBase
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateMovie([FromBody] Filme movie)
    {
        using var context = new MyDbContext();

        try
        {
            await context.Filmes.AddAsync(movie);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "O filme foi cadastrado corretamente");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível cadastrar o filme");
        }
    }

    [HttpGet]
    public List<Filme> GetMovies()
    {
        using var context = new MyDbContext();

        List<Filme> filmes = context.Filmes.ToList();
        return filmes;
    }
}