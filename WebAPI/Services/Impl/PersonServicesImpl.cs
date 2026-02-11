using ClosedXML.Excel;
using Mapster;
using WebAPI.Data.Converter.Impl;
using WebAPI.Data.DTO.V1;
using WebAPI.Files.Importers.Factory;
using WebAPI.Model;
using WebAPI.Repositorys;
using WebAPI.Repositorys.Impl;

namespace WebAPI.Services.Impl
{
    public class PersonServicesImpl : IPersonServices

    {

        private IPersonRepository _repository;
        private readonly FileImporterFactory _fileImporterFactory;
        private readonly ILogger<PersonServicesImpl> _logger;
        private readonly PersonConverter _converter;

        public PersonServicesImpl(
            IPersonRepository repository ,
            FileImporterFactory fileimporterFactory,
            ILogger<PersonServicesImpl> logger
            )
        {
            _repository = repository;
            _fileImporterFactory = fileimporterFactory;
            _converter = new PersonConverter();
            _logger = logger;
        }

        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonDTO Disable(long id)
        {

            var entity = _repository.Disable(id);
            return entity?.Adapt<PersonDTO>();

        }

        public async Task<List<PersonDTO>> MassCreationAsync(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                _logger.LogError("File is null or empty.");
                throw new ArgumentException("File is null or empty.");
            }
            using var stream = file.OpenReadStream();
            var fileName = file.FileName;
            try
            {
                var importer = _fileImporterFactory.GetImporter(fileName);
                var persons = await importer.ImportFileAsync(stream);
                
                var entities = persons
                    .Select(dto => _repository.Create(
                        dto.Adapt<Person>())).ToList();
                return entities.Adapt<List<PersonDTO>>();
            }
            catch (Exception)
            {
                _logger.LogError("Failed to import file: {FileName}", fileName);
                throw ;
            }
        }
    }   

}
