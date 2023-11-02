

using Blazored.SessionStorage;
using Dr.Abrishami_Ai.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Dr.Abrishami_Ai.Client.Extention
{
    public class AuthenticationExtention : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _WithoutInformation = new ClaimsPrincipal(new ClaimsIdentity());


        public AuthenticationExtention(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
            
        }

        public async Task UpdateAuthentication(SessionDTO? sessionAuth)
        {
            ClaimsPrincipal claimsPrincipal;
            if(sessionAuth != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sessionAuth.Nombre),
                    new Claim(ClaimTypes.Email,sessionAuth.Correo),
                    new Claim(ClaimTypes.Role,sessionAuth.Rol),


                }, "JwtAuth"));

                await _sessionStorage.SaveStorage("sessionAuth", sessionAuth);

            }
            else
            {
                claimsPrincipal = _WithoutInformation;
                await _sessionStorage.RemoveItemAsync("swssionAuth");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sessionAuth = await _sessionStorage.ObtainStorage<SessionDTO>("swssionAuth");

            if (sessionAuth == null)
            {
                return await Task.FromResult(new AuthenticationState(_WithoutInformation));
            }
                var claimPrincipal = new ClaimsPrincipal(new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sessionAuth.Nombre),
                    new Claim(ClaimTypes.Email,sessionAuth.Correo),
                    new Claim(ClaimTypes.Role,sessionAuth.Rol),


                }, "JwtAuth")));

                return await Task.FromResult(new AuthenticationState(claimPrincipal));
            
        }
    }
}
