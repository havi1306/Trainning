using MediatR;
using System;

namespace AudioBook.Api.Application.Commands.AuthorUpdate
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}