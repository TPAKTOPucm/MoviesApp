using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}