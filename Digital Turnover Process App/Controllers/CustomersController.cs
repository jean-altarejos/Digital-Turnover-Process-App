using Digital_Turnover_Process_App.Data;
using Digital_Turnover_Process_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Digital_Turnover_Process_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAllCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById (int Id)
        {
            var customer = await _context.Customers.FindAsync(Id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {
            if (customer == null || customer.Id == 0)
            {
                return BadRequest();
            }
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.CustomerAccountNumber = customer.CustomerAccountNumber;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.GivenName = customer.GivenName;
            existingCustomer.MiddleName = customer.MiddleName;
            existingCustomer.Suffix = customer.Suffix;
            existingCustomer.Email = customer.Email;
            existingCustomer.ContactNumber = customer.ContactNumber;
            existingCustomer.Category = customer.Category;
            existingCustomer.primaryBuyerId = customer.primaryBuyerId;
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
