using AutoMapper;
using MoviesApp.Models;

namespace MoviesApp.ViewModels.AutoMapperProfiles {
	public class ActorProfile : Profile
	{
		public ActorProfile()
		{ 
			CreateMap<Actor, ActorViewModel>();
			CreateMap<InputActorViewModel, Actor>();
			CreateMap<Actor, EditActorViewModel>().ReverseMap();
			CreateMap<Actor, DeleteActorViewModel>();
		}
	}
}
