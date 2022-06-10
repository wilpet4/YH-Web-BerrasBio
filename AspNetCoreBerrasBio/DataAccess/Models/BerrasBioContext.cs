using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BerrasBioContext: DbContext
    {
        public BerrasBioContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<ScreeningRoom> screeningRooms { get; set; }
        public DbSet<Seat> seats { get; set; }
        public DbSet<Movie> movie { get; set; }
        public DbSet<Screening> screenings { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Director> directors { get; set; }
    }
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public ICollection<ScreeningRoom> ScreeningRooms { get; set; }
    }
    public class ScreeningRoom
    {
        public int ScreeningRoomId { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
    public class Seat
    {
        public int SeatId { get; set; }
        public int ScreeningRoomId { get; set; }
        public ScreeningRoom ScreeningRoom { get; set; }
    }
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }
        public int AgeRestriction { get; set; }
        public ICollection<Genre> Genres { get; set; } // ?
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
    public class Screening
    {
        public int ScreeningId { get; set; }
        public bool IsRecurring { get; set; }
        public int ScreeningRoomId { get; set; }
        public ScreeningRoom ScreeningRoom { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; } // ?
    }
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> DirectedMovies { get; set;}
    }
}
