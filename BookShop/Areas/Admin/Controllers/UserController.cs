using BookShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetUsers());
        }

        public IActionResult Login(string username, string password)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            int count = context.CheckLogin(username, password);
            if (count > 0)
                return RedirectToAction("/Admin/Dashboard/Index");
            else
                return RedirectToAction("/Admin/Dashboard/Login");

        }
        public IActionResult EnterUser()
        {
            return View();
        }


        public IActionResult RegisterUser(User acc)
        {
            int count;

            //StoreContext context = HttpContext.RequestServices.GetService(typeof(BookShop.Areas.Admin.Models.StoreContext)) as StoreContext;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.RegisterUser(acc);
            if (count> 0)
                ViewData["thongbao"] = "Đăng ký Thành Công";
            else

                ViewData["thongbao"] = "Đăng ký không thành công";
            return View();
        }

        public IActionResult CheckRegister()
        {
            return View();
        }

        public IActionResult CheckRegisterUsername(User us)
        {
            int count;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.CheckRegisterUsername(us.username);
            if (count > 0)
                ViewData["thongbao"] = "Ten dang nhap da ton tai";
            else
            { return View(CheckRegisterEmail(us)); }
            return View();
        }

        public IActionResult CheckRegisterEmail(User mail)
        {
            int count;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.CheckRegisterEmail(mail.email);
            if (count > 0)
                ViewData["thongbao"] = "Email da duoc su dung";
            else
            { return View(RegisterUser(mail)); }
            return View();

        }

        public IActionResult ViewUser(string Id)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            User us = context.ViewUser(Id);
            ViewData.Model = us;
            return View();
        }
        public IActionResult UpdateUser(User us)
        {
            int count;
            string message = string.Empty;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");

            count = context.UpdateUser(us);
           
            return RedirectToAction("Index", "User");

        }
        public IActionResult DeleteUser(string ID)
        {

            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            context.DeleteUser(ID);
            return RedirectToAction("Index", "User");
        }

        protected void SetAlert(string msg, int type)
        {
            TempData["AlertMessage"] = msg;
            TempData["AlertMessage"] = msg;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }

    }
}
