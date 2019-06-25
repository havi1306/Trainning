using MediatR;

namespace AudioBook.Api.Application.Commands.CategoryUpdate
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}