using System.Web.Mvc;
using OrdersAssignment.Models;
using OrdersAssignment.Utilities;

namespace OrdersAssignment.Controllers
{
    public class CustomersController : Controller
    {
        private OrdersAssignmentContext db = new OrdersAssignmentContext();
        private const string bind = "Id,Name,CreditLimit";

        public ActionResult Add([Bind(Include = bind)] Customer customer)
        {
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Delete(int? id)
        {
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Get(int? id)
        {
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult List()
        {
            return Json(new Msg { Result = "Placeholder", Message = "Placeholder" });
        }

        public ActionResult Update([Bind(Include = bind)] Customer customer)
        {
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
