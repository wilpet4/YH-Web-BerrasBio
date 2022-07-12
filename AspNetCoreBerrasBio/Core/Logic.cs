using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class Logic
    {
        public void GenerateSampleData()
        {
            var db = DbSingleton.Instance;
            Cinema c = new Cinema { Name = "Berras Bio"};
            db.Add(c);
            ScreeningRoom sr = new ScreeningRoom { Capacity = 50, Cinema = c };
            db.Add(sr);
            #region Movies
            db.Add(new Movie
            {
                Name = "Top Gun: Maverick",
                Description = "After more than thirty years of service as one of the Navy's top aviators, Pete Mitchell is where he belongs, " +
                              "pushing the envelope as a courageous test pilot and dodging the advancement in rank that would ground him.",
                Runtime = 130,
                AgeRestriction = 11,
                Genres = new List<Genre>
                {
                    new Genre { GenreName = "Action" },
                    new Genre { GenreName = "Drama" }
                },
                Director = new Director { Name = "Joseph Kosinski" }
            });
            db.SaveChanges();
            db.Add(new Movie
            {
                Name = "Jurassic World Dominion",
                Description = "Four years after the destruction of Isla Nublar, dinosaurs now live--and hunt--alongside humans all over the world. " +
                              "This fragile balance will reshape the future and determine, once and for all, " +
                              "whether human beings are to remain the apex predators on a planet they now share with history's most fearsome creatures in a new Era.",
                Runtime = 146,
                AgeRestriction = 11,
                Genres = new List<Genre>
                {
                    db.Genres.Where(x => x.GenreName == "Action").First(),
                    new Genre { GenreName = "Adventure" },
                    new Genre { GenreName = "Sci-Fi"}
                },
                Director = new Director { Name = "Colin Trevorrow" }
            });
            db.SaveChanges();
            db.Add(new Movie
            {
                Name = "Fantastic Beasts: The Secrets of Dumbledore",
                Description = "Albus Dumbledore assigns Newt and his allies with a mission related to the rising power of Grindelwald.",
                Runtime = 142,
                AgeRestriction = 11,
                Genres = new List<Genre>
                {
                    db.Genres.Where(x => x.GenreName == "Action").First(),
                    db.Genres.Where(x => x.GenreName == "Adventure").First(),
                    new Genre { GenreName = "Fantasy" }
                },
                Director = new Director { Name = "David Yates" }
            });
            db.SaveChanges();
            db.Add(new Movie
            {
                Name = "Clifford the Big Red Dog",
                Description = "A young girl's love for a tiny puppy named Clifford makes the dog grow to an enormous size.",
                Runtime = 96,
                AgeRestriction = 0,
                Genres = new List<Genre>
                {
                    db.Genres.Where(x => x.GenreName == "Adventure").First(),
                    new Genre { GenreName = "Family" },
                    new Genre { GenreName = "Comedy" },
                },
                Director = new Director { Name = "Walt Becker" }
            });
            db.SaveChanges();
            db.Add(new Movie
            {
                Name = "Belfast",
                Description = "A young boy and his working-class Belfast family experience the tumultuous late 1960s.",
                Runtime = 98,
                AgeRestriction = 11,
                Genres = new List<Genre>
                {
                    new Genre { GenreName = "Drama" }
                },
                Director = new Director { Name = "Kenneth Branagh" }
            });
            db.SaveChanges();
            db.Add(new Movie
            {
                Name = "Men",
                Description = "A young woman goes on a solo vacation to the English countryside following the death of her ex-husband.",
                Runtime = 100,
                AgeRestriction = 15,
                Genres = new List<Genre>
                {
                    db.Genres.Where(x => x.GenreName == "Drama").First(),
                    new Genre { GenreName = "Horror" }
                },
                Director = new Director { Name = "Alex Garland" }
            });
            db.SaveChanges();
            #endregion
            #region Screenings
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 1).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0),
                Capacity = sr.Capacity
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 2).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 30, 0),
                Capacity = sr.Capacity
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 3).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 0),
                Capacity = sr.Capacity
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 4).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 30, 0),
                Capacity = sr.Capacity
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 5).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 0),
                Capacity = sr.Capacity
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 6).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 45, 0),
                Capacity = sr.Capacity
            });
            db.SaveChanges();
            #endregion
            foreach (Screening sc in db.Screenings)
            {
                for (int i = 0; i < sc.Capacity; i++)
                {
                    sc.Seats.Add(new Seat());
                }
            }
            db.SaveChanges();
        }
        public void SetScreeningDates() // Gör så att alla Screenings med IsRecurring uppdateras
        {                               // så man alltid bokar biljetten till nästa dag.
            var db = DbSingleton.Instance;
            var recurringScreenings = db.Screenings.Where(s => s.IsRecurring == true).ToList();
            foreach (Screening screening in recurringScreenings)
            {
                if (screening.DateTime.Day == DateTime.Now.AddDays(1).Day) return;
                var oldDate = screening.DateTime;
                var newDate = new DateTime(
                    DateTime.Now.Year, 
                    DateTime.Now.Month, 
                    DateTime.Now.AddDays(1).Day,
                    oldDate.Hour,
                    oldDate.Minute,
                    oldDate.Second);

                screening.DateTime = newDate;
                db.Update(screening);
            }
            db.SaveChanges();
        }
        public List<Movie> GetAllMoviesWithRelationData()
        {
            var query = (from m in DbSingleton.Instance.Movies
                        select m).Include(g => g.Genres);

            return query.ToList();
        }
        public Screening GetScreeningByIndex(in int index)
        {
            int id = index;
            return (Screening)DbSingleton.Instance.Screenings.Include(x => x.Movie).Where(s => s.ScreeningId == id).First();
        }
        public List<Screening> GetAllScreeningsWithRelationData()
        {
            var query = (from s in DbSingleton.Instance.Screenings
                         orderby s.DateTime ascending
                         select s).Include(s => s.Seats).Include(s => s.ScreeningRoom).Include(m => m.Movie).ThenInclude(g => g.Genres).Include(m => m.Movie).ThenInclude(d =>d.Director);
            if (query.Any() == false)
            {
                return new List<Screening>();
            }
            return query.ToList();
        }
        public List<Seat> GetAllAvailableSeatsFromScreening(in Screening screening)
        {
            int screeningId = screening.ScreeningId;
            var query = (from s in DbSingleton.Instance.Seats
                         where s.ScreeningId == screeningId && s.IsOccupied == false
                         select s);
            return query.ToList();
        }
        public void PrintReceipt(in Screening screening, in Seat seat, int seatNr)
        {
            // ..\
            string cleanDate = DateTime.Now.ToString().Replace(':', '.'); // Eftersom man inte får använda ':' i filnamn.
            Receipt receipt = new Receipt { Screening = screening, SeatNr = seatNr };
            string fileName = $"{cleanDate}.{screening.ScreeningId}.{receipt.ReceiptId}";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            if (Directory.Exists($@"{basePath}\Receipts") == false)
            {
                Directory.CreateDirectory($@"{basePath}\Receipts");
            }
            using (StreamWriter sw = File.CreateText($@"{basePath}\Receipts\{fileName}.txt"))
            {
                sw.WriteLine($"Movie: {screening.Movie.Name}");
                sw.WriteLine($"Date: {screening.DateTime}");
                sw.WriteLine($"Room: {screening.ScreeningRoomId}");
                sw.WriteLine($"Seat: {seatNr}");
                sw.WriteLine($"Price: {screening.Price}kr");
                sw.WriteLine($"Date of Purchase: {cleanDate}");
            }
            seat.IsOccupied = true;
            DbSingleton.Instance.Receipts.Add(receipt);
            DbSingleton.Instance.SaveChanges();
        }
        public string ReceiptPath()
        {
            string basePath = $"{AppDomain.CurrentDomain.BaseDirectory}Receipts";
            return basePath;
        }
        public void ResetSeatsForScreening(in Screening screening)
        {
            foreach (var seat in screening.Seats)
            {
                seat.IsOccupied = false;
            }
            DbSingleton.Instance.SaveChanges();
        }
    }
}