using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CreateCategoryCommandHandler(IMapper _mapper, ICategoryRepository categoryRepository)
		{
			this._mapper = _mapper;
			this._categoryRepository = categoryRepository;
		}

		public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var createCategoryCommandResponse = new CreateCategoryCommandResponse();

			var validator = new CreateCategoryCommandValidator();
			var validationResult = await validator.ValidateAsync(request, cancellationToken);

			if (validationResult.Errors.Count > 0) 
			{
				createCategoryCommandResponse.Success = false;
				createCategoryCommandResponse.ValidationErrors = new List<string>(validationResult.Errors.Count);

				foreach (var error in validationResult.Errors)
				{
					createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
				}
			}

			if (createCategoryCommandResponse.Success)
			{
				var category = new Category() { Name = request.Name };
				category = await _categoryRepository.AddAsync(category);
				createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
			}

			return createCategoryCommandResponse;
		}
	}
}
