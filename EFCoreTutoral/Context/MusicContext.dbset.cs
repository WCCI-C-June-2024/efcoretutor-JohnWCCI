using EFCoreTutoral.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutoral.Context
{
    public partial class MusicContext
    {
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<ArtistModel> Artists { get; set; }
        public DbSet<SongModel> Songs { get; set; }
    }
}
