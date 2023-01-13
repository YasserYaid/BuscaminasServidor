using Logica;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Contratos
{
    public partial class BuscaminasServicio : IAmigosServiceMgt
    {
        public List<string> ObtenerAmigosUsuario(int idJugador)
        {
            try
            {
                return AmigosServiceMgtLogica.ObtenerListaAmigos(idJugador);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public List<Tuple<string, string>> ObtenerEstadoAmigos(int idJugador)
        {
            try
            {
                List<Tuple<string, string>> amigosJugador = new List<Tuple<string, string>>();
                AmigosServiceMgtLogica amigos = new AmigosServiceMgtLogica();

                amigosJugador = amigos.ObtenerEstadoListaAmigos(idJugador);
                return amigosJugador;
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public List<string> ObtenerSolicitudesUsuario(int idJugador)
        {
            try
            {
                return AmigosServiceMgtLogica.ObtenerListaSolicitudes(idJugador);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public bool EnviarSolicitud(int idSolicitante, int idReceptor)
        {
            bool esEnvioSolicitudSatisfactorio = false;
            try
            {
                AmigosServiceMgtLogica amigosServiceMgtLogica = new AmigosServiceMgtLogica();
                EstadoOperacion estadoOperacionEnvioSolicitud = amigosServiceMgtLogica.EnviarSolicitud(idSolicitante, idReceptor);

                if (estadoOperacionEnvioSolicitud == EstadoOperacion.EXITOSO)
                {
                    esEnvioSolicitudSatisfactorio = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esEnvioSolicitudSatisfactorio;
        }

        public bool ExisteSolicitudAmistad(int idSolicitante, int idReceptor)
        {
            bool esSolicitudExistente = false;
            try
            {
                AmigosServiceMgtLogica amigosServiceMgtLogica = new AmigosServiceMgtLogica();
                EstadoOperacion estadoConsutaExistenceiaSolicitud = amigosServiceMgtLogica.ExisteSolicitud(idSolicitante, idReceptor);

                if (estadoConsutaExistenceiaSolicitud == EstadoOperacion.EXITOSO)
                {
                    esSolicitudExistente = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esSolicitudExistente;
        }

        public bool EliminarAmigo(int idSolicitante, int idReceptor)
        {
            bool esEliminacionAmigoExitosa = false;
            try
            {
                AmigosServiceMgtLogica amigosServiceMgtLogica = new AmigosServiceMgtLogica();
                EstadoOperacion estadoOpercionEliminacion = amigosServiceMgtLogica.BorrarSolicitud(idSolicitante, idReceptor);

                if (estadoOpercionEliminacion == EstadoOperacion.EXITOSO)
                {
                    esEliminacionAmigoExitosa = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esEliminacionAmigoExitosa;
        }

        public bool AceptarSolicitud(int idSolicitante, int idReceptor)
        {
            bool esSolicitudAceptadaSatisfactoriamente = false;
            try
            {
                AmigosServiceMgtLogica amigosServiceMgtLogica = new AmigosServiceMgtLogica();
                EstadoOperacion estadoOperacionAceptar = amigosServiceMgtLogica.AceptarSolicitud(idSolicitante, idReceptor);

                if (estadoOperacionAceptar == EstadoOperacion.EXITOSO)
                {
                    esSolicitudAceptadaSatisfactoriamente = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esSolicitudAceptadaSatisfactoriamente;
        }
    }
}
