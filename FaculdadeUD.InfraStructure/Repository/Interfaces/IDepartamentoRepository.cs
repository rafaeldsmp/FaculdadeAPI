using FaculdadeUD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
