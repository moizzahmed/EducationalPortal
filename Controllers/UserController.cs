using EducationalPortal.Models;
using EducationalPortal.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            return View(await _userService.GetAll());
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            return View(await _userService.GetById(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User userModel)
        {
            try
            {
                var response = await _userService.Add(userModel);

                if (response.Status)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await _userService.GetById(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var User = new User();
                var response = await _userService.Update(User);
                if (response.Status)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            return View(await _userService.GetById(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                var user = await _userService.GetById(id);
                var response = await _userService.Delete(user);

                if (response.Status)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
