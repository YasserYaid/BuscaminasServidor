using System.ServiceModel;

namespace Contratos
{
    [ServiceContract]
    public interface ICuentaUsuarioServiceMgt
    {
        [OperationContract]
        string GenerarCodigo();

        [OperationContract]
        bool ComprobarCodigos(string codigoCorreo, string codigoRecibido);

        [OperationContract]
        bool EnviarCorreo(string correo, string asunto, string mensaje, string codigo);

        [OperationContract]
        bool VerificarRegistroCuenta(string nombreUsuario, string contrasenia, string correo, bool genero);

        [OperationContract]
        bool VerificarDisponibilidadCuenta(string usuario, string correo);

        [OperationContract]
        bool ValidarAuntentificacion(string nombreUsuario, string contrasenia);

        [OperationContract]
        bool ComprobarEstado(string nombreUsuario);

        [OperationContract]
        bool ActualizarEstado(string nombreUsuario, int estado);

        [OperationContract]
        int ObtenerIdJugador(string nombreUsuario);

        [OperationContract]
        string ObtenerCorreoJugador(string usuario);
        
        [OperationContract]
        string ObtenerNombreUsuario(int idJugador);

        [OperationContract]
        int ObtenerEstadoJugador(int idJugador);

        [OperationContract]
        bool VerificarExisteciaJugador(string nombreUsuario);
    }
}
