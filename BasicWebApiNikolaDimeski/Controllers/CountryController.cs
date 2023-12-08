using BasicWebApiNikolaDimeski.Data;
using BasicWebApiNikolaDimeski.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiNikolaDimeski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private BasicWebApiDbContext _context;

        public CountryController(BasicWebApiDbContext context) => _context = context;

        //Get By ID

        [HttpGet("id")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int i)
        {
            var country = await _context.Countries.FindAsync(i);
            return country == null ? NotFound() : Ok(country);
        }

        //Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = country.CountryId }, country);
        }

        //Select (Get)

        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _context.Countries.ToListAsync();
        }

        //Update

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Country country)
        {
            if (id != country.CountryId) return BadRequest();
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Delete

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var countryToDelete = await _context.Countries.FindAsync(id);
            if (countryToDelete == null) { return NotFound(); }

            _context.Countries.Remove(countryToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
