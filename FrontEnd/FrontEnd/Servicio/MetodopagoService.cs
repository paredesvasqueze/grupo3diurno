using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class MetodopagoService //: IMetodopagoService
    { 
    
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public MetodopagoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);            
        }

        public async Task<IEnumerable<Metodopago>> GetMetodopagosAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Metodopago/ObtenerMetodopagoTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Metodopago>>();
        }        

        public async Task<bool> CreateMetodopagoAsync(Metodopago Metodopago, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Metodopago/InsertarMetodopago", Metodopago);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateMetodopagoAsync(Metodopago Metodopago, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Metodopago/ActualizarMetodopago", Metodopago);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMetodopagoAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Metodopago/EliminarMetodopago/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
