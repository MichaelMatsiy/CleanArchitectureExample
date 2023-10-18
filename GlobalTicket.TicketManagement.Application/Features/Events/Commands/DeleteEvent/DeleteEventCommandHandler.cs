using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
	public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
	{
		private readonly IAsyncRepository<Event> _eventRepository;
		private readonly IMapper _mapper;

		public DeleteEventCommandHandler(IMapper _mapper, IAsyncRepository<Event> _eventRepository)
		{
			this._mapper = _mapper;
			this._eventRepository = _eventRepository;
		}

		public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
		{
			var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

			await _eventRepository.DeleteAsync(eventToDelete);

			return Unit.Value;
		}
	}
}
