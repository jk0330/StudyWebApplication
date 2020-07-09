using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyWebApplication.DbHelper;
using StudyWebApplication.Models;
using System.Data;
using System.Linq;

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
        public IActionResult Login(Users model)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = UserData.SelectUser(model);

                if (dt.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("USER_LOGIN_KEY", dt.Select()[0]["USERID"].ToString());

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "사용자 아이디 또는 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");

            return RedirectToAction("Index", "Home");
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
        public IActionResult Register(Users model)
        {
            if (ModelState.IsValid)
            {
                if (UserData.InsertUser(model.UserId, model.UserPassword) > 0)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(model);
        }
    }
}
