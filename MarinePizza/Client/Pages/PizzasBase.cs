using MarinePizza.Client.Services.Contracts;
using MarinePizza.Models;
using Microsoft.AspNetCore.Components;

namespace MarinePizza.Client.Pages;

public class PizzasBase : ComponentBase
{
	[Inject]
	public required IPizzaService PizzaService { get; set; }

	public IEnumerable<Pizza>? Pizzas { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadPizzas();
    }

    protected async Task LoadPizzas()
    {
        Pizzas = await PizzaService.GetPizzas();
        // Ensure the component re-renders to reflect the changes.
        StateHasChanged();
    }

    protected async Task RefreshPizzas()
    {
        Pizzas = null; // Set to null to show the loading state.
        await LoadPizzas();
    }
}

