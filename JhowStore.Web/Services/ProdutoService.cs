using JhosStoreModels.DTOs;
using System.Net.Http.Json;

namespace JhowStore.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient;

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");
                return produtosDto;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao acessar produtos: api/produtos");
            }
        }

        public async Task<ProdutoDto> GetItem(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/produtos/{id}");

                if (response.IsSuccessStatusCode) 
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProdutoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<ProdutoDto>();
                }
                else
                {
                    var mensagem = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status Code: {response.StatusCode} - {mensagem}");
                }

            }
            catch (Exception)
            {

                throw new Exception($"Erro ao obter o produto {id}!");
            }
        }
    }
}
