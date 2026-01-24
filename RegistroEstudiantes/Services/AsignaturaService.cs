using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.DAL;
using System.Linq.Expressions;


namespace RegistroEstudiantes.Services
{
    public class AsignaturaService
    {
        private readonly Contexto _contexto;

        public AsignaturaService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(AsignaturaEntity asignatura)
        {
            if (await Existe(a => a.Nombre.ToLower() == asignatura.Nombre.ToLower() && a.AsignaturaId != asignatura.AsignaturaId))
            {
                return false;
            }

            if (!await Existe(a => a.AsignaturaId == asignatura.AsignaturaId))
                return await Insertar(asignatura);
            else
                return await Modificar(asignatura);
        }

        private async Task<bool> Insertar(AsignaturaEntity asignatura)
        {
            _contexto.Asignaturas.Add(asignatura);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(AsignaturaEntity asignatura)
        {
            _contexto.Asignaturas.Update(asignatura);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int id)
        {
            return await _contexto.Asignaturas.AnyAsync(a => a.AsignaturaId == id);
        }

        public async Task<bool> Existe(Expression<Func<AsignaturaEntity, bool>> criterio)
        {
            return await _contexto.Asignaturas.AnyAsync(criterio);
        }

        public async Task<AsignaturaEntity?> Buscar(int id)
        {
            return await _contexto.Asignaturas
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AsignaturaId == id);
        }

        public async Task<List<AsignaturaEntity>> ObtenerTodos()
        {
            return await _contexto.Asignaturas
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contexto.Asignaturas
                .Where(a => a.AsignaturaId == id)
                .ExecuteDeleteAsync() > 0;
        }
    }
}