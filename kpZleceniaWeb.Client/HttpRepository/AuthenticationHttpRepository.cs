using kpZleceniaWeb.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Authentication.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Client.AuthStateProviders;
using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Client.Models;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class AuthenticationHttpRepository : KpBaseHttpRepository, IAuthenticationHttpRepository
    {
        private readonly CookieStorageService _cookieStorageService;
        private readonly AuthenticationStateProvider _authStateProvider;
       
        public AuthenticationHttpRepository(
            HttpClient httpClient,
            CookieStorageService cookieStorageService,
            AuthenticationStateProvider authStateProvider
            ) : base(httpClient)
        {
            _cookieStorageService = cookieStorageService;
            _authStateProvider = authStateProvider;
        }

        public async Task<string> RefreshToken()
        {
            var token = await _cookieStorageService.GetValueAsync(GlobalStaticParameters.AuthTokenName);
            var refreshToken = await _cookieStorageService.GetValueAsync(GlobalStaticParameters.RefreshTokenName);

            var response = await _httpClient.PostAsJsonAsync("token/refresh",
                new RefreshTokenCommand
                {
                    Token = token,
                    RefreshToken = refreshToken
                });

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<LoginUserDto>(content, _options);

            if (!result.IsAuthSuccessful)
                return null;
                
            await _cookieStorageService.SetValueAsync(GlobalStaticParameters.AuthTokenName, result.Token);
            await _cookieStorageService.SetValueAsync(GlobalStaticParameters.RefreshTokenName, result.RefreshToken);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                ("bearer", result.Token);

            return result.Token;
        }

        public async Task<ResponseDto> RegisterUser(RegisterUserCommand registerUserCommand)
        {
            
            var response = await _httpClient.PostAsJsonAsync("account/register",
                registerUserCommand);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ResponseDto>(content, _options);

                return result;
            }

            return new ResponseDto { IsSuccess = true };
        }

        public async Task<LoginUserDto> Login(LoginUserCommand userForAuthentication)
        {
            var response = await _httpClient.PostAsJsonAsync("account/login",
                userForAuthentication);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<LoginUserDto>(content, _options);

            if (!response.IsSuccessStatusCode)
                return result;

            await _cookieStorageService.SetValueAsync(GlobalStaticParameters.AuthTokenName, result.Token);
            await _cookieStorageService.SetValueAsync(GlobalStaticParameters.RefreshTokenName, result.RefreshToken);

            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(
                result.Token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "bearer", result.Token);

            return new LoginUserDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _cookieStorageService.RemoveValueAsync(GlobalStaticParameters.AuthTokenName);
            await _cookieStorageService.RemoveValueAsync(GlobalStaticParameters.RefreshTokenName);

            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
