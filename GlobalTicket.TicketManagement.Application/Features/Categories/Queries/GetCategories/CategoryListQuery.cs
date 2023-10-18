using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategories
{
	public class CategoryListQuery : IRequest<List<CategoryListVm>>
	{
	}
}
