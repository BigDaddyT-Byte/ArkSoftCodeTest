using ArkSoftExample.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArkSoftExample.Controllers
{
    public class HomeController : Controller
    {
        private CustomerDbModel db = new CustomerDbModel();
        // GET: Home
        public ActionResult Index(string Sorting_Order, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var customers = from cus in db.Customers select cus;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(customer => customer.Name.Contains(searchString)
                                       || customer.VATNumber.Contains(searchString));
            }
            switch (Sorting_Order)
            {
                case "Name":
                    customers = customers.OrderByDescending(stu => stu.Name);
                    break;
                case "Address":
                    customers = customers.OrderByDescending(stu => stu.Adress);
                    break;
                case "Telephone_Number":
                    customers = customers.OrderByDescending(stu => stu.TelephoneNumber);
                    break;
                case "Contact_Name":
                    customers = customers.OrderByDescending(stu => stu.contactName);
                    break;
                case "Contact_Email":
                    customers = customers.OrderByDescending(stu => stu.contactEmail);
                    break;
                case "VAT_Number":
                    customers = customers.OrderByDescending(stu => stu.VATNumber);
                    break;
                default:
                    customers = customers.OrderByDescending(stu => stu.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber,pageSize));
        }

        // GET: Home/Details/5
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

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Customer customerNew)

        {

            if (!ModelState.IsValid)

                return View();

            db.Customers.Add(customerNew);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customerEdited)
        {
            if (!ModelState.IsValid)

                return View();
            Customer customer = db.Customers.Find(customerEdited.Id);
            db.Customers.Remove(customer);
            db.Customers.Add(customerEdited);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
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


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
