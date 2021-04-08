using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CitizenServices.Services
{
    public class SasciService : ISasciService
    {
        private readonly HttpClient _httpClient;

        public SasciService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetExamResultAsync(string exam)
        {
            var jsonBody = JsonSerializer.Serialize(new
            {
                getExamResult = new
                {
                    examCode = exam
                }
            });

            var response = await _httpClient.PostAsync("GetExamResult", new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var responseBody = await JsonSerializer.DeserializeAsync<SasciResponseContainer>(responseStream);

                return responseBody.Response.Result;
            }

        }

        private class SasciResponseContainer
        {
            [JsonPropertyName("getExamResultResponse")]
            public SasciResponse Response { get; set; }
        }

        private class SasciResponse
        {
            [JsonPropertyName("getExamResultResult")]
            public string Result { get; set; }
        }
    }
}