namespace RegistroEstudiantes.DAL;

using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EstudianteEntity> Estudiantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstudianteEntity>().ToTable("estudiantes");
    }
}