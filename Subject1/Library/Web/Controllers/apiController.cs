using Library.BLL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class apiController : Controller
    {
        public JsonResult GetBookList()
        {
            BookBll bll = new BookBll();
            List<Book> books = bll.GetModelList("");
            ViewBag.books = books;
            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}