using System.ServiceModel;

namespace Contratos
{
    [ServiceContract]
    public interface ISalaServiceCallback
    {
        [OperationContract]
        void ActualizarNombresUsuario(string nombreUsuarioJugador1, string nombreUsuarioJugador2);
        [OperationContract]
        void JugarMultigugador(string codigoSala);
    }
}
