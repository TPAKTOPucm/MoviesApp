using AutoMapper;
using MoviesApp.Models;
using MoviesApp.Services.Dto;

namespace MoviesApp.ViewModels.AutoMapperProfiles {
	public class ActorProfile : Profile
	{
		public ActorProfile()
		{ 
			CreateMap<ActorDto, ActorViewModel>().ReverseMap();
			CreateMap<InputActorViewModel, ActorDto>();
			CreateMap<ActorDto, EditActorViewModel>().ReverseMap();
			CreateMap<ActorDto, DeleteActorViewModel>();
		}
	}
}
