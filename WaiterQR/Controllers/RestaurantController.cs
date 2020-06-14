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
                    restaurant.Restaurant_City = restaurants.Restaurant_City;
                    restaurant.Restaurant_StreetName = restaurants.Restaurant_StreetName;
                    restaurant.Restaurant_HouseNo = restaurants.Restaurant_HouseNo;



                    db.Restaurant.Add(restaurant);
                    db.SaveChanges();
                }

              

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

            }
            return View();

        }

        public ActionResult ShowRestaurant()
        {
            try
            {
                var tempList = new List<Restaurant>();
                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach (Restaurant r in db.Restaurant)
                    {
                        tempList.Add(r);
                    }
                }
                return View(tempList);
            }


            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();

            }

        }
        public ActionResult EditRestaurant(int restaurantid)
        {
            if (!restaurantid.Equals(null))
            {
                try
                {
                    websitedbEntities db = new websitedbEntities();
                    

                    var res = db.Restaurant.SingleOrDefault(x => x.RestaurantID == restaurantid);

                    return View(res);
                    
                }

                catch (Exception e)
                {
                    string s = string.Format("Fehler: {0}", e.Message);
                    s = string.Format("Typ: {0}", e.GetType());
                    return View();
                }

            }
            return View();


        }
        [HttpPost]
        public ActionResult EditRestaurant(Restaurant restaurant)
        {
            try
            {
                websitedbEntities db = new websitedbEntities();
                

                
                Restaurant res = db.Restaurant.SingleOrDefault(x => x.RestaurantID == restaurant.RestaurantID);

                res.OwnerID = restaurant.OwnerID;
                res.RestaurantPostalCode = restaurant.RestaurantPostalCode;
                res.Restaurant_City = restaurant.Restaurant_City;
                res.Restaurant_HouseNo = restaurant.Restaurant_HouseNo;
                res.Restaurant_StreetName = restaurant.Restaurant_StreetName;

                db.SaveChanges();

                ViewBag.message = "Restaurant information updated successfully.";
                return View(res);
                
            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();
            }


        }
    }
}


