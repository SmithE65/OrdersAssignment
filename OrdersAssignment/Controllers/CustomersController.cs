using System.Web.Mvc;
using OrdersAssignment.Models;
using OrdersAssignment.Utilities;
using System.Linq;
using System;

namespace OrdersAssignment.Controllers
{
    public class CustomersController : Controller
    {
        private OrdersAssignmentContext db = new OrdersAssignmentContext();
        private const string bind = "Id,Name,CreditLimit";

        public ActionResult Add([Bind(Include = bind)] Customer customer)
        {
            // Check for errors in the ModelState
            if (ModelState.IsValid)
            {
                try // These things can blow up
                {
                    db.Customers.Add(customer); // Put the customer in the local cache
                    db.SaveChanges();           // Save to database
                }
                catch (Exception e) // On blow up: inform the user
                {
                    return Json(new Msg { Result = "Error", Message = e.Message });
                }
                return Json(new Msg { Result = "Success", Message = "Placeholder" });
            }
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Delete(int? id)
        {
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null || id <= 0)  // Do we have an id and is it in the valid range?
                return Json(new Msg { Result = "Error", Message = "Invalid Customer.Id: out of range error." });

            Customer customer = db.Customers.Find(id);  // Attempt to find a customer with the given id

            if (customer == null)   // Is there a customer with the given id?
                return Json(new Msg { Result = "Error", Message = "Invalid CUstomer.Id." });

            // Send out the selected customer in JSON format
            return new JsonNetResult { Data = customer };
        }

        public ActionResult List()
        {
            // Send out a list of Customers in JSON format
            return new JsonNetResult { Data = db.Customers.ToList() };
        }

        public ActionResult Update([Bind(Include = bind)] Customer customer)
        {
            if (ModelState.IsValid)     // If all our data look ok.
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified; // Flag this customer as Modified
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
