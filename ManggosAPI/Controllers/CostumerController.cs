using ManggosAPI.Data;
using ManggosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ManggosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var customers = await _context.costumers.ToListAsync();
            return Ok(customers);
        }

        // GET: api/Customer/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            var customer = await _context.costumers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody] RequestData request)
        {
            var customer = new Costumer
            {
                Id = Guid.NewGuid(),
                Barang = request.barang,
                Jumlah = request.jumlah,
                Harga = request.harga,
                TotalHarga = request.totalharga,
        };

            await _context.costumers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetail), new { id = customer.Id }, customer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RequestData request)
        {
            var customer = await _context.costumers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Barang = request.barang;
            customer.Jumlah = request.jumlah;
            customer.Harga = request.harga;
            customer.TotalHarga = request.totalharga;

            _context.costumers.Update(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var customer = await _context.costumers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.costumers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }
    }
}
