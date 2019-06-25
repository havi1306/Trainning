using AudioBook.Infrastructure.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Commands.AuthorDelete
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IAuthorRepository _authorRepo;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepo)
        {
            this._authorRepo = authorRepo;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var data = await this._authorRepo.GetAsync(request.Id);

            if (data != null)
            {
                return await this._authorRepo.DeleteAsync(data);
            }

            return false;
        }
    }
}