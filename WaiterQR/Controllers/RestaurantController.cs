using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
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