using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PokedexGambaApp.Shared;

public class Auth : ComponentBase
{
    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Inject] public NavigationManager Navigation { get; set; }
    [Inject] public HttpClient Http { get; set; }

    protected async Task EnsureUserIsAuthenticatedAsync(bool sentFromRegister = false)
    {
        string sessionStorageToken = await JSRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
        if (string.IsNullOrEmpty(sessionStorageToken))
        {
            Navigation.NavigateTo("/");
            Console.WriteLine("User is not logged in, redirecting to login");
        }
        else
        {
            await EnsureUserInfoIsRegisteredAsync(sessionStorageToken, sentFromRegister);
        }
    }

    private async Task EnsureUserInfoIsRegisteredAsync(string sessionStorageToken, bool sentFromRegister)
    {
        try
        {
            // Vytvoř požadavek
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/findUserInfo");
            // Nastavení hlaviček
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", sessionStorageToken);
            request.Headers.Add("X-Host", "user-info-api.pokedex-gamba.internal");

            // Poslání požadavku
            HttpResponseMessage response = await Http.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Navigation.NavigateTo("/Register");
            }
            else
            {
                if (sentFromRegister)
                {
                    Navigation.NavigateTo("/Inventory");
                }
                Console.WriteLine("User info is registered");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    protected async Task RedirectLoggedUserToInventoryAsync()
    {
        string sessionStorageToken = await JSRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
        if (!string.IsNullOrEmpty(sessionStorageToken))
        {
            Navigation.NavigateTo("/Inventory");
            Console.WriteLine("User already logged in, redirecting to inventory");
        }
    }

    // Funkce pro odhlášení (smazání tokenu)
    protected async Task LogoutCurrentUserAsync()
    {
        await JSRuntime.InvokeAsync<string>("sessionStorage.removeItem", "token");
        Navigation.NavigateTo("/");
        Console.WriteLine("User logged out");
    }
}