using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        [HttpGet]
        public ActionResult<IEnumerable<Filme>> Get()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public ActionResult<Filme> Get(Guid id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            return filme;
        }

        [HttpPost]
        public ActionResult<Filme> Post([FromBody] Filme filme)
        {
            filme.Id = Guid.NewGuid();
            filmes.Add(filme);
            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Filme filme)
        {
            var filmeExistente = filmes.FirstOrDefault(f => f.Id == id);
            if (filmeExistente == null)
            {
                return NotFound();
            }

            filmeExistente.Nome = filme.Nome;
            filmeExistente.Genero = filme.Genero;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            filmes.Remove(filme);
            return NoContent();
        }
    }
}
