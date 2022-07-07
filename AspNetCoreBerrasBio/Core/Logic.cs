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
            for (int i = 0; i < sr.Capacity; i++)
            {
                sr.Seats.Add(new Seat());
            }
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
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0)
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 2).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 30, 0)
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 3).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 30, 0)
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 4).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 30, 0)
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 5).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 0)
            });
            db.Add(new Screening
            {
                ScreeningRoom = db.ScreeningRooms.First(),
                Movie = db.Movies.Where(x => x.MovieId == 6).First(),
                IsRecurring = true,
                Price = 129,
                DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 45, 0)
            });
            db.SaveChanges();
            #endregion
        }
        public List<Movie> GetAllMoviesWithRelationData()
        {
            var query = (from m in DbSingleton.Instance.Movies
                        select m).Include(g => g.Genres);

            return query.ToList();
        }
        public Screening GetScreeningByIndex(in int index)
        {
            return (Screening)DbSingleton.Instance.Screenings.Include(x => x.Movie).ToList().First();
        }
        public List<Screening> GetAllScreeningsWithRelationData()
        {
            var query = (from s in DbSingleton.Instance.Screenings
                         orderby s.DateTime ascending
                         select s).Include(s => s.ScreeningRoom) .Include(m => m.Movie).ThenInclude(g => g.Genres).Include(m => m.Movie).ThenInclude(d =>d.Director);
            if (query.Any() == false)
            {
                return new List<Screening>();
            }
            return query.ToList();
        }
        public List<Seat> GetAllAvailableSeatsFromRoom(in ScreeningRoom room)
        {
            int roomId = room.ScreeningRoomId;
            var query = (from s in DbSingleton.Instance.Seats
                         where s.ScreeningRoomId == roomId && s.IsOccupied == false
                         select s);
            return query.ToList();
        }
        public void PrintReceipt(in Screening screening, in Seat seat)
        {
            // ..\
            string cleanDate = DateTime.Now.ToString().Replace(':', '.');
            Receipt receipt = new Receipt { Screening = screening };
            string fileName = $"{cleanDate}.{screening.ScreeningId}.{receipt.ReceiptId}";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            if (Directory.Exists($@"{basePath}\Receipts") == false)
            {
                Directory.CreateDirectory($@"{basePath}\Receipts");
            }
            using (StreamWriter sw = File.CreateText($@"{basePath}\Receipts\{fileName}.txt"))
            {
                sw.WriteLine($"Movie: {screening.Movie.Name}, {screening.DateTime:f}");
                sw.WriteLine($"Room: {screening.ScreeningRoomId}");
                sw.WriteLine($"Date of Purchase: {cleanDate}");
                sw.WriteLine($"Identification: {fileName}");
            }
            seat.IsOccupied = true;
            DbSingleton.Instance.Receipts.Add(receipt);
            DbSingleton.Instance.SaveChanges();
        }
        public string ReceiptPath()
        {
            string basePath = $"{AppDomain.CurrentDomain.BaseDirectory}/Receipts";
            return basePath;
        }
        public void ResetSeatsForScreening(in Screening screening)
        {
            foreach (var seat in screening.ScreeningRoom.Seats)
            {
                seat.IsOccupied = false;
            }
            DbSingleton.Instance.SaveChanges();
        }
    }
}