using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class FilmeDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Genero { get; set; }


    }
}
