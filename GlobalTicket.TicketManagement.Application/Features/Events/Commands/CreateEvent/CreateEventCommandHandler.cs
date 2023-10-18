using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
	public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
	{
		private readonly IEventRepository _eventRepository;
		private readonly IMapper _mapper;

        public CreateEventCommandHandler(IMapper _mapper, IEventRepository _eventRepository)
        {
			this._mapper = _mapper;
			this._eventRepository = _eventRepository;
        }

        public async Task<Guid> Handle(CreateEventCommand request, 
			CancellationToken cancellationToken)
		{
			var @event = _mapper.Map<Event>(request);

			var validator = new CreateEventCommandValidator(_eventRepository);
			var validationResult = await validator.ValidateAsync(request, cancellationToken);
			if (validationResult.Errors.Count > 0)
				throw new Exceptions.ValidationException(validationResult);

			@event = await _eventRepository.AddAsync(@event);

			return @event.EventId;
		}
	}
}
