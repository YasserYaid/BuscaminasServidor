using System.ServiceModel;

namespace Contratos
{
    [ServiceContract]
    public interface IJuegoServiceCallback
    {        
        [OperationContract]
        void RecibirTurno(string nombreUsuarioAnterior, string turnoJugador);
        [OperationContract]
        void RecibirPorcentages(int percentage);
        [OperationContract]
        void RecibirFinalizacionDelJuego(string cause);
    }
}
