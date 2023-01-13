using System.ServiceModel;

namespace Contratos
{
    [ServiceContract]
    public interface IChatServiceCallback
    {
        [OperationContract]
        void RecibirMensaje(string nombreUsuarioEmisor, string mensaje);
    }
}
