using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_store.Models.DB
{
  public interface ICustomer
  {
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNo { get; set; }
    string BillingAddress { get; set; }
    string BillingZipCode { get; set; }
    string BillingCity { get; set; }
    string DeliveryAddress { get; set; }
    string DeliveryZipCode { get; set; }
    string DeliveryCity { get; set; }
  
  }
}
