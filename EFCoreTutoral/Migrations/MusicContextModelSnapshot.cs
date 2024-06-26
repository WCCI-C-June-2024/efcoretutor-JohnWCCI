﻿// <auto-generated />
using EFCoreTutoral.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreTutoral.Migrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreTutoral.Models.ArtistModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Johnny",
                            LastName = "Cash"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jimmy",
                            LastName = "Buffet"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Home",
                            LastName = "Free"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Justin",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Def",
                            LastName = "Leppard"
                        });
                });

            modelBuilder.Entity("EFCoreTutoral.Models.GenreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Rock and Roll"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "R&B"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Country"
                        },
                        new
                        {
                            Id = 4,
                            GenreName = "Pop"
                        },
                        new
                        {
                            Id = 5,
                            GenreName = "Easy Listening"
                        },
                        new
                        {
                            Id = 6,
                            GenreName = "Blues"
                        });
                });

            modelBuilder.Entity("EFCoreTutoral.Models.SongModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("T_Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            GenreId = 1,
                            Title = "Your Heartless"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 1,
                            GenreId = 3,
                            Title = "Ride Bikes"
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 1,
                            GenreId = 3,
                            Title = "Your Heartless"
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 1,
                            GenreId = 3,
                            Title = "Wayfaring Stranger"
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 2,
                            GenreId = 2,
                            Title = "Son of a Sailor"
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 3,
                            GenreId = 3,
                            Title = "Sea Shanty"
                        },
                        new
                        {
                            Id = 7,
                            ArtistId = 2,
                            GenreId = 3,
                            Title = "Island"
                        },
                        new
                        {
                            Id = 8,
                            ArtistId = 3,
                            GenreId = 3,
                            Title = "Man of Constant Sorrow"
                        },
                        new
                        {
                            Id = 9,
                            ArtistId = 4,
                            GenreId = 6,
                            Title = "Laid-Back Delta Blues"
                        },
                        new
                        {
                            Id = 10,
                            ArtistId = 5,
                            GenreId = 1,
                            Title = "Pour Some Sugar on Me"
                        });
                });

            modelBuilder.Entity("EFCoreTutoral.Models.SongModel", b =>
                {
                    b.HasOne("EFCoreTutoral.Models.ArtistModel", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreTutoral.Models.GenreModel", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EFCoreTutoral.Models.ArtistModel", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
