using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel;

namespace DataAccess.Models
{
    public class BerrasBioContext: DbContext
    {
        public BerrasBioContext()
        {

        }
        public BerrasBioContext(DbContextOptions<BerrasBioContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);

            //string connectionString =
            //builder.Build().GetConnectionString("DefaultConnection"); // Returnerar null för nån jävla anledning.

            if (optionsBuilder.IsConfigured == false)
            {
                //optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BerrasBio_WilliamPetrik;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<ScreeningRoom> ScreeningRooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
    public class Cinema
    {
        public Cinema()
        {
            ScreeningRooms = new List<ScreeningRoom>();
        }
        public int CinemaId { get; set; }
        [MaxLength(70)] public string Name { get; set; }
        public ICollection<ScreeningRoom> ScreeningRooms { get; set; }
    }
    public class ScreeningRoom
    {
        public ScreeningRoom()
        {
            Seats = new List<Seat>();
        }
        public int ScreeningRoomId { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
        [Required] public Cinema Cinema { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
    public class Seat
    {
        public int SeatId { get; set; }
        public int ScreeningRoomId { get; set; }
        [Required] public ScreeningRoom ScreeningRoom { get; set; }
    }
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genre>();
        }
        public int MovieId { get; set; }
        [Required, MaxLength(70)] public string Name { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }
        public int AgeRestriction { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public int DirectorId { get; set; }
        [Required] public Director Director { get; set; }
    }
    public class Screening
    {
        public int ScreeningId { get; set; }
        public bool IsRecurring { get; set; }
        public int ScreeningRoomId { get; set; }
        [Required] public ScreeningRoom ScreeningRoom { get; set; }
        public int MovieId { get; set; }
        [Required] public Movie Movie { get; set; }
        [DefaultValue(129.99f)] public float Price { get; set; }
    }
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
    public class Director
    {
        public Director()
        {
            DirectedMovies = new List<Movie>();
        }
        public int DirectorId { get; set; }
        [Required, MaxLength(70)] public string Name { get; set; }
        public ICollection<Movie> DirectedMovies { get; set;}
    }
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int SeatId { get; set; }
        [Required] public Seat Seat { get; set; }
        public int ScreeningId { get; set; }
        [Required] public Screening Screening { get; set; }
    }
}
