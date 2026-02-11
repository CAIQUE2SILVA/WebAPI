using ClosedXML.Excel;
using WebAPI.Data.DTO.V1;
using WebAPI.Files.Importers.Contract;

namespace WebAPI.Files.Importers.Impl
{
    internal class ExcelImporter : IFileImporter
    {
        public Task<List<PersonDTO>> ImportFileAsync(Stream fileStream)
        {
            var people = new List<PersonDTO>();

            using var workbook = new XLWorkbook(fileStream);

            var worksheet = workbook.Worksheets.First(); 

            var rows = worksheet.RowsUsed().Skip(1);
            foreach (var row in rows)
            {
                if(!row.Cell(1).IsEmpty())
                {
                    people.Add ( new PersonDTO
                    {
                        FirstName = row.Cell(1).GetString(),
                        LastName = row.Cell(2).GetString(),
                        Address = row.Cell(3).GetString(),
                        Gender = row.Cell(4).GetString(),
                        Enabled = true
                      });
                }
            }
            return Task.FromResult(people);
        }
    }
}