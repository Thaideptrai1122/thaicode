using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShop.Areas.Admin.Models;
using MySql.Data.MySqlClient;



namespace BookShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

     

        public IActionResult Login()
        {

            return View();
        }
    }
}
