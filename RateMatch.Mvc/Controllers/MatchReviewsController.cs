using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateMatch.Mvc.Controllers
{
    public class MatchReviewsController : Controller
    {
        // GET: MatchReviewsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MatchReviewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MatchReviewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchReviewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MatchReviewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MatchReviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: MatchReviewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MatchReviewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
