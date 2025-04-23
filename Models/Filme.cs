using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora.Models
{
    [Table("filmes")]
    public class Filme
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Genero { get; set; }

        public DateOnly? AnoLancamento { get; set; }
    }
}
