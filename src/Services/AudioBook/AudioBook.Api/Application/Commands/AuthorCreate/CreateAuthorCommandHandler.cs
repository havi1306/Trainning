using AudioBook.Api.Application.Commands.CategoryCreate;
using AudioBook.Core.Entities;
using AudioBook.Infrastructure.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Commands.AuthorCreate
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepo;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            this._authorRepo = authorRepository;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Author()
            {
                Name = request.Name,
                Description = request.Description,
                DateOfBirth = request.DateOfBirth,
                CreatedAt = DateTime.Now,
                CreatedBy = "Ha Vi"
            };

            return await this._authorRepo.InsertAsync(entity);
        }
    }
}
