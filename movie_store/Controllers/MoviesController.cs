using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static movie_store.Data_modify_method.Repo;
using movie_store.Models;
using movie_store.Models.DB;

namespace movie_store.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        List<Movie> cartItems = new List<Movie>();

        // GET: All Movies
        public ActionResult Index()
        {
            return View(GetMovies());
        }

        // Get: Movie by Title
        public ActionResult SearchMovies(string searchString)
        {
            return View(GetSearchMoviesByTitle(searchString));
        }


        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Director,ReleaseYear,Price,ImgUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                SaveMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //add a movie order to cart , might delete if this action is recreated in cartcontroller
        public ActionResult AddToCart(int id)
        {

            var cartItem = _db.Movies.FirstOrDefault(m => m.Id == id);

            if (Session.IsNewSession && cartItems != null || Session["cart"] == null && cartItems != null)
            {
                cartItems.Add(cartItem);
                Session["cart"] = cartItems;
            }
            else
            {
                cartItems = (List<Movie>)Session["cart"];
                cartItems.Add(cartItem);
                Session["cart"] = cartItems;
            }

            return RedirectToAction("Index");
        }

        //// GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Director,ReleaseYear,Price,ImdbRating,ImdbId,ImdbRated,Plot,ImgUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = _db.Movies.Find(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose()
        //{
        //    _db.Dispose();
        //    base.Dispose();
        //    /*            if (disposing)
        //                {
        //                    _db.Dispose();
        //                }
        //                base.Dispose(disposing);
        //    */
        //}
    }
}
