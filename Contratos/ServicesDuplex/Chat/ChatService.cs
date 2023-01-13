using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Contratos
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public partial class BuscaminasServicio : IChatServiceDuplex
    {
        public void AgregarJugadorChatCallback(string codigoSala, string nombreUsuario)
        {
            try
            {
                IChatServiceCallback conexion = OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();
                inventarioSalas[codigoSala].JugadoresChatCallback.Add(nombreUsuario, conexion);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public void EnviarMensajeChat(string codigoSala, string nombreUsuario, string mensaje)
        {
            try 
            {
                Dictionary<string, IChatServiceCallback>.KeyCollection Jugadores = inventarioSalas[codigoSala].JugadoresChatCallback.Keys;
                string primero = Jugadores.First();
                string ultimo = Jugadores.Last();
                inventarioSalas[codigoSala].JugadoresChatCallback[primero].RecibirMensaje(nombreUsuario, mensaje);
                inventarioSalas[codigoSala].JugadoresChatCallback[ultimo].RecibirMensaje(nombreUsuario, mensaje);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }
    }
}
