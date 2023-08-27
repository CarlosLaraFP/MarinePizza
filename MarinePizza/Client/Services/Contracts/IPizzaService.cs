using MarinePizza.Models;

namespace MarinePizza.Client.Services.Contracts;

public interface IPizzaService
{
    Task<IEnumerable<Pizza>> GetPizzas();
}

