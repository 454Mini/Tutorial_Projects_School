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
           if()
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, "Henriette")
                }, "test authentication type");



            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
    }
}
