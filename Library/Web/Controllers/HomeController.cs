using Library.BLL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "关于我";

            return View();
        }

        public ActionResult List()
        {
            BookBll bll = new BookBll();
            List<Book> books = bll.GetModelList("");
            ViewBag.books = books;
            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }


        public ActionResult EditBook(int id)
        {
            BookBll bll = new BookBll();
            if (id > 0)
            {
                Book book = bll.GetModel(id);
                ViewBag.book = book;
            }
            else
            {
                ViewBag.book = null;
            }
            return View();
        }

        public ActionResult DeleteBook(int id)
        {
            BookBll bll = new BookBll();
            if (id > 0)
            {
                Book book = bll.GetModel(id);
                ViewBag.book = book;
            }
            else
            {
                ViewBag.book = null;
            }
            return View();
        }

        public ActionResult BookOperation()
        {
            var bookValues = Request.Form;
            string type = Convert.ToString(bookValues["type"]);
            if(type == "add")
            {
                bool res = this.DealWithAddBook(bookValues);
                ViewBag.message = res ? "添加成功" : "添加失败";
            }

            if (type == "edit")
            {
                bool res = this.DealWithEditBook(bookValues);
                ViewBag.message = res ? "修改成功" : "修改失败";
            }

            if (type == "delete")
            {
                bool res = this.DealWithDeleteBook(bookValues);
                ViewBag.message = res ? "删除成功" : "删除失败";
            }
            return View();
        }

        #region JSON获取
        //public JsonResult AddBook()
        //{
        //    return new JsonResult();
        //}
        #endregion

        #region 私有业务处理逻辑
        private bool DealWithAddBook(dynamic bookValues)
        {
            Book book = new Book()
            {
                name = bookValues["name"],
                author = bookValues["author"],
                publish = bookValues["publish"],
                price = String.IsNullOrEmpty(bookValues["price"]) ? null : Convert.ToDecimal(bookValues["price"]),
                date = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss:f"),
                isbn = bookValues["isbn"],
                cover = bookValues["cover"],
            };

            BookBll bll = new BookBll();
            int res = bll.Add(book);

            return res > 0;
        }


        private bool DealWithEditBook(dynamic bookValues)
        {
            Book book = new Book()
            {
                id = Convert.ToInt32(bookValues["id"]),
                name = bookValues["name"],
                author = bookValues["author"],
                publish = bookValues["publish"],
                price = String.IsNullOrEmpty(bookValues["price"]) ? null : Convert.ToDecimal(bookValues["price"]),
                isbn = bookValues["isbn"],
                cover = bookValues["cover"],
            };

            BookBll bll = new BookBll();
            return bll.Update(book);
        }


        private bool DealWithDeleteBook(dynamic bookValues)
        {
            int id = Convert.ToInt32(bookValues["id"]);

            BookBll bll = new BookBll();
            return bll.Delete(id);
        }


        #endregion

    }
}