using System.ComponentModel.DataAnnotations;

namespace Datos.BuscaminasModelos
{
    public partial class Jugador
    {
        [Key]
        public int idJugador { get; set; }
        public string nombreUsuario { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public bool genero { get; set; }
        public int estado { get; set; }
    }
}
