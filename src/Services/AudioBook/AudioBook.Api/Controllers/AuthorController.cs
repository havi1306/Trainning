using AudioBook.Api.Application.Commands.AuthorCreate;
using AudioBook.Api.Application.Commands.AuthorDelete;
using AudioBook.Api.Application.Commands.AuthorUpdate;
using AudioBook.Api.Application.Queries.AuthorDetail;
using AudioBook.Api.Application.Queries.AuthorPaging;
using AudioBook.Core.Constants;
using AudioBook.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AudioBook.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("authors/{id}")]
        public async Task<ActionResult<AuthorDetailDTO>> Get(int id)
        {
            var data = await this._mediator.Send(new AuthorDetailQuery() { Id = id });

            if (data == null)
            {
                return this.NoContent();
            }

            var result = new ApiResult<AuthorDetailDTO>()
            {
                Message = "Get success",
                Data = data
            };

            return this.Ok(result);
        }

        [HttpGet("authors")]
        public async Task<ActionResult<PagedData<AuthorPagingDTO>>> Gets([FromQuery] AuthorPagingQuery query)
        {
            if (query.Page <= 0)
            {
                return this.BadRequest();
            }

            var data = await this._mediator.Send(query);

            var result = new ApiResult<PagedData<AuthorPagingDTO>>()
            {
                Message = ApiMessage.GetOk,
                Data = data
            };

            return this.Ok(result);
        }

        [HttpPost("authors")]
        public async Task<IActionResult> Post([FromBody] CreateAuthorCommand request)
        {
            var id = await this._mediator.Send(request);

            var result = new ApiResult<int>()
            {
                Message = "Insert success",
                Data = id
            };

            return this.Created("api/authors", result);
        }

        [HttpPut("authors/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAuthorCommand request)
        {
            var data = await this._mediator.Send(request);

            var result = new ApiResult<bool>()
            {
                Message = ApiMessage.UpdateOk,
                Data = data
            };

            return Ok(result);
        }

        [HttpDelete("authors/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await this._mediator.Send(new DeleteAuthorCommand() { Id = id });

            var result = new ApiResult<bool>()
            {
                Message = "Delete Success",
                Data = data
            };

            return Ok(result);
        }
    }
}