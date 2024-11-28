using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class DetalleVentaService //: IDetalleVentaService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public DetalleVentaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<DetalleVenta>> GetDetalleVentasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("DetalleVenta/ObtenerDetalleVentaTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<DetalleVenta>>();
        }        

        public async Task<bool> CreateDetalleVentaAsync(DetalleVenta DetalleVenta, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("DetalleVenta/InsertDetalleVenta", DetalleVenta);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDetalleVentaAsync(DetalleVenta DetalleVenta, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"DetalleVenta/ActualizarDetalleVenta", DetalleVenta);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDetalleVentaAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"DetalleVenta/EliminarDetalleVenta/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
