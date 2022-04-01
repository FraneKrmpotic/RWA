using WAFraneProject.Models;
using WAFraneProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WAFraneProject.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index(string tab)
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            ViewBag.Tab = tab;
            return View();
        }

        //-------------------CATEGORY----------------------
        public ActionResult ViewAllCategories()
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            return View(Repository.GetCategorys());
        }

        public ActionResult AddOrEditCategory(int id = 0)
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            Category category = new Category();

            if (id != 0)
            {
                category = Repository.GetCategory(id);
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult AddOrEditCategory(Category category)
        {

            if (category.ID != 0)
            {
                Repository.UpdateCategory(category);
            }
            else
            {
                Repository.CreateCategory(category);
            }

            return RedirectToAction("Index", new { tab = "category" });
        }

        public ActionResult DeleteCategory(int id)
        {
            Repository.DeleteCategory(id);
            return RedirectToAction("ViewAllCategories");
        }

        //-------------------SUBCATEGORY----------------------
        public ActionResult ViewAllSubcategories()
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            return View(Repository.GetAllSubcategories());
        }

        public ActionResult AddOrEditSubcategory(int id = 0)
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            var model = new AddOrEditSubcategoryVM
            {
                Categories = Repository.GetCategorys()
            };

            if (id != 0)
            {
                model.Subcategory = Repository.GetSubcategory(id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrEditSubcategory(Subcategory subcategory)
        {

            if (subcategory.ID != 0)
            {
                Repository.UpdateSubcategory(subcategory);
            }
            else
            {
                Repository.CreateSubcategory(subcategory);
            }

            return RedirectToAction("Index", new { tab = "subcategory" });
        }

        public ActionResult DeleteSubcategory(int id)
        {
            Repository.DeleteSubcategory(id);
            return RedirectToAction("ViewAllSubcategories");
        }

        //-------------------PRODUCT----------------------
        public ActionResult ViewAllProducts()
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            return View(Repository.GetAllProducts());
        }

        public ActionResult AddOrEditProduct(int id = 0)
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");

            var model = new AddOrEditProductVM
            {
                Subcategories = Repository.GetAllSubcategories()
            };

            if (id != 0)
            {
                model.Product = Repository.GetProduct(id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrEditProduct(Product product)
        {

            if (product.IDProduct != 0)
            {
                Repository.UpdateProduct(product);
            }
            else
            {
                Repository.CreateProduct(product);
            }

            return RedirectToAction("Index", new { tab = "product" });
        }

        public ActionResult DeleteProduct(int id)
        {
            Repository.DeleteProduct(id);
            return RedirectToAction("ViewAllProducts");
        }
    }
}