using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using movie_store.Models;
using movie_store.Models.DB;
using movie_store.ViewModels;
using static movie_store.Data_modify_method.Repo;

namespace movie_store.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,PhoneNo,BillingAddress,BillingZipCode,BillingCity,BillingCountry,DeliveryAddress,DeliveryZipCode,DeliveryCity,DeliverCountry")] Customer customer)
        {
            if (CheckDuplicateEmail(customer) == true)
            {
            ModelState.AddModelError("Email", "Email already exists.");
            }
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                if (Session["MovieList"] != null)
                {
                    return RedirectToAction("Create", "Order", new { custId = customer.Id });
                }
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // Display Customers Orders
        public ActionResult DisplayOrders(int custId)
        {
            var orderList = GetOrders(custId);

            return View(ArrangeOrders(orderList));
        }

        private CustOrdersViewModel ArrangeOrders(List<Order> orderList)
        {
            CustOrdersViewModel custOrders = new CustOrdersViewModel();
            custOrders.NumberOfOrders = orderList.Count();
            custOrders.Customer = orderList.FirstOrDefault().Customer;
            foreach (var item in orderList)
            {
                custOrders.Orders.Add(new OrderViewModel()
                {
                    Id = item.Id,
                    OrderDate = item.OrderDate,
                });
                List<OrderRowViewModel> orderItems = item.OrderRows.GroupBy(r => r.MovieId)
                                                                    .Select(ordr => new OrderRowViewModel()
                                                                    {
                                                                        Title = ordr.First().Movie.Title,
                                                                        Price = ordr.First().Movie.Price,
                                                                        SubTotal = ordr.Sum(r => r.Price),
                                                                        Copies = ordr.Count()
                                                                    }).ToList();
                custOrders.Orders.Last().OrderItems = orderItems;
            }
            return custOrders;
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int custId)
        {
            if (custId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(custId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNo,BillingAddress,BillingZipCode,BillingCity,BillingCountry,DeliveryAddress,DeliveryZipCode,DeliveryCity,DeliverCountry")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
