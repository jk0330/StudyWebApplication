using System;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyWebApplication.DbHelper;
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
            if (model.Start == 0)
            {
                model.Start = 1;
                model.End = 5;
                model.NoteCount = 5;
            }

            int count = NoteData.SelectNoteCount();

            if (model.Start < 1)
            {
                model.Start = 1;
            }
            else if (model.End > count)
            {
                model.End = count;
            }

            if (count < 5)
            {
                count = 5;
            }

            var notes = NoteData.SelectNote(model).Select();

            NoteIndexView viewModel = new NoteIndexView();

            if (notes.Length < 1)
            {
                viewModel.Notes = new System.Collections.Generic.List<DataRow>();
                viewModel.NoteCount = count;

                return View(viewModel);
            }

            viewModel.Notes = notes.ToList();
            viewModel.NoteCount = count;

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
