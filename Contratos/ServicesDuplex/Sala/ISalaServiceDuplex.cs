using System.ServiceModel;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(ISalaServiceCallback))]
    public interface ISalaServiceDuplex
    {
        [OperationContract(IsOneWay = true)]
        void AgregarJugadorComoPrimerJugador(string codigoSala, string nombreUsario);

        [OperationContract(IsOneWay = true)]
        void AgregarJugadorComoSegundoJugador(string codigoSala, string nombreUsuario);

        [OperationContract(IsOneWay = true)]
        void ColocarJugadoresEnElJuego(string codigoSala);
    }
}
