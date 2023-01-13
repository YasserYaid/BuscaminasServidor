using System.ServiceModel;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatServiceDuplex
    {
        [OperationContract(IsOneWay = true)]
        void AgregarJugadorChatCallback(string codigoSala, string nombreUsuario);
        [OperationContract(IsOneWay = true)]
        void EnviarMensajeChat(string codigoSala, string nombreUsuario, string mensaje);
    }
}
