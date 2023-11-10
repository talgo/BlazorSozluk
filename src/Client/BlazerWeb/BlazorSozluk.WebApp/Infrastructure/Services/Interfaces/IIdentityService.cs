using BlazorSozluk.Common.Models.RequestModels;

namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IIdentityService
    {
        Guid GetUserId();
        Task<bool> Login(LoginUserCommand command);
        void Logout();
    }
}