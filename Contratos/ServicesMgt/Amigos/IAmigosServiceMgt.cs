using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Contratos
{
    [ServiceContract]
    public interface IAmigosServiceMgt
    {
        [OperationContract]
        List<string> ObtenerAmigosUsuario(int idJugador);
        
        [OperationContract]
        List<Tuple<string, string>> ObtenerEstadoAmigos(int idJugador);
        
        [OperationContract]
        List<string> ObtenerSolicitudesUsuario(int idJugador);
        
        [OperationContract]
        bool EnviarSolicitud(int idSolicita, int idRecibe);

        [OperationContract]
        bool ExisteSolicitudAmistad(int idSolicita, int idRecibe);

        [OperationContract]
        bool EliminarAmigo(int idSolicita, int idRecibe);

        [OperationContract]
        bool AceptarSolicitud(int idSolicita, int idRecibe);
    }
}
