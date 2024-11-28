using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class DetallecompraService //: IDetallecompraService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public DetallecompraService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Detallecompra>> GetDetallecomprasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Detallecompra/ObtenerDetallecompraTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Detallecompra>>();
        }

        public async Task<bool> CreateDetallecompraAsync(Detallecompra Detallecompra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Detallecompra/InsertDetallecompra", Detallecompra);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDetallecompraAsync(Detallecompra Detallecompra, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Detallecompra/ActualizarDetallecompra", Detallecompra);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDetallecompraAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Detallecompra/EliminarDetallecompra/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
