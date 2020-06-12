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

        [Required(ErrorMessage = "OwnerID is required.")]
        public int OwnerID { get; set; }

        [Required(ErrorMessage = "RestaurantPostalCode is required.")]
        public int RestaurantPostalCode { get; set; }

        [Required(ErrorMessage = "Restaurant_City is required.")]
        public string Restaurant_City { get; set; }

        [Required(ErrorMessage = "Restaurant_StreetName is required.")]
        public string Restaurant_StreetName { get; set; }

        [Required(ErrorMessage = "Restaurant_HouseNo is required.")]
        public string Restaurant_HouseNo { get; set; }

    }

}