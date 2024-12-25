using System.Text.Json;
using AspireShowcase.Client.Models;
using Microsoft.Extensions.Http;

namespace AspireShowcase.Client.Services
{
    public class ProductListService
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        private readonly HttpClient _httpClient;

        public ProductListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync("products");

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<List<Product>>(stream, jsonSerializerOptions) ?? [];
        }
    }
}
