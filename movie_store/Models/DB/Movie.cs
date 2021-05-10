using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace movie_store.Models.DB
{
  public class Movie
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(150), MinLength(2)]
    public string Title { get; set; }
    [Required]
    [MaxLength(150), MinLength(2)]
    public string Director { get; set; }
    [Required]
    [Display(Name ="Release Year")]
    public int ReleaseYear { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    public double ImdbRating { get; set; }
    public string ImdbId { get; set; }
    public string ImdbRated { get; set; }
    public string Plot { get; set; }
    public string ImgUrl { get; set; }

    public virtual ICollection<OrderRow> OrderRows { get; set; }
  }
}