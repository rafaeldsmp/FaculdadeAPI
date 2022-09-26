using FaculdadeUD.Domain.Model;
using FaculdadeUD.InfraStructure.Data;
using FaculdadeUD.InfraStructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FaculdadeUD.InfraStructure.Repository.Repositorios
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        FaculdadeContext _context;
        public DepartamentoRepository(FaculdadeContext context)
        {
            _context = context;
        }
        public Departamento[] GetAllDepartamentos()
        {
            IQueryable<Departamento> query = _context.Departamentos;
            query = query.AsNoTracking().OrderBy(d => d.Id);
            return query.ToArray();
        }

        public Departamento GetDepartamentoById(int DepartamentoId)
        {
            IQueryable<Departamento> query = _context.Departamentos;
            query = query.AsNoTracking().OrderBy(d => d.Id).Where(departamento => departamento.Id == DepartamentoId);
            return query.FirstOrDefault();
        }

        public void Add<T>(T entity)
        {
          _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() > 0);
        }

    }
}
