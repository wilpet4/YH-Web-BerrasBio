using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Xml;
using System.Collections.Generic;
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
        public DbSet<Receipt> Receipts { get; set; }
    }
}
