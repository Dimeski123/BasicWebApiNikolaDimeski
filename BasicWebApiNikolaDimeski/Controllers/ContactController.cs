using BasicWebApiNikolaDimeski.Data;
using BasicWebApiNikolaDimeski.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiNikolaDimeski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase

    {
        private BasicWebApiDbContext _context;

        public ContactController(BasicWebApiDbContext context) => _context = context;

        //Get By ID

        [HttpGet("id")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int i)
        {
            var contact = await _context.Contacts.FindAsync(i);

            return contact == null ? NotFound() : Ok(contact);
        }

        //Create

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = contact.ContactId }, contact);
        }

        //Select (Get)

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _context.Contacts.ToListAsync();
        }

        //Update

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            if (id != contact.ContactId) return BadRequest();
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Delete

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contactToDelete = await _context.Contacts.FindAsync(id);
            if (contactToDelete == null) { return NotFound(); }

            _context.Contacts.Remove(contactToDelete);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        //GetContactsWithCompanyAndCountry

        [HttpGet("WithCompanyAndCountry")]
        public async Task<IEnumerable<ContactUpdated>> GetContactsWithCompanyAndCountry()
        {
            var contact = await _context.Contacts.ToListAsync();
            List<ContactUpdated> result = new List<ContactUpdated>();
            foreach (Contact singleContact in contact)
            {
                var company = await _context.Companies
                    .Where(c => c.CompanyId == singleContact.CompanyId)
                    .Select(c => c.CompanyName).FirstOrDefaultAsync();

                var country = await _context.Countries
                    .Where(c => c.CountryId == singleContact.CountryId)
                   .Select(c => c.CountryName).FirstOrDefaultAsync();
                var updatedContact = new ContactUpdated
                {
                    ContactId = singleContact.ContactId,
                    ContactName = singleContact.ContactName,
                    CompanyName = company,
                    CountryName = country
                };

                result.Add(updatedContact);

            }
            return result;

        }

        //Filter Contact by Company and COuntry Id

        [HttpGet("FilterContact")]
        public async Task<IEnumerable<Contact>> FilterContact(int companyId = 0, int countryId = 0)
        {
            var contactsQuery = _context.Contacts.AsQueryable();

            if (companyId != 0)
            {
                contactsQuery = contactsQuery.Where(c => c.CompanyId == companyId);
            }

            if (countryId != 0)
            {
                contactsQuery = contactsQuery.Where(c => c.CountryId == countryId);
            }

            var contacts = await contactsQuery.ToListAsync();

            return contacts;
        }



    }
}
