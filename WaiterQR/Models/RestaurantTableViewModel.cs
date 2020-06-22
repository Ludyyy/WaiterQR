using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WaiterQR.Database;

namespace WaiterQR.Models
{
    public class RestaurantTableViewModel
    {
        [Key]
        [Display(Name = "RestaurantID")]
        public int ResID { get; set; }

        [Required(ErrorMessage = "RestaurantTable_ID is required.")]
        public int RestaurantTable_ID { get; set; }

        [Required(ErrorMessage = "RestaurantTable_Occupied is required.")]
        public Boolean RestaurantTable_Occupied { get; set; }

        public List<RestaurantTable> RestaurantTables { get; set; }

        public int capacity { get; set; }
    }

}