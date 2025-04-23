using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Buscar()
        {
            var listaFilmes = await _context.Filmes.ToListAsync();
            return Ok(listaFilmes);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] FilmeDto item)
        {
            var filme = new Filme
            {
                Nome = item.Nome,
                Genero = item.Genero
            };

            await _context.Filmes.AddAsync(filme);
            await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(Buscar), new { id = filme.Id }, filme);
            return Created("", filme);
        }

        //private static List<Filme> filmes = new List<Filme>();

        //public ActionResult<IEnumerable<Filme>> Get()
        //{
        //    return filmes;
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Filme> Get(Guid id)
        //{
        //    var filme = filmes.FirstOrDefault(f => f.Id == id);
        //    if (filme == null)
        //    {
        //        return NotFound();
        //    }
        //    return filme;
        //}

        //[HttpPost]
        //public ActionResult<Filme> Post([FromBody] Filme filme)
        //{
        //    filme.Id = Guid.NewGuid();
        //    filmes.Add(filme);
        //    return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(Guid id, [FromBody] Filme filme)
        //{
        //    var filmeExistente = filmes.FirstOrDefault(f => f.Id == id);
        //    if (filmeExistente == null)
        //    {
        //        return NotFound();
        //    }

        //    filmeExistente.Nome = filme.Nome;
        //    filmeExistente.Genero = filme.Genero;

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    var filme = filmes.FirstOrDefault(f => f.Id == id);
        //    if (filme == null)
        //    {
        //        return NotFound();
        //    }

        //    filmes.Remove(filme);
        //    return NoContent();
        //}
    }
}
