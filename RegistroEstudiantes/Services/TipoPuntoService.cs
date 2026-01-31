using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.DAL;
using System.Linq.Expressions;

namespace RegistroEstudiantes.Services
{
    public class TipoPuntoService
    {
        private readonly Contexto _contexto;

        public TipoPuntoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(TiposPuntosEntity tipo)
        {
            if (await Existe(tipo.TipoId, tipo.Nombre))
            {
                return false;
            }

            if (tipo.TipoId == 0)
            {
                return await Insertar(tipo);
            }
            else
            {
                return await Modificar(tipo);
            }
        }

        private async Task<bool> Existe(int id, string nombre)
        {
            return await _contexto.TiposPuntos
                .AnyAsync(t => t.TipoId != id && t.Nombre.ToLower() == nombre.ToLower());
        }

        private async Task<bool> Insertar(TiposPuntosEntity tipo)
        {
            _contexto.TiposPuntos.Add(tipo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(TiposPuntosEntity tipo)
        {
            var local = _contexto.Set<TiposPuntosEntity>()
                .Local
                .FirstOrDefault(entry => entry.TipoId.Equals(tipo.TipoId));

            if (local != null)
            {
                _contexto.Entry(local).State = EntityState.Detached;
            }
            _contexto.Entry(tipo).State = EntityState.Modified;

            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipo = await _contexto.TiposPuntos
                .Where(t => t.TipoId == id)
                .ExecuteDeleteAsync();

            return tipo > 0;
        }

        public async Task<TiposPuntosEntity?> Buscar(int id)
        {
            return await _contexto.TiposPuntos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == id);
        }

        public async Task<List<TiposPuntosEntity>> ObtenerTodos()
        {
            return await _contexto.TiposPuntos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}