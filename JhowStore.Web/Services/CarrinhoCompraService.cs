using JhosStoreModels.DTOs;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text;

namespace JhowStore.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient _httpClient;

        public event Action<int> OnCarrinhoCompraChanged;

        [Inject]
        NavigationManager ?navigationManager { get; set; }

        public CarrinhoCompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/CarrinhoCompras",
                               carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    var mensagem = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Mensagem - {mensagem}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CarrinhoItemDto>> GetItens(string usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/CarrinhoCompras/{usuarioId}/GetItens");

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent) 
                    {
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
                }
                else
                {
                    var mensagem = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code; {response.StatusCode} Mensagem: {mensagem}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CarrinhoItemDto> DeletaItem(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/CarrinhoCompras/{id}");

                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }

                return default(CarrinhoItemDto);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CarrinhoItemDto> AtualizaQuantidade(CarrinhoItemAtualizaQuantidadeDto
                                                   carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(carrinhoItemAtualizaQuantidadeDto);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/CarrinhoCompra/{carrinhoItemAtualizaQuantidadeDto.CarrinhoItemId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade)
        {
            if(OnCarrinhoCompraChanged != null)
            {
                OnCarrinhoCompraChanged.Invoke(totalQuantidade);
            }
        }
    }
}
