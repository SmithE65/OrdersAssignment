using System.Web.Mvc;
using OrdersAssignment.Models;
using OrdersAssignment.Utilities;
using System;
using System.Linq;

namespace OrdersAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersAssignmentContext db = new OrdersAssignmentContext();
        private const string bind = "Id,OrderNbr,DateReceived,CustomerId,Total";

        public ActionResult Add([Bind(Include = bind)] Order order)
        {
            // Do we actually have an object?
            if (order == null)
            {
                return Json(new Msg { Result = "Error", Message = "Order cannot be null." });
            }

            order.IsDeleted = false; // I don't care what the user wants; it's stupid to add something that's already deleted.

            // Check for errors in the ModelState
            if (ModelState.IsValid)
            {
                try // These things can blow up
                {
                    db.Orders.Add(order); // Put the customer in the local cache
                    db.SaveChanges();           // Save to database
                }
                catch (Exception e) // On blow up: inform the user
                {
                    return Json(new Msg { Result = "Error", Message = e.Message });
                }

                // We didn't blow up! Announce our success.
                return Json(new Msg { Result = "Success", Message = "Placeholder" });
            }

            // If we wind up down here, something went wrong.
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Delete(int? id)
        {
            // Do we have a value and is it in range?
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "Invalid Order.Id: out of range." });

            // Try and find a customer
            Order order = db.Orders.Find(id);

            // Couldn't find a customer; return an error
            if (order == null)
                return Json(new Msg { Result = "Error", Message = "Invalid Order.Id" });

            // 'delete' our customer
            order.IsDeleted = true;

            // Save changes
            if (ModelState.IsValid)
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return Json(new Msg { Result = "Error", Message = e.Message });
                }
            }
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null || id <= 0)  // Do we have an id and is it in the valid range?
                return Json(new Msg { Result = "Error", Message = "Invalid Order.Id: out of range error." });

            Order order = db.Orders.Find(id);  // Attempt to find a customer with the given id

            if (order == null || order.IsDeleted == true)   // Is there a customer with the given id?
                return Json(new Msg { Result = "Error", Message = "Invalid Order.Id." });

            // Send out the selected customer in JSON format
            return new JsonNetResult { Data = order };
        }

        public ActionResult List()
        {
            // Send out a list of Customers in JSON format (ignoring those that are 'deleted')
            return new JsonNetResult { Data = db.Orders.Where(o => o.IsDeleted == false).ToList() };
        }

        public ActionResult Update([Bind(Include = bind)] Order order)
        {
            // Did we actually get a customer?
            if (order == null)
                return Json(new Msg { Result = "Error", Message = "Customer cannot be null." });

            // If we just updated it, it can't be deleted...
            order.IsDeleted = false;

            if (ModelState.IsValid)     // If all our data look ok.
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified; // Flag this customer as Modified
                try     // In case anything goes wrong
                {
                    db.SaveChanges();
                }
                catch (Exception e) // Tell the user what to tell us
                {
                    return Json(new Msg { Result = "Error", Message = e.Message });
                }
                // Send the all-clear
                return Json(new Msg { Result = "Success", Message = "Placeholder" });
            }

            // ModelState is not valid      TO-DO: List ModelState Errors
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
