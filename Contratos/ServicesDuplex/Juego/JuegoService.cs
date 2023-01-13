using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Contratos
{
    public partial class BuscaminasServicio : IJuegoServiceDuplex
    {
        public void AgregarJugadorJuegoCallback(string codigoSala, string nombreUsuario)
        {
            try
            {
                IJuegoServiceCallback conexion = OperationContext.Current.GetCallbackChannel<IJuegoServiceCallback>();
                inventarioSalas[codigoSala].JugadoresJuegoCallback.Add(nombreUsuario, conexion);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }

        }

        public void DeclararJuegoTerminado(string codigoSala, string causa)
        {
            Dictionary<string, IJuegoServiceCallback>.KeyCollection jugadores = inventarioSalas[codigoSala].JugadoresJuegoCallback.Keys;
            string primerJugador = jugadores.First();
            string ultimoJugador = jugadores.Last();
            Console.WriteLine("llega al server");
            inventarioSalas[codigoSala].JugadoresJuegoCallback[primerJugador].RecibirFinalizacionDelJuego("llega al cliente");
            inventarioSalas[codigoSala].JugadoresJuegoCallback[ultimoJugador].RecibirFinalizacionDelJuego("llega al cliente");
        }

        public void EnviarPorcentaje(string codigoSala, string nombreUsuario, int porcentajeJugador)
        {
            Dictionary<string, IJuegoServiceCallback>.KeyCollection jugadores = inventarioSalas[codigoSala].JugadoresJuegoCallback.Keys;
            var primerJugador = jugadores.First();
            var ultimoJugador = jugadores.Last();
            if (primerJugador == nombreUsuario)
            {
                inventarioSalas[codigoSala].JugadoresJuegoCallback[ultimoJugador].RecibirPorcentages(porcentajeJugador);
            }
            else
            {
                inventarioSalas[codigoSala].JugadoresJuegoCallback[primerJugador].RecibirPorcentages(porcentajeJugador);
            }
        }

        public string ObtenerJugadorRival(string codigoSala, string nombreUsuario)
        {
            Dictionary<string, IJuegoServiceCallback>.KeyCollection jugadores = inventarioSalas[codigoSala].JugadoresJuegoCallback.Keys;
            string primerJugador = jugadores.First();
            string ultimoJugador = jugadores.Last();
            string jugadorObtenido = "";
            if (nombreUsuario.Equals(primerJugador))
            {
                jugadorObtenido = ultimoJugador;
            }
            else
            {
                jugadorObtenido = primerJugador;
            }
            return jugadorObtenido;
        }

        public void PasarTurno(string codigoSala, string nombreUsuarioClic, string turnoJugador)
        {
            try
            {
                Dictionary<string, IJuegoServiceCallback>.KeyCollection Jugadores = inventarioSalas[codigoSala].JugadoresJuegoCallback.Keys;
                string primero = Jugadores.First();
                string ultimo = Jugadores.Last();
                inventarioSalas[codigoSala].JugadoresJuegoCallback[primero].RecibirTurno(nombreUsuarioClic, "JUGADOR2");
                inventarioSalas[codigoSala].JugadoresJuegoCallback[ultimo].RecibirTurno(nombreUsuarioClic, "JUGADOR1");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }catch(TimeoutException e)
            {
                throw new TimeoutException("Excepcion: " + e);
            }
            catch (CommunicationException e)
            {
                throw new CommunicationException("Excepcion: " + e);
            }
        }
    }
}
