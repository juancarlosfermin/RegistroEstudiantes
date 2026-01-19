namespace RegistroEstudiantes.Services;

using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.DAL;
using RegistroEstudiantes.Models;

public class EstudianteService
{
    private readonly Contexto _context;

    public EstudianteService(Contexto context)
    {
        _context = context;
    }

    public async Task<bool> Guardar(EstudianteEntity estudiante)
    {
        if (await _context.Estudiantes.AnyAsync(e => e.Nombres.ToLower() == estudiante.Nombres.ToLower()))
        {
            return false;
        }

        _context.Estudiantes.Add(estudiante);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(EstudianteEntity estudiante)
    {
        _context.Estudiantes.Update(estudiante);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var estudiante = await _context.Estudiantes.FindAsync(id);
        if (estudiante != null)
        {
            _context.Estudiantes.Remove(estudiante);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<EstudianteEntity?> Buscar(int id)
    {
        return await _context.Estudiantes.FindAsync(id);
    }

    public async Task<List<EstudianteEntity>> ObtenerTodos()
    {
        return await _context.Estudiantes.ToListAsync();
    }
}