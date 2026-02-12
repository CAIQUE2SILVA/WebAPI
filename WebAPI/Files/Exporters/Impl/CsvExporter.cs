using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using WebAPI.Data.DTO.V1;
using WebAPI.Files.Exporters.Contract;
using WebAPI.Files.Importers.Factory;

namespace WebAPI.Files.Exporters.Impl
{
    internal class CsvExporter : IFileExporter
    {
        public FileContentResult ExportToFile<T>(List<PersonDTO> people)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream , Encoding.UTF8, leaveOpen: true);

            using var csv = new CsvWriter(writer, 
                new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                });
            csv.WriteRecords(people);
            writer.Flush();

            var fileBytes = memoryStream.ToArray();

            return new FileContentResult(fileBytes, MediaTypes.AplicationCsv)
            {
                FileDownloadName = $"people_exporterd_{DateTime.UtcNow: yyyyMMddHHmmss}.csv"
            };
        }
    }
}