using WebAPI.Files.Exporters.Contract;
using WebAPI.Files.Exporters.Impl;
using WebAPI.Files.Importers.Factory;

namespace WebAPI.Files.Exporters.Factory
{
    public class FileExporterFactory(IServiceProvider serviceProvider, ILogger<FileExporterFactory> logger)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly ILogger<FileExporterFactory> _logger = logger;

        public IFileExporter GetExporter(string acceptHeader)
        {
            if (string.Equals(acceptHeader, MediaTypes.ApplicationExcel, StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Creating ExcelFileExporter for Accept header: {AcceptHeader}", acceptHeader);
                return _serviceProvider.GetRequiredService<ExcelExporter>();
            }
            else if (string.Equals(acceptHeader, MediaTypes.AplicationCsv, StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Creating CsvFileExporter for Accept header: {AcceptHeader}", acceptHeader);
                return _serviceProvider.GetRequiredService<CsvExporter>();
            }
            else
            {

            }_logger.LogWarning("Unsupported Accept header: {AcceptHeader}. Defaulting to CsvFileExporter.", acceptHeader);
            throw new NotSupportedException($"Unsupported Accept header: {acceptHeader}");
        }
    }
}
