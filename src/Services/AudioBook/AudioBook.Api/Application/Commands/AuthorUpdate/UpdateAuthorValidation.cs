using AudioBook.Api.Application.Commands.CategoryUpdate;
using AudioBook.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Commands.AuthorUpdate
{
    public class UpdateAuthorValidation : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IAuthorRepository _authorRepo;

        public UpdateAuthorValidation(IAuthorRepository authorRepo)
        {
            this._authorRepo = authorRepo;

            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Id).MustAsync((request, id, token) => CheckIdExist(id)).WithMessage("Data not exists");
        }

        private async Task<bool> CheckIdExist(int id)
        {
            var data = await this._authorRepo.GetAsync(id);

            return data != null;
        }
    }
}
