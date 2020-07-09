using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyWebApplication.DbContext;
using StudyWebApplication.ViewModels;

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
            var notes = NoteData.SelectNote(model).Tables[0];//.Tables[0].Select().OrderByDescending(no => no["No"]);

            NoteIndexView viewModel = new NoteIndexView();
            if (notes.Rows.Count < 1)
            {
                viewModel.Notes = new System.Collections.Generic.List<DataRow>();
                viewModel.NoteCount = 0;

                return View(viewModel);
            }

            viewModel.Notes = notes.Select().OrderByDescending(no => no["No"]).ToList();
            viewModel.NoteCount = notes.Select().Length;

            return View(viewModel);
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
