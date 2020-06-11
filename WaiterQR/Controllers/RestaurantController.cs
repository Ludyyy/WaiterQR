using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
    public class RestaurantController : Controller
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: Restaurant
        public ActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurant(RestaurantModel restaurants)
        {
            try
            {
                using (websitedbEntities db = new websitedbEntities())
                {
                    Restaurants restaurants1 = new Restaurants();
                    restaurants1.Restaurant_Id = 3;
                    restaurants1.Owner_LastName = "Ly";
                    restaurants1.Owner_FirstName = "Kung muy";
                    restaurants1.Restaurant_City = "Köln Kalk Ehrenmord";
                    restaurants1.Restaurant_PostalCode = 51105;
                    restaurants1.Restaurant_StreetName = "Rolshover Str. 12";
                    
                    db.Restaurants.Add(restaurants1);
                    db.SaveChanges();
                }

                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach(Restaurants r in db.Restaurants)
                    {
                       
                    }

                    Restaurants ds = db.Restaurants.Where(x => x.Restaurant_StreetName == "Rolshoverstr ").First();
                    ds.Owner_FirstName = "Shengu Ling long";
                    db.SaveChanges();
                }
                
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

            }
           

            try
            {
                if (ModelState.IsValid)
                {
                    RestaurantRepository restaurantrepo = new RestaurantRepository();

                    if (restaurantrepo.AddRestaurant(restaurants))
                    {
                        ViewBag.message = "restaurant details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //To Add Restaurant details
        public bool AddRestaurants(RestaurantModel obj)
        {

            connection();
  
            SqlCommand com = new SqlCommand("AddNewRestaurantsDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Restaurant_Id", obj.ResID);
            com.Parameters.AddWithValue("@Owner_FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@Owner_LastName", obj.LastName);
            com.Parameters.AddWithValue("@Restaurant_City", obj.City);
            com.Parameters.AddWithValue("@Restaurant_StreetName", obj.StreetName);
            com.Parameters.AddWithValue("@Restaurant_PostalCode", obj.PostalCode);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
            
        }

    }

}