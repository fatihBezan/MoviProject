﻿

using Microsoft.EntityFrameworkCore;
using MoviProject.Model.Entities;
using System.Reflection;

namespace MoviProject.DataAccess.Contexts;

public sealed class BaseDbContext:DbContext
{



    public BaseDbContext(DbContextOptions opt):base(opt)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"server=ASUS\SQLEXPRESS; Database=Movie_Project_db;Trusted_connection=true;TrustServerCertificate=True;");
    //}
    //@"server=ASUS\SQLEXPRESS; Database=LibraryManagement _db; Trusted_connection=true; TrustServerCertificate=True;"
    public DbSet<Artist> Artists { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Director> Directors { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<MovieArtist> MovieArtists { get; set; }

  
}
