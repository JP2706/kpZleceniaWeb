using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace kpZleceniaWeb.Client.Services.Interfaces
{
    public class RefreshTokenService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAuthenticationHttpRepository _authenticationHttpRepository;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public RefreshTokenService(
            AuthenticationStateProvider authenticationStateProvider,
            IAuthenticationHttpRepository authenticationHttpRepository)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _authenticationHttpRepository = authenticationHttpRepository;
        }

        public async Task<string> TryRefreshToken()
        {
            try
            {
                await _semaphore.WaitAsync();

                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                var expClaim = user.FindFirst(c => c.Type.Equals("exp")).Value;

                var expTime = DateTimeOffset.FromUnixTimeSeconds(
                    Convert.ToInt64(expClaim));
                var diff = expTime - DateTime.UtcNow;

                if (diff.TotalMinutes <= 2)
                {
                    return await _authenticationHttpRepository.RefreshToken();
                }

                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
