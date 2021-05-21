using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace movie_store.Models
{
  public class CustomersViewModels
  {
    [Required]
    [MaxLength(150), MinLength(2)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(150), MinLength(2)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required]
    [MaxLength(150), MinLength(2)]
    [DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct Email.")]
    public string Email { get; set; }
    [Required]
    [MaxLength(100), MinLength(2)]
    [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter correct Phone Number")]
    [Display(Name = "Phone Number")]
    public string PhoneNo { get; set; }
    [Required]
    [MaxLength(150), MinLength(2)]
    [Display(Name = "Billing Address")]
    public string BillingAddress { get; set; }
    [Required]
    [MaxLength(50), MinLength(2)]
    [Display(Name = "Billing Zip Code")]
    public string BillingZipCode { get; set; }
    [Required]
    [MaxLength(50), MinLength(2)]
    [Display(Name = "Billing City")]
    public string BillingCity { get; set; }
    [Required]
    [MaxLength(50), MinLength(2)]
    [Display(Name = "Billing Country")]
    public string BillingCountry { get; set; }
    [Required]
    [MaxLength(150), MinLength(2)]
    [Display(Name = "Delivery Address")]
    public string DeliveryAddress { get; set; }
    [Required]
    [MaxLength(50), MinLength(2)]
    [Display(Name = "Delivery Zip Code")]
    public string DeliveryZipCode { get; set; }
    [Required]
    [MaxLength(50), MinLength(2)]
    [Display(Name = "Delivery City")]
    public string DeliveryCity { get; set; }
    [Required]
    [MaxLength(50), MinLength(2)]
    [Display(Name = "Delivery Country")]
    public string DeliverCountry { get; set; }

  }
}