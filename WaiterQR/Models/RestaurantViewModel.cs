using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaiterQR.Models
{
    public class RestaurantViewModel
    {
        [Key]
        [Display(Name = "RestaurantID")]
        public int ResID { get; set; }

        [Required(ErrorMessage = "OwnerID is required.")]
        public int OwnerID { get; set; }

        [Required(ErrorMessage = "RestaurantPostalCode is required.")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Restaurant_City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Restaurant_StreetName is required.")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Restaurant_HouseNo is required.")]
        public int HouseNo { get; set; }

        [Required(ErrorMessage = "Restaurant_TableAmount is required.")]
        public int TableAmount { get; set; }

        [Required(ErrorMessage = "Restaurant_Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant_Description is required.")]
        public string Description { get; set; }

    }

}