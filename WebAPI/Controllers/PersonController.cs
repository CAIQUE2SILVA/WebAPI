using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Model;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all persons");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {            
            _logger.LogInformation("Getting person with id {Id}", id);
            var person = _personServices.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with id {Id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Creating a new person" );
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to create person: {fristName}", person.FristName);
                return NotFound();
            }
            return Ok(createdPerson);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("Updating person with id {Id}", person.Id);
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to update person with id {Id}", person.Id);
                return NotFound();

            }
            _logger.LogInformation("Person with id {Id} updated successfully", person.Id);
            return Ok(createdPerson);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting person with id {Id}", id);
            _personServices.Delete(id);
            _logger.LogInformation("Person with id {Id} deleted successfully", id);
            return NoContent();
        }

    }
}
