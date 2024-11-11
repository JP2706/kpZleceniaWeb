namespace kpZleceniaWeb.Client.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Task<string> GetUserId();
    }
}
