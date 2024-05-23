using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Shared_Library.GenericsModel;
using System.Security.Claims;
namespace Shared_Library.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        private ClaimsPrincipal anonymous = new(new ClaimsIdentity());
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                string stringToken = await _localStorageService.GetItemAsStringAsync("token");

                if (string.IsNullOrWhiteSpace(stringToken))
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var claims = Generics.GetClaimsFromToken(stringToken);

                var claimsPrincipal = Generics.SetClaimPrincipal(claims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async Task UpdateAuthenticationState(string? token)
        {
            ClaimsPrincipal claimsPrincipal = new();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var userSession = Generics.GetClaimsFromToken(token);
                claimsPrincipal = Generics.SetClaimPrincipal(userSession);
                await _localStorageService.SetItemAsStringAsync("token", token);
            }
            else
            {
                claimsPrincipal = anonymous;
                await _localStorageService.RemoveItemAsync("token");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
