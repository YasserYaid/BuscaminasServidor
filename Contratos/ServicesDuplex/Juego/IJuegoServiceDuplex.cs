using System.ServiceModel;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(IJuegoServiceCallback))]
    public interface IJuegoServiceDuplex
    {
        [OperationContract(IsOneWay = true)]
        void PasarTurno(string codigoSala, string nombreUsuarioClic, string turnoJugador);

        [OperationContract(IsOneWay = true)]
        void AgregarJugadorJuegoCallback(string codigoSala, string nombreUsuario);
        [OperationContract]
        void EnviarPorcentaje(string codigoSala, string nombreUsuario, int porcentajeJugador);
        [OperationContract]
        void DeclararJuegoTerminado(string codigoSala, string causa);
        [OperationContract]
        string ObtenerJugadorRival(string codigoSala, string nombreUsuario);
    }
}
