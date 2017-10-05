using System.Web.Mvc;
using OrdersAssignment.Models;
using OrdersAssignment.Utilities;

namespace OrdersAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersAssignmentContext db = new OrdersAssignmentContext();
        private const string bind = "Id,OrderNbr,DateReceived,CustomerId,Total";

        public ActionResult Add([Bind(Include = bind)] Order order)
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

        public ActionResult Update([Bind(Include = bind)] Order order)
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
