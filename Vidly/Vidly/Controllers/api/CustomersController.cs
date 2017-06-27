using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {

        //Get/Api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.Customers
                    .Include(x=>x.MembershipType)
                    .ToList().Select(Mapper.Map<Customer, CustomerDto>);
            }
        }

        //Get/api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var customer = _context.Customers.FirstOrDefault(x => x.Id == Id);

                if (customer == null)
                    return NotFound();

                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;
            }
            
            return Created(new System.Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        [HttpPut]
        public CustomerDto UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var customerDB = _context.Customers.FirstOrDefault(x => x.Id == Id);

                if (customerDB == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);


                Mapper.Map(customerDto, customerDB);

                _context.SaveChanges();
            }

            return customerDto;
        }

        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var customerDB = _context.Customers.FirstOrDefault(x => x.Id == Id);

                if (customerDB == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _context.Customers.Remove(customerDB);
                _context.SaveChanges();
            }
        }
    }
}
