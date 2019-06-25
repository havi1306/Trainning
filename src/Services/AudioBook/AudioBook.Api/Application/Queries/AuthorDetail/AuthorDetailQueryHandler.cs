using AudioBook.Infrastructure.Repositories.Interfaces;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Queries.AuthorDetail
{
    public class AuthorDetailQueryHandler : IRequestHandler<AuthorDetailQuery, AuthorDetailDTO>
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorDetailQueryHandler(IAuthorRepository authorRepo)
        {
            this._authorRepo = authorRepo;
        }

        public async Task<AuthorDetailDTO> Handle(AuthorDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await this._authorRepo.GetAsync(request.Id);

            var model = data.Adapt<AuthorDetailDTO>();

            return model;
        }
    }
}