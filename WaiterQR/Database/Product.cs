//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WaiterQR.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;

    public partial class Product
    {
        public int ProductID { get; set; }
        public int RestaurantID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        
        [DisplayName("UploadFile")]
        public string ImagePath { get; set; } //This parameter is used to set the imagepath to the picture when the editor presses "UploadFile")

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
