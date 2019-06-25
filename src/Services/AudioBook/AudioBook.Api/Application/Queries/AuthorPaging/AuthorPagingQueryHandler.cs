using AudioBook.Core.Models;
using AudioBook.Infrastructure.Repositories.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Queries.AuthorPaging
{
    public class AuthorPagingQueryHandler : IRequestHandler<AuthorPagingQuery, PagedData<AuthorPagingDTO>>
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorPagingQueryHandler(IAuthorRepository authorRepo)
        {
            this._authorRepo = authorRepo;
        }

        public async Task<PagedData<AuthorPagingDTO>> Handle(AuthorPagingQuery request, CancellationToken cancellationToken)
        {
            var data = await this._authorRepo.GetAllPagingAsync(request.Page, request.Limit, request.Search);

            var dataDTO = data.Adapt<IEnumerable<AuthorPagingDTO>>();

            var total = await this._authorRepo.CountAllAsync(request.Search);

            var result = new PagedData<AuthorPagingDTO>(dataDTO, total);

            return result;
        }
    }
}