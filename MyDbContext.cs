using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity_MySQL;

public partial class MyDbContext : DbContext
{
    public DbSet<Ator> Atores { get; set; }
    public DbSet<Filme> Filmes { get; set; }

    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user id=root;password=root;database=entitymysql", ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
