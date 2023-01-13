using System.ServiceModel;

namespace Contratos
{
    [ServiceContract]
    public interface ISalaService
    {
        [OperationContract]
        Sala CrearNuevaSala();
        [OperationContract]
        Sala BuscarSala(string codigoSala);
    }
}
