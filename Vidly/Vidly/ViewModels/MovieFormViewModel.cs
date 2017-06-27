﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public List<Genre> Genres { get; set; }
    
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
 
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }


            
        public string Title
        {
            get
            {
                if (Id == 0)
                    return "New Movie";
                else return "Edit Movie";
            }
        }

        public MovieFormViewModel()
        {
             Id = 0;
        }
 
        public MovieFormViewModel(Movie movie)
        {
             Id = movie.Id;
             Name = movie.Name;
             ReleaseDate = movie.ReleaseDate;
             NumberInStock = movie.NumberInStock;
             GenreId = movie.GenreId;
        }
    }
}