using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WaiterQR.Models
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "ProductID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "RestaurantID is required.")]
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "ProductName is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ProductDescription is required.")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "ProductPrice is required.")]
        public string ProductPrice { get; set; }

        [Required(ErrorMessage = "ProductImage is required.")]
        public string ProductImage { get; set; }

    }

}