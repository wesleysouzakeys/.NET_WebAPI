using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
    }

    [HttpGet("/filmes")]
    public IEnumerable<Filme> ListaFilmes()
    {
        return filmes;
    }

    [HttpGet("/filme/{id}")]
    public Filme ListaFilmePorId([FromRoute] int id)
    {
        return filmes.Find(filme => filme.Id == id);
    }
}
