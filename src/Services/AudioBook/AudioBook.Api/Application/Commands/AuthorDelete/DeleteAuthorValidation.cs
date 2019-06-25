using AudioBook.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Commands.AuthorDelete
{
    public class DeleteAuthorValidation : AbstractValidator<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepo;

        public DeleteAuthorValidation(IAuthorRepository authorRepo)
        {
            this._authorRepo = authorRepo;

            RuleFor(x => x.Id).MustAsync((request, id, token) => CheckIdExist(id)).WithMessage("Data not exists");
        }

        private async Task<bool> CheckIdExist(int id)
        {
            var data = await this._authorRepo.GetAsync(id);

            return data != null;
        }
    }
}