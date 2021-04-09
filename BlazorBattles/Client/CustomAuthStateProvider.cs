using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBattles.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localstorageService;

        public CustomAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localstorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _localstorageService.GetItemAsync<bool>("isAuthenticated"))
            {
           

            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, "Henriette")
                }, "test authentication type");



            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;


            }

            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
