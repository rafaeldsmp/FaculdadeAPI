using FaculdadeUD.Domain.Model;

namespace FaculdadeUD.InfraStructure.Repository.Interfaces
{
    public interface IDepartamentoRepository
    {
        Departamento[] GetAllDepartamentos();
        Departamento GetDepartamentoById(int DepartamentoId);
        public void Add<T>(T entity);
        public void Update<T>(T entity);
        public void Delete<T>(T entity);
        public bool SaveChanges();

    }
}
