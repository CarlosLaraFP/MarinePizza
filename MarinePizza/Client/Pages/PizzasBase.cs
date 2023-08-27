using MarinePizza.Client.Services.Contracts;
using MarinePizza.Models;
using Microsoft.AspNetCore.Components;

namespace MarinePizza.Client.Pages;

public class PizzasBase : ComponentBase
{
	[Inject]
	public IPizzaService PizzaService { get; set; }

	public IEnumerable<Pizza> Pizzas { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Pizzas = await PizzaService.GetPizzas();
    }
}

