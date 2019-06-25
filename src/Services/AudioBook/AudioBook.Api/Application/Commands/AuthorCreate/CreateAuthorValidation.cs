using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Commands.AuthorCreate
{
    public class CreateAuthorValidation : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
