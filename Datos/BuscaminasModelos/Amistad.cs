using System.ComponentModel.DataAnnotations;

namespace Datos.BuscaminasModelos
{
    public partial class Amistad
    {
        [Key]
        public int idAmistad { get; set; }
        public int idJugadorSolicitante { get; set; }
        public int idJugadorReceptor { get; set; }
        public int estadoSolicitud { get; set; }
        public virtual Jugador Jugador1 { get; set; }
        public virtual Jugador Jugador2 { get; set; }
    }
}
