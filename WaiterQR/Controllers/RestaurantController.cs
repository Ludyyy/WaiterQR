// This class defines the product handling such as Editing, Deleting and Showing of different restaurants.
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

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
    [Authorize] //only accessible with login

    public class RestaurantController : Controller
    {
        // GET: Opens the addproduct view and gives the user the option to set the attributes
        public ActionResult AddRestaurant()
        {
            return View();
        }
        // POST: Product/Create Creates the product in the database based on the user input
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
        // GET: Gives out all the restaurant in the db
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
        // GET: Opens the EditRestaurant view and gives the user the option to reset the attributes. The restaurant id clearly identifies the product to change and
        // therefore the fields are auto completed
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
        // POST: REstaurant/Edit Edits the product in the database based on the user input
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

        // Restaurant/Delete Deletes the product in the database based on the given product id
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


