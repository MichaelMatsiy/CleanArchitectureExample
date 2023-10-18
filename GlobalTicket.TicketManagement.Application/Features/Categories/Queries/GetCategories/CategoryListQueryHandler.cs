using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategories
{
	public class CategoryListQueryHandler : IRequestHandler<CategoryListQuery, List<CategoryListVm>>
	{
		private readonly IAsyncRepository<Category> _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryListQueryHandler(IMapper mapper,
			IAsyncRepository<Category> categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryListVm>> Handle(CategoryListQuery request, 
			CancellationToken cancellationToken)
		{
			var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
			return _mapper.Map<List<CategoryListVm>>(allCategories);
		}
	}
}
