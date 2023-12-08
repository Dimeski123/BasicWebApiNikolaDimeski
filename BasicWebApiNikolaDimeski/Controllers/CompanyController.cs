using BasicWebApiNikolaDimeski.Data;
using BasicWebApiNikolaDimeski.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiNikolaDimeski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private BasicWebApiDbContext _context;

        public CompanyController(BasicWebApiDbContext context) => _context = context;

        //Get By ID

        [HttpGet("id")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int i)
        {
            var company = await _context.Companies.FindAsync(i);
            return company == null ? NotFound() : Ok(company);
        }

        //Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = company.CompanyId}, company);
        }

        //Select (Get)

        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _context.Companies.ToListAsync();
        }

        //Update

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Company company)
        {
            if (id != company.CompanyId) return BadRequest();
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Delete

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var companyToDelete = await _context.Companies.FindAsync(id);
            if (companyToDelete == null) { return NotFound(); }

            _context.Companies.Remove(companyToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
