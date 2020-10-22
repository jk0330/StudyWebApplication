using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyWebApplication.DbHelper;
using StudyWebApplication.ViewModels;
using System.Data;
using System.Linq;

namespace StudyWebApplication.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns></returns>
        // GET: NoteController
        [HttpGet]
        public ActionResult Index(NoteIndexView model)
        {
            if (model.Page == 0)
            {
                model.Page = 1;
            }

            int count = NoteData.SelectNoteCount();

            model.NoteCount = (count % 10 == 0) ? (count / 10) : ((count / 10) + 1);

            var notes = NoteData.SelectNote(model).Select();

            if (notes.Length < 1)
            {
                model.Notes = new System.Collections.Generic.List<DataRow>();

                return View(model);
            }

            model.Notes = notes.ToList();

            return View(model);
        }

        public ActionResult Test()
        {
            return new JsonResult(new string[] { "c", "j", "k" });
        }
        // GET: NoteController/Details/5
        public ActionResult Detail(int no)
        {
            return View(NoteData.SelectDetail(no).Select().First());
        }

        /// <summary>
        /// 게시글 생성
        /// </summary>
        /// <returns></returns>
        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 게시글 생성
        /// </summary>
        /// <returns></returns>
        // POST: NoteController/Create
        [HttpPost]
        public ActionResult Create(NoteIndexCreate model)
        {
            model.UserName = HttpContext.Session.GetString("USER_LOGIN_KEY");

            if (ModelState.IsValid)
            {
                int result = NoteData.InsertNote(model);

                if (result > 0)
                {
                    return RedirectToAction("Index", "Note");
                }
            }

            return View();
        }

        /// <summary>
        /// 게시글 수정
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// 게시글 수정
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: NoteController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// 게시글 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: NoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// 게시글 수정
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: NoteController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
