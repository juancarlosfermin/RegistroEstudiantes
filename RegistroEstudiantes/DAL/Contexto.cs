namespace RegistroEstudiantes.DAL;

using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EstudianteEntity> Estudiantes { get; set; }

    public DbSet<AsignaturaEntity> Asignaturas { get; set; }

    public DbSet<TiposPuntosEntity> TiposPuntos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EstudianteEntity>().ToTable("estudiantes");
        modelBuilder.Entity<AsignaturaEntity>().ToTable("asignaturas");
        modelBuilder.Entity<TiposPuntosEntity>().ToTable("TiposPuntos");
    }
}