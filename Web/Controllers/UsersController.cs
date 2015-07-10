using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(userRepository.GetUsers());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(userRepository.GetUserByID(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                userRepository.InsertUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(userRepository.GetUserByID(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                userRepository.UpdateUser(id, user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View(userRepository.GetUserByID(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                userRepository.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
