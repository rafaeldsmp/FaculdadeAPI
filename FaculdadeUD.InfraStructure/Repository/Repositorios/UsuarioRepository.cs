using FaculdadeUD.Domain.Model;
using FaculdadeUD.InfraStructure.Data;
using FaculdadeUD.InfraStructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FaculdadeUD.InfraStructure.Repository.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        FaculdadeContext _context;
        public UsuarioRepository(FaculdadeContext context)
        {
            _context = context;
        }

        public Usuario[] GetAllUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.AsNoTracking().OrderBy(u => u.Id);
            return query.ToArray();
        }

        public Usuario GetById(int UsuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios.Where(u => u.Id == UsuarioId);
            query = query.AsNoTracking().OrderBy(u => u.Id);
            return query.FirstOrDefault();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delelte<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
