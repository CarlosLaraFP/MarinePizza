using System.Net.Http.Json;
using MarinePizza.Client.Services.Contracts;
using MarinePizza.Models;

namespace MarinePizza.Client.Services;

public class PizzaService : IPizzaService
{
	private readonly HttpClient _client;

	public PizzaService(HttpClient client)
	{
		_client = client;
	}

    public async Task<IEnumerable<Pizza>> GetPizzas()
    {
        try
        {
            var pizzas = await _client.GetFromJsonAsync<IEnumerable<Pizza>>("Pizza");
            return pizzas;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

