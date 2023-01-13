using System.Collections;
using AutoMapper;
using EventsMan.Application.Features.Categories.Queries.GetCategoriesList;
using EventsMan.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using EventsMan.Application.Features.Events;
using EventsMan.Application.Features.Events.Commands;
using EventsMan.Application.Features.Events.Commands.CreateEvent;
using EventsMan.Application.Features.Events.Queries.GetEventDetail;
using EventsMan.Application.Features.Events.Queries.GetEventsList;
using EventsMan.Domain.Entities;

namespace EventsMan.Application.Profiles;

public class MappingProfile: Profile
{
   public MappingProfile()
   {
      CreateMap<Event, EventListVm>().ReverseMap();
      CreateMap<Event, EventDetailVm>().ReverseMap();
      CreateMap<Category, CategoryDto>();
      CreateMap<Category, CategoryListVm>();
      CreateMap<Category, CategoryEventListVm>();
      CreateMap<Event ,CreateEventCommand>().ReverseMap();
   } 
}