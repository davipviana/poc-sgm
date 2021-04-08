using System.Text.Json.Serialization;

namespace CitizenServices.Entities.Services.Saem
{
    public class School
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("acceptedAges")]
        public string AcceptedAges { get; set; }
    }
}