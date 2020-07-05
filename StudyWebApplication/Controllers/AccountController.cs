using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyWebApplication.DbContext;
using StudyWebApplication.Models;
using StudyWebApplication.ViewModel;

namespace StudyWebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(DtoUser model)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = Data.SelectUser(model.UserId, model.UserPassword);
            }
            return View(model);
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }
    }
}
