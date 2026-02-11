using WebAPI.Data.DTO.V1;

namespace WebAPI.Files.Importers.Contract
{
    public interface IFileImporter
    {
        Task <List<PersonDTO>> ImportFileAsync(Stream fileStream);

    }
}
