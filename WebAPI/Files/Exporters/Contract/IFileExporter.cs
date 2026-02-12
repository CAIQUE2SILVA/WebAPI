using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO.V1;

namespace WebAPI.Files.Exporters.Contract
{
    public interface IFileExporter
    {
        FileContentResult ExportToFile<T>(List<PersonDTO> people);
    }
}
