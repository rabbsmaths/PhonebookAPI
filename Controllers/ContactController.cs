using Microsoft.AspNetCore.Mvc;

using PhonebookAPI.Interfaces;
using PhonebookAPI.Models;
using PhonebookAPI.Services;

namespace PhonebookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContact _service;

        public ContactController(IContact service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll() => Ok(_service.GetAll());

        [HttpGet("search")]
        public ActionResult<IEnumerable<Contact>> Search([FromQuery] string q) => Ok(_service.Search(q));

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            try
            {
                _service.Add(contact);
                return Ok(new { message = "Contact created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{phoneNumber}")]
        public IActionResult Update(string phoneNumber, Contact contact)
        {
            if (phoneNumber != contact.PhoneNumber)
                return BadRequest(new { message = "Phone number mismatch." });

            try
            {
                _service.Update(contact);
                return Ok(new { message = "Contact updated successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{phoneNumber}")]
        public IActionResult Delete(string phoneNumber)
        {
            _service.Delete(phoneNumber);
            return Ok(new { message = "Contact deleted successfully." });
        }

    }
}
