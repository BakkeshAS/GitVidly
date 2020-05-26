using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public static readonly int bigBagCapacity = 5;
        public static readonly int smallBagCapacity = 1;
        #region AppDbContext
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //_context is a disposable object hence we have to dispose it manually.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        //Get // api/Customers
        [HttpGet]
        public IEnumerable<PartialCustomer> Customers()
        {
            var customer = _context.Customers.ToList();
            // datatables have difficulty in finding the length of null
            var count = customer.Count;
            PartialCustomer[] partialCustomer = new PartialCustomer[count];
            var i = 0;
            foreach (var element in customer)
            {
                partialCustomer[i] = new PartialCustomer();
                partialCustomer[i].Name = element.Name;
                partialCustomer[i].IsSubscribedToNewsletter = element.IsSubscribedToNewsletter;
                if (null == element.DOB)
                {
                    partialCustomer[i].DOB = DateTime.Now;
                }
                else
                {
                    partialCustomer[i].DOB = element.DOB;
                }
                partialCustomer[i].Id = element.Id;
                partialCustomer[i].MembershipTypeId = element.MembershipTypeId;

                i++;
            }

            return partialCustomer;
        }

        //Get // api/Customers/1
        [HttpGet]
        public Customer Customers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (null == customer)
                throw new HttpResponseException(HttpStatusCode.NotFound); //Standard Http response if customer is not found.

            return customer;
        }

        [HttpGet]
        public bool BagStatus(int goal, int big, int small)
        {
            var bRem = 0;
            //var sRem = 0;
            var bQuo = 0;
            var bDif = 0;
            var status = false;

            // if goal = 0 then we are not computing a of now
            //if (0 == goal && big >= 0 || small >= 0)
            //    return true;

            if (goal > 0)
            {
                if (big > 0 && small > 0)
                {
                    //bRem = goal - (bigBagCapacity * big);
                    //if (0 == bRem - (smallBagCapacity * small))
                    //    status = true;

                    //if(goal == ((big * bigBagCapacity) + (small * smallBagCapacity))) {do something} else{do something}

                    bQuo = goal / bigBagCapacity;

                    if (bQuo > big) bDif = bQuo - big;

                    bRem = goal % bigBagCapacity;

                    if ((bRem + (bDif * bigBagCapacity)) <= small) status = true;
                }
                else if ((big > 0 && 0 == small) && (goal % bigBagCapacity == 0)) status = true;

                else if ((0 == big && small > 0) && (goal % smallBagCapacity == 0)) status = true;
            }
            return status;
        }


        //post
        [HttpPost]// this action will only be called if it's an http request.
        // when a resource is created we will return the resource created because it might have got an id generated in db.
        public Customer CreateCustomer(Customer customer)// this customer will be in the request body and web api f.w. will
                                                         //automatically initialize this.
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //Put
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

            if (null == customerInDb)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.DOB = customer.DOB;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        //Delet
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (null == customerInDb)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
