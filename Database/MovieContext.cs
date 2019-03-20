using System;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieCompany> MovieCompanies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=movies;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithOne(g => g.Movie).HasForeignKey(g => g.MovieId);
            modelBuilder.Entity<Movie>().HasMany(m => m.ProductionCompanies).WithOne(g => g.Movie).HasForeignKey(g => g.MovieId);
            modelBuilder.Entity<Genre>().HasMany(m => m.Movies).WithOne(g => g.Genre).HasForeignKey(g => g.GenreId);
            modelBuilder.Entity<Company>().HasMany(m => m.Movies).WithOne(g => g.Company).HasForeignKey(g => g.CompanyId);
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenre");
            modelBuilder.Entity<MovieCompany>().ToTable("MovieCompany");

        }
    }
}
