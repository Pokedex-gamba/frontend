using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PokedexGambaApp.Shared;

public class Auth : ComponentBase
{
    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Inject] public NavigationManager Navigation { get; set; }

    protected async Task EnsureUserIsAuthenticatedAsync()
    {
        string sessionStorageToken = await JSRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
        if (string.IsNullOrEmpty(sessionStorageToken))
        {
            Navigation.NavigateTo("/");
            Console.WriteLine("User is not logged in, redirecting to login");
        }
    }

    protected async Task RedirectLoggedUserToInventoryAsync()
    {
        string sessionStorageToken = await JSRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
        if (!string.IsNullOrEmpty(sessionStorageToken))
        {
            Navigation.NavigateTo("/inventory");
            Console.WriteLine("User already logged in, redirecting to inventory");
        }
    }

    // Funkce pro odhlášení (smazání tokenu)
    protected async Task LogoutCurrentUserAsync()
    {
        await JSRuntime.InvokeAsync<string>("sessionStorage.removeItem;", "token");
    }
}