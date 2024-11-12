using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Libro
    {

        public int IdLibro { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(50)]
        public string Autor { get; set; }

        [Required]
        [StringLength(50)]
        public  string Genero { get; set; }
        [Required]
        public DateOnly Fechapublicacion { get; set; }
        [Required]
        [StringLength(250)]
        public  string Sinopsis{ get; set; }

    }
}
