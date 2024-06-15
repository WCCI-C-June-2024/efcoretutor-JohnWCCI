using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EFCoreTutoral.Context
{
    public partial class MusicContext : DbContext
    {
        private readonly IConfiguration configuration;

        public MusicContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? section = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(section))
            {
                throw new ApplicationException("DefaultConnection was not found.");
            }
            optionsBuilder.UseSqlServer(section);
        }
    }
}
