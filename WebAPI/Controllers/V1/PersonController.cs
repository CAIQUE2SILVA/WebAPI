using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Data.DTO.V1;
using WebAPI.Services;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Produces("application/json")]
    //[EnableCors("Development")]


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
        [ProducesResponseType(200,Type = typeof(List<PersonDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Get()
        {
            _logger.LogInformation("Getting all persons");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating a new person" );
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to create person: {fristName}", person.FirstName);
                return NotFound();
            }
            return Ok(createdPerson);
        }
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating person with id {Id}", person.Id);
            var updatedPerson = _personServices.Update(person);
            if (person == null)
            {
                _logger.LogWarning("Failed to update person with id {Id}", person.Id);
                return NotFound();

            }
            _logger.LogInformation("Person with id {Id} updated successfully", person.Id);
            return Ok(person);
        }
        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with id {Id}", id);
            _personServices.Delete(id);
            _logger.LogInformation("Person with id {Id} deleted successfully", id);
            return NoContent();
        }

        [HttpPatch("id")]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]

        public IActionResult Disable(long id)
        {
            _logger.LogInformation("Disabling person With ID {id}", id);
            var disabledPerson = _personServices.Disable(id);
            if (disabledPerson == null)
            {
                _logger.LogError("Failed to disable person with ID {id}",id);
                return NotFound();
            }
            _logger.LogDebug("Peson with ID {id} disable", id);
            return Ok(disabledPerson);
        }

        [HttpPost("massCreation")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(200, Type = typeof(List<PersonDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public async Task<IActionResult> MassCreation([FromForm] FileUploadDTO input)
        {
            if (input.File == null || input.File.Length == 0 )
            {
                _logger.LogWarning("No file uploaded for mass creation");
                return BadRequest("No file uploaded");
            }
            _logger.LogInformation("Starting mass creation of persons from file {FileName}", input.File);

            var persons = await _personServices.MassCreationAsync(input.File);

            if (persons == null || !persons.Any())
            {
                _logger.LogWarning("No valid person data found in the uploaded file {FileName}", input.File);
                return NoContent();
            }
            _logger.LogInformation("Mass creation completed successfully with {Count} persons created from file {FileName}", persons.Count, input.File);
            return Ok(persons);
        }
    }
}
