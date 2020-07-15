// This class defines the product handling such as Editing, Deleting, Adding and Showing of different RestaurantTables.
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
    [Authorize] //only accessible with login

    public class RestaurantTableController : Controller
    {
        // GET: Gives out the restaurant tables for a specific restaurant based on the given restaurant id
        public ActionResult ShowRestaurantTable(int restaurantid)
        {
            try
            {
                var tempList = new List<RestaurantTable>();
                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach (RestaurantTable rt in db.RestaurantTable)
                    {
                        if (rt.RestaurantID == restaurantid)
                        {
                            tempList.Add(rt);
                        }
                        
                    }
                }
                RestaurantTableViewModel rtvw = new RestaurantTableViewModel();
                rtvw.ResID = restaurantid;
                rtvw.RestaurantTables = tempList;
                return View(rtvw);
            }


            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();

            }        
        }

        // GET: Opens the EditRestaurantTable view and gives the user the option to reset the attributes. The restaurant id clearly identifies the restaurant to change and
        // therefore the fields are auto completed
        public ActionResult EditRestaurantTable(int restaurantid)
        {
            try
            {
                var tempList = new List<RestaurantTable>();
                int tableamount = 0;
                using (websitedbEntities db = new websitedbEntities())
                {              
                    tableamount = db.RestaurantTable.Where(x => x.RestaurantID == restaurantid).Count();

                }
                RestaurantTableViewModel rv = new RestaurantTableViewModel();
                rv.ResID = restaurantid;
                rv.capacity = tableamount;
                return View(rv);

            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

            }
            return View();

        }
        // POST: RestaurantTable/Edit Edits the product in the database based on the user input
        [HttpPost]
        public ActionResult EditRestaurantTable(RestaurantTableViewModel restaurantTableViewModel)
        {
            try
            {
                var tempList = new List<RestaurantTable>();
                int tableamount = 0;
                using (websitedbEntities db = new websitedbEntities())
                {

                    tableamount = db.RestaurantTable.Where(x => x.RestaurantID == restaurantTableViewModel.ResID).Count();

                    if (tableamount < restaurantTableViewModel.capacity)
                    {

                        while (tableamount < restaurantTableViewModel.capacity)
                        {
                            RestaurantTable rt = new RestaurantTable();
                            rt.RestaurantID = restaurantTableViewModel.ResID;
                            rt.RestaurantSeat = tableamount + 1;
                            tableamount = tableamount + 1;

                            db.RestaurantTable.Add(rt);
                            db.SaveChanges();
                        }
                        ViewBag.message = "Successfully increased to " + restaurantTableViewModel.capacity + " Tables";
                        ViewBag.resid = restaurantTableViewModel.ResID;

                    }
                    else if (tableamount > restaurantTableViewModel.capacity)
                    {
                        List<RestaurantTable> tableList = db.RestaurantTable.ToList();

                        foreach (RestaurantTable rt in tableList)
                        {
                            if(rt.RestaurantID == restaurantTableViewModel.ResID)
                            {                      
                              db.RestaurantTable.Remove(rt);
                              db.SaveChanges();
                            }
                        }

                        tableamount = 0;
                        while (tableamount < restaurantTableViewModel.capacity)
                        {
                            RestaurantTable rt = new RestaurantTable();
                            rt.RestaurantID = restaurantTableViewModel.ResID;
                            rt.RestaurantSeat = tableamount + 1;
                            tableamount = tableamount + 1;

                            db.RestaurantTable.Add(rt);
                            db.SaveChanges();
                        }
                        ViewBag.message = "Successfully decreased to "+ restaurantTableViewModel.capacity + " Tables";
                        ViewBag.resid = restaurantTableViewModel.ResID;

                    }
                   else if (tableamount == restaurantTableViewModel.capacity)
                    {
                        ViewBag.message = "Please enter a different Table Capacity Number than the current one";
                        ViewBag.resid = restaurantTableViewModel.ResID;

                    }
                }
            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

            }
            return View();

        }

    }
}
