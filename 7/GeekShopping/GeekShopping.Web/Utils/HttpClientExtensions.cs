using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException();

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataAsString);
            stringContent.Headers.ContentType = contentType;
            return client.PostAsync(url,stringContent);
        }

        public static Task<HttpResponseMessage> PustAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataAsString);
            stringContent.Headers.ContentType = contentType;
            return client.PutAsync(url, stringContent);
        }
    }
}
