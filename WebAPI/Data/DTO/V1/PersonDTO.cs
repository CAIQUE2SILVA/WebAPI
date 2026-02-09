using WebAPI.Hypermedia;
using WebAPI.Hypermedia.Abstract;

namespace WebAPI.Data.DTO.V1
{
    public class PersonDTO : IsuportsHypermedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public bool Enabled { get; set; }
        public List<HypermediaLink> Links { get; set; } = [];
    }
}
