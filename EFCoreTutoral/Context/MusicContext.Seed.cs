using EFCoreTutoral.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutoral.Context
{
    public partial class MusicContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreModel>().HasData(
                               // new Genre { Id = -1, GenreName = "None" },
                               new GenreModel { Id = 1, GenreName = "Rock and Roll" },
                               new GenreModel { Id = 2, GenreName = "R&B" },
                               new GenreModel { Id = 3, GenreName = "Country" },
                               new GenreModel { Id = 4, GenreName = "Pop" },
                               new GenreModel { Id = 5, GenreName = "Easy Listening" },
                               new GenreModel { Id = 6, GenreName = "Blues" });

            modelBuilder.Entity<ArtistModel>().HasData(
                                 new ArtistModel { Id = 1, FirstName = "Johnny", LastName = "Cash" },
                                 new ArtistModel { Id = 2, FirstName = "Jimmy", LastName = "Buffet" },
                                 new ArtistModel { Id = 3, FirstName = "Home", LastName = "Free" },
                                 new ArtistModel { Id = 4, FirstName = "Justin", LastName = "Johnson" },
                                 new ArtistModel { Id = 5, FirstName = "Def", LastName = "Leppard" });

            modelBuilder.Entity<SongModel>().HasData(
                                new SongModel { Id = 1, GenreId = 1, Title = "Your Heartless", ArtistId = 1 },
                                new SongModel { Id = 2, GenreId = 3, Title = "Ride Bikes", ArtistId = 1 },
                                new SongModel { Id = 3, GenreId = 3, Title = "Your Heartless", ArtistId = 1 },
                                new SongModel { Id = 4, GenreId = 3, Title = "Wayfaring Stranger", ArtistId = 1 },
                                new SongModel { Id = 5, GenreId = 2, Title = "Son of a Sailor", ArtistId = 2 },
                                new SongModel { Id = 6, GenreId = 3, Title = "Sea Shanty", ArtistId = 3 },
                                new SongModel { Id = 7, GenreId = 3, Title = "Island", ArtistId = 2 },
                                new SongModel { Id = 8, GenreId = 3, Title = "Man of Constant Sorrow", ArtistId = 3 },
                                new SongModel { Id = 9, GenreId = 6, Title = "Laid-Back Delta Blues", ArtistId = 4 },
                                new SongModel { Id = 10, GenreId = 1, Title = "Pour Some Sugar on Me", ArtistId = 5 });
        }
    }
}
