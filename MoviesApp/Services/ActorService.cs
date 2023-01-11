﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Dto;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApp.Services
{
    public class ActorService : IActorService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;
        public ActorService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDto AddActor(ActorDto actorDto)
        {
            var actor = _context.Add(_mapper.Map<Actor>(actorDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<ActorDto>(actor);
        }

        public ActorDto DeleteActor(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
                return null;
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return _mapper.Map<ActorDto>(actor);
        }

        public ActorDto GetActor(int id)
        {
            return _mapper.Map<ActorDto>(_context.Actors.Find(id));
        }
        public ActorDto UpdateActor(ActorDto actorDto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorDto);
                _context.Update(actor);
                _context.SaveChanges();
                return _mapper.Map<ActorDto>(actor);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public IEnumerable<ActorDto> GetAllActors()
        {
            return _mapper.Map<ActorDto[]>(_context.Actors.ToArray());
        }
    }
}
