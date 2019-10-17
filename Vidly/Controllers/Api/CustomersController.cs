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

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/customers
        public IHttpActionResult GetCustomers(string query = null) {
            var customersQuery = _context.Customers
            .Include(c => c.MembershipType);

            if(!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                   
            .ToList().Select(Mapper.Map<Customer, CustomerDto>);
        
            return Ok(customerDtos);

        }
        //GET  /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(cust));

        }

        // post /api/customer
        [HttpPost]

        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);


        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)

               return BadRequest();
            var custtomerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custtomerInDb == null)
                return NotFound();
            Mapper.Map(customerDto, custtomerInDb);

            _context.SaveChanges();
            return Ok();        }

        //DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var custtomerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custtomerInDb == null)
                return NotFound();
            _context.Customers.Remove(custtomerInDb);

            _context.SaveChanges();

            return Ok();

        }

    }
}

