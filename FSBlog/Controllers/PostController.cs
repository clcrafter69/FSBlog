using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogModel;
using Microsoft.AspNetCore.Authorization;

namespace FSBlog.Controllers
{
    
    public class PostController : Controller
    {
       
        private IBlogRepository _postRepo;

        public PostController(IBlogRepository repo)
        {
            _postRepo = repo;
        }

        // GET: Post
        public ActionResult Index()
        {
            return View(_postRepo.ListAll());
        }

        // GET: Post
        public ActionResult EditIndex()
        {
            return View(_postRepo.ListAll());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View(_postRepo.GetById(id));
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Post newPost, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _postRepo.Add(newPost);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(_postRepo.GetById(id));
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Post editedPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _postRepo.Edit(editedPost);
                   
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(_postRepo.GetById(id));
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _postRepo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_postRepo.GetById(id));
            }
        }
    }
}