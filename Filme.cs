using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora
{
    [Table("filmes")]
    public class Filme
    {
        [Column("id_filmes")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Genero { get; set; }

        public DateOnly? AnoLancamento { get; set; }
    }
}
