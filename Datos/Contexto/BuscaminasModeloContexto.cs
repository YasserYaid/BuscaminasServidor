using Datos.BuscaminasModelos;
using System.Data.Entity;

namespace Datos.Contexto
{
    public partial class BuscaminasModeloContexto : DbContext
    {
        public BuscaminasModeloContexto() : base("name=Buscaminas")
        {
            Database.SetInitializer<BuscaminasModeloContexto>(new DropCreateDatabaseIfModelChanges<BuscaminasModeloContexto>());
        }
        public virtual DbSet<Jugador> Jugadores { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Amistad> Amistades { get; set; }
    }
}
