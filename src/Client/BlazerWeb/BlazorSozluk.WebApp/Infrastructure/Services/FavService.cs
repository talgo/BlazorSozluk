using BlazorSozluk.Common.Models.RequestModels;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class FavService : IFavService
    {
        private readonly HttpClient client;

        public FavService(HttpClient client)
        {
            this.client = client;
        }

        public async Task CreateEntryFav(Guid entryId)
        {
            await client.PostAsync($"/api/Favorite/Entry/{entryId}", null);
        }

        public async Task CreateEntryCommentFav(Guid entryCommentId)
        {
            await client.PostAsync($"/api/Favorite/EntryComment/{entryCommentId}", null);
        }

        public async Task DeleteEntryFav(Guid entryId)
        {
            await client.PostAsync($"/api/Favorite/DeleteEntryFav/{entryId}", null);
        }

        public async Task DeleteEntryCommentFav(Guid entryCommentId)
        {
            await client.PostAsync($"/api/Favorite/DeleteEntryCommentFav/{entryCommentId}", null);
        }
    }
}
