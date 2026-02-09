using Mapster;
using WebAPI.Data.Converter.Impl;
using WebAPI.Data.DTO.V1;
using WebAPI.Model;
using WebAPI.Repositorys;
using WebAPI.Repositorys.Impl;

namespace WebAPI.Services.Impl
{
    public class PersonServicesImpl : IPersonServices

        {

            private IPersonRepository _repository;
            private readonly PersonConverter _converter;

        public PersonServicesImpl(IPersonRepository repository)
            {
                _repository = repository;
                _converter = new PersonConverter();
        }

            public List<PersonDTO> FindAll()
            {
                return _converter.ParseList(_repository.FindAll());
            }

            public PersonDTO FindById(long id)
            {
                return _converter.Parse (_repository.FindById(id));
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

        }

    }
