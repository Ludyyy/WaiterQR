using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
    public class RestaurantTableController : Controller
    {
        // GET: RestaurantTable
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

        [HttpPost]
        public ActionResult EditRestaurantTable(RestaurantTableViewModel restaurantTableViewModel)
        {
            try
            {
                var tempList = new List<RestaurantTable>();
                int tableamount = 0;
                using (websitedbEntities db = new websitedbEntities())
                {
                    int resid = restaurantTableViewModel.ResID;
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
                       

                    }
                    if (tableamount > restaurantTableViewModel.capacity)
                    {

                    }
                    if (tableamount == restaurantTableViewModel.capacity)
                    {

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
