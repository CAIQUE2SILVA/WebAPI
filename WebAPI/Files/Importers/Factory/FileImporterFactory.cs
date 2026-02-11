using WebAPI.Files.Importers.Contract;
using WebAPI.Files.Importers.Impl;

namespace WebAPI.Files.Importers.Factory
{
    public class FileImporterFactory(IServiceProvider serviceProvider, ILogger<FileImporterFactory> logger)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly ILogger<FileImporterFactory> _logger = logger;

        public IFileImporter GetImporter(string fileName)
        {
            if (fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Selected CSV File Importer for file: {FileName}", fileName);
                return _serviceProvider.GetRequiredService<CsvImporter>();
            }
            else if (fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Selected Excel File Importer for file: {FileName}", fileName);
                return _serviceProvider.GetRequiredService<ExcelImporter>();
            }
            else
            {
                _logger.LogError("Unsupported file format: {FileName}", fileName);
                throw new NotSupportedException($"The file format of '{fileName}' is not supported.");
            }
        }
    }
}
