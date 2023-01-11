using MoviesApp.Services.Dto;
using System.Collections.Generic;

namespace MoviesApp.Services
{
    public interface IActorService
    {
        ActorDto GetActor(int id);
        IEnumerable<ActorDto> GetAllActors();
        ActorDto UpdateActor(ActorDto actor);
        ActorDto AddActor(ActorDto actor);
        ActorDto DeleteActor(int id);
    }
}
