using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        
        [Required]
        public int GenreId { get; set; }

        public virtual GenreDto Genre { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        public byte NumberInStock { get; set; }
    }
}