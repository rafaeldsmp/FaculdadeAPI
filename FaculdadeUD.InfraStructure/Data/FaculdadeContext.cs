using Microsoft.EntityFrameworkCore;
using FaculdadeUD.Domain.Model;

namespace FaculdadeUD.InfraStructure.Data
{
    public class FaculdadeContext : DbContext
    {
        public FaculdadeContext(DbContextOptions<FaculdadeContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
