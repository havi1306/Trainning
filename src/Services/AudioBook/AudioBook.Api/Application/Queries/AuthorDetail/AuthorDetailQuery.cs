using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioBook.Api.Application.Queries.AuthorDetail
{
    public class AuthorDetailQuery : IRequest<AuthorDetailDTO>
    {
        public int Id { get; set; }
    }
}
