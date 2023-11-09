﻿using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Infrastructure.Extensions;
using BlazorSozluk.Common.Models.Page;
using BlazorSozluk.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Queries.GetUserEntries
{
    public class GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQuery, PagedViewModel<GetUserEntriesDetailViewModel>>
    {
        private readonly IEntryRepository entryRepository;

        public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public async Task<PagedViewModel<GetUserEntriesDetailViewModel>> Handle(GetUserEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = entryRepository.AsQueryable();

            if (request.UserId != null && request.UserId.HasValue && request.UserId != Guid.Empty)
            {
                query = query.Where(i => i.CreatedById == request.UserId);
            }
            else if (!string.IsNullOrEmpty(request.UserName))
            {
                query = query.Where(i => i.CreatedBy.UserName == request.UserName);
            }
            else
                return null;

            query = query.Include(i => i.EntryFavorites).Include(i => i.CreatedBy);

            var list = query.Select(i => new GetUserEntriesDetailViewModel()
            {
                Id= i.Id,
                Content = i.Content,
                CreatedByUserName= request.UserName,
                CreatedDate = DateTime.Now,
                FavoritedCount = i.EntryFavorites.Count,
                IsFavorited = false,
                Subject = i.Subject
            });

            var entries = await list.GetPaged(request.Page, request.PageSize);

            return new PagedViewModel<GetUserEntriesDetailViewModel>(entries.Results, entries.PageInfo);
        }
    }
}
