using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movie_store.Models.DB
{
  public class OrderRow
  {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int MovieId { get; set; }

    [Required]  
    public decimal Price { get; set; }
    public virtual Order Order { get; set; }
    public virtual Movie Movie { get; set; }

  }
}