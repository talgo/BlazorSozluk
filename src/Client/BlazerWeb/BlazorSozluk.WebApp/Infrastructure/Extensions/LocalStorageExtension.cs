using Blazored.LocalStorage;

namespace BlazorSozluk.WebApp.Infrastructure.Extensions
{
    public static class LocalStorageExtension
    {
        public const string TokenName = "token";
        public const string UserName = "username";
        public const string UserId = "userId";

        public static bool IsUserLoggedIn(this ISyncLocalStorageService localStorageService)
        {
            return !string.IsNullOrEmpty(GetToken(localStorageService));
        }

        public static string GetUserName(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<string>(UserName);
        }

        public static async Task<string> GetUserName(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<string>(UserName);
        }

        public static void SetUserName(this ISyncLocalStorageService localStorageService,string value)
        {
            localStorageService.SetItem<string>(UserName,value);
        }

        public static async Task SetUserName(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync<string>(UserName, value);
        }

        public static Guid GetUserId(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<Guid>(UserId);
        }

        public static async Task<Guid> GetUserId(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<Guid>(UserId);
        }

        public static void SetUserId(this ISyncLocalStorageService localStorageService, Guid id)
        {
            localStorageService.SetItem<Guid>(UserId, id);
        }

        public static async Task SetUserId(this ILocalStorageService localStorageService, Guid id)
        {
            await localStorageService.SetItemAsync<Guid>(UserId, id);
        }

        public static string GetToken(this ISyncLocalStorageService localStorageService)
        {
            string token = localStorageService.GetItem<string>(TokenName);

            if (string.IsNullOrEmpty(token))
                token = "";

            return token;
        }

        public static async Task<string> GetToken(this ILocalStorageService localStorageService)
        {
            string token = await localStorageService.GetItemAsync<string>(TokenName);

            if (string.IsNullOrEmpty(token))
                token = "";

            return token;
        }

        public static void SetToken(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem<string>(TokenName, value);
        }

        public static async Task SetToken(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync<string>(TokenName, value);
        }
    }
}
