using AutoMapper;
using GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategories;
using GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GlobalTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GlobalTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail.Dto;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<Event, EventListVm>().ReverseMap();
			CreateMap<Event, EventDetailVm>().ReverseMap();
			CreateMap<Category, CategoryDto>();
			CreateMap<Category, CategoryListVm>();
			CreateMap<Category, CategoryEventListVm>();

			CreateMap<Event, CreateEventCommand>().ReverseMap();
			CreateMap<Event, UpdateEventCommand>().ReverseMap();
			CreateMap<Event, DeleteEventCommand>().ReverseMap();
		}
	}
}
