using WAFraneProject.Models;
using WAFraneProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Main.Controllers
{
    public class ReceiptController : Controller
    {      
        public ActionResult ShowAll()
        {
            var id = ViewBag.ReceiptID = Request.Url.Segments.Last();
            var isNumeric = int.TryParse(id, out int n);

            if (Request.Cookies["account"] == null)
            Response.Redirect("~/WebForms/Login.aspx");

            if (id == null || !isNumeric)
                return RedirectToAction(
                    actionName: "Index",
                    controllerName: "Error",
                    routeValues: new { err = "The receipt was not found." });

            var model = Repository.GetAllReceipts(int.Parse(id));
            //var model = new ShowReceiptDetailsVM()
            //{
            //    ItemDetails = Repository.GetItemDetails(int.Parse(id)),
            //    Commercialist = new Commercialist(),
            //    CreditCard = new CreditCard()
            //};

            return View(model);       
        }

    }    
}