using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    // name of the controller excluding Controller part is important to 
    //create connection to the Customer folder in the views folder.
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //_context is a disposable object hence we have to dispose it manually.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [Route("Customer/Customers/{Id}")]
        public ActionResult Customers(int Id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if(!String.IsNullOrEmpty(customers.Name))                       
                return View(customers);
            else
                return HttpNotFound();
        }

        public ActionResult AllCustomers()// name of an action and the view file name should match to create a connection.
        {
            // var customers = _context.Customers; 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(customers);
        }
    }
}