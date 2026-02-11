using WebAPI.Data.DTO.V1;

namespace WebAPI.Services
{
    public interface IPersonServices 
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO person);
        void Delete(long id);

        PersonDTO Disable(long id);

        Task<List<PersonDTO>> MassCreationAsync(IFormFile file);
    }

}
