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
            //string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            //con = new SqlConnection(constr);
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

                    Restaurant restaurant = new Restaurant();
                    restaurant.OwnerID = restaurants.OwnerID;
                    restaurant.RestaurantPostalCode = restaurants.RestaurantPostalCode;
                    restaurant.Restaurant_City =restaurants.Restaurant_City;
                    restaurant.Restaurant_StreetName = restaurants.Restaurant_StreetName;
                    restaurant.Restaurant_HouseNo = restaurants.Restaurant_HouseNo;



                    db.Restaurant.Add(restaurant);
                    db.SaveChanges();
                }

                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach (Restaurant r in db.Restaurant)
                    {
                        var r2 = db.Restaurant.Where(x => x.Restaurant_StreetName == "Rolshover").First();
                        r2.OwnerID = 2;
                        db.SaveChanges();
                    }

                }
            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

            }
            return View();

            //    try
            //    {
            //        if (ModelState.IsValid)
            //        {
            //            RestaurantRepository restaurantrepo = new RestaurantRepository();

            //            if (restaurantrepo.AddRestaurant(restaurants))
            //            {
            //                ViewBag.message = "restaurant details added successfully";
            //            }
            //        }

            //        return View();
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //To Add Restaurant details
            //    //public bool AddRestaurants(RestaurantModel obj)
            //    {

            //        connection();

            //        SqlCommand com = new SqlCommand("AddNewRestaurantsDetails", con);
            //        com.CommandType = CommandType.StoredProcedure;
            //        com.Parameters.AddWithValue("@Restaurant_Id", obj.ResID);
            //        com.Parameters.AddWithValue("@Owner_FirstName", obj.FirstName);
            //        com.Parameters.AddWithValue("@Owner_LastName", obj.LastName);
            //        com.Parameters.AddWithValue("@Restaurant_City", obj.City);
            //        com.Parameters.AddWithValue("@Restaurant_StreetName", obj.StreetName);
            //        com.Parameters.AddWithValue("@Restaurant_PostalCode", obj.PostalCode);

            //        con.Open();
            //        int i = com.ExecuteNonQuery();
            //        con.Close();
            //        if (i >= 1)
            //        {

            //            return true;

            //        }
            //        else
            //        {

            //            return false;
            //        }

            //    }

        }

    }
}