using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class ClienteService //: IClienteService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public ClienteService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Cliente/ObtenerclienteTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
        }        

        public async Task<bool> CreateClienteAsync(Cliente Cliente, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Cliente/Insertarcliente", Cliente);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateClienteAsync(Cliente Cliente, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Cliente/actualizarcliente", Cliente);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteClienteAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Cliente/eliminarcliente/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
