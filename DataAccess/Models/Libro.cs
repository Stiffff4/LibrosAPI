using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Autor")]
        public string Autor { get; set; }

        [Column("Genero")]
        public string Genero { get; set; }

        [Column("Edicion")]
        public int? Edicion { get; set; }

        [Column("FechaPublicacion")]
        public DateTime? FechaPublicacion { get; set; }

    }
}
