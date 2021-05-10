using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movie_store.Models.DB
{
  public class Order
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderRow> OrderRows { get; set; }
  }
}