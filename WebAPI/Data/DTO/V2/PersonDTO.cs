using System.Text.Json.Serialization;
using WebAPI.JsonSerializers;

namespace WebAPI.Data.DTO.V2
{
    public class PersonDTO
    {
        //[JsonPropertyName("code")]
        //[JsonPropertyOrder(5)]

        public long Id { get; set; }

        //[JsonPropertyName("first_name")]
        //[JsonPropertyOrder(4)]
        public string FirstName { get; set; }

        //[JsonPropertyName("last_name")]
        //[JsonPropertyOrder(3)]

        public string LastName { get; set; }

        //[JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Address { get; set; }
        //[JsonPropertyOrder(2)]

        [JsonConverter(typeof(GenderSerializer))]
        public string Gender { get; set; }

        //[JsonConverter(typeof(DateSerializer))]
        [JsonIgnore]
        public DateTime? BirthDay { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Age { get; set; }
    }
}
