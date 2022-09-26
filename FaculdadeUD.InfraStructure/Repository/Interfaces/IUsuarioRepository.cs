using FaculdadeUD.Domain.Model;

namespace FaculdadeUD.InfraStructure.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario[] GetAllUsuarios();
        Usuario GetById(int UsuarioId);
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delelte<T>(T entity) where T : class;
        public bool SaveChanges();

    }
}
