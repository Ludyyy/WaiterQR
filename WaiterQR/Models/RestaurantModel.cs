using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaiterQR.Models
{
    public class RestaurantModel
    {
        [Key]
        [Display(Name = "RestaurantID")]
        public int ResID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "PostalCode")]
        public int PostalCode { get; set; }
    }
    public class RestaurantRepository
    {
        internal bool AddRestaurant(RestaurantModel restaurants)
        {
            throw new NotImplementedException();
        }
    }

}