using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var CustomerRecord = _context.Customers.First(x => x.Id == customer.Id);
                CustomerRecord.Name = customer.Name;
                CustomerRecord.Birthdate = customer.Birthdate;
                CustomerRecord.MembershipTypeId = customer.MembershipTypeId;
                CustomerRecord.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Customers", "Customers");
        }

        public ActionResult New()
        {
            var ViewModel = new CustomerFormViewModel()
            {
                customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", ViewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel() { customer = customer, MembershipTypes = _context.MembershipTypes.ToList() };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Customers()
        {
            return View();
        }
        
        public ActionResult Details(int Id)
        {

            var customers = _context.Customers.Where(x => x.Id == Id).Include(c =>c.MembershipType).FirstOrDefault();

            return View(customers);

        }
    }
}