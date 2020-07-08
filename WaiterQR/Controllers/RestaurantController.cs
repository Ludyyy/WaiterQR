using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Windows.Media.Animation;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
    [Authorize]

    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurants)
        {
            try
            {
                using (websitedbEntities db = new websitedbEntities())
                {

                    Restaurant restaurant = new Restaurant();

                    
                    restaurant.OwnerID = restaurants.OwnerID;
                    restaurant.PostalCode = restaurants.PostalCode;
                    restaurant.City = restaurants.City;
                    restaurant.StreetName = restaurants.StreetName;
                    restaurant.HouseNo = restaurants.HouseNo;
                    restaurant.TableAmount = 0;
                    restaurant.Name = restaurants.Name;
                    restaurant.Description = restaurants.Description;

                   

                    db.Restaurant.Add(restaurant);
                    db.SaveChanges();


                }

            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

            }
            return RedirectToAction("ShowRestaurant");

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


                    var res = db.Restaurant.SingleOrDefault(x => x.ID == restaurantid);

                    return View(res);

                }

                catch (Exception e)
                {
                    string s = string.Format("Fehler: {0}", e.Message);
                    s = string.Format("Typ: {0}", e.GetType());
                    return View();
                }

            }
            else
            {
                return View();
            }


    }
        [HttpPost]
        public ActionResult EditRestaurant(Restaurant restaurants)
        {
            try
            {
                websitedbEntities db = new websitedbEntities();



                Restaurant restaurant = db.Restaurant.Find(restaurants.ID);

                restaurant.OwnerID = restaurants.OwnerID;
                restaurant.PostalCode = restaurants.PostalCode;
                restaurant.City = restaurants.City;
                restaurant.StreetName = restaurants.StreetName;
                restaurant.HouseNo = restaurants.HouseNo;
                restaurant.TableAmount = restaurants.TableAmount;
                restaurant.Name = restaurants.Name;
                restaurant.Description = restaurants.Description;

                db.SaveChanges();

                ViewBag.message = "Restaurant information updated successfully.";
                return View(restaurant);

            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();
            }


        }

        
        public ActionResult DeleteRestaurant(int restaurantid)
        {
            using(websitedbEntities db = new websitedbEntities())
            {
                db.Restaurant.Remove(db.Restaurant.Find(restaurantid));
                db.SaveChanges();

            }
            return RedirectToAction("ShowRestaurant");

        }
    }


}


