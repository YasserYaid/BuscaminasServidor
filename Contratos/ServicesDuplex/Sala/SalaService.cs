using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Contratos
{
    public partial class BuscaminasServicio : ISalaService, ISalaServiceDuplex
    {
        private Dictionary<string, Sala> inventarioSalas = new Dictionary<string, Sala>();
        public Sala CrearNuevaSala()
        {
            try
            {
                string codigoSala;
                do
                {
                    codigoSala = GenerarCodigoDeSala();
                } while (inventarioSalas.ContainsKey(codigoSala));

                Sala sala = new Sala();
                sala.codigoSala = codigoSala;
                sala.JugadoresSalaCallback = new Dictionary<string, ISalaServiceCallback>();
                sala.JugadoresChatCallback = new Dictionary<string, IChatServiceCallback>();
                sala.JugadoresJuegoCallback = new Dictionary<string, IJuegoServiceCallback>();
                inventarioSalas.Add(codigoSala, sala);
                return sala;
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }
        public Sala BuscarSala(string codigoSala)
        {
            try
            {
                Sala sala = null;
                inventarioSalas.TryGetValue(codigoSala, out sala);
                return sala;
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public void AgregarJugadorComoPrimerJugador(string codigoSala, string nombreUsario)
        {
            try
            {
                ISalaServiceCallback conexion = OperationContext.Current.GetCallbackChannel<ISalaServiceCallback>();
                inventarioSalas[codigoSala].JugadoresSalaCallback.Add(nombreUsario, conexion);
            }
            catch(KeyNotFoundException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public void AgregarJugadorComoSegundoJugador(string codigoSala, string nombreUsuario)
        {
            try
            {
                ISalaServiceCallback conexion = OperationContext.Current.GetCallbackChannel<ISalaServiceCallback>();
                inventarioSalas[codigoSala].JugadoresSalaCallback.Add(nombreUsuario, conexion);
                Dictionary<string, ISalaServiceCallback>.KeyCollection jugadores = inventarioSalas[codigoSala].JugadoresSalaCallback.Keys;
                string primero = jugadores.First();
                string ultimo = jugadores.Last();
                inventarioSalas[codigoSala].JugadoresSalaCallback[primero].ActualizarNombresUsuario(primero, ultimo);
                inventarioSalas[codigoSala].JugadoresSalaCallback[ultimo].ActualizarNombresUsuario(primero, ultimo);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public void ColocarJugadoresEnElJuego(string codigoSala)
        {
            try
            {
                Dictionary<string, ISalaServiceCallback>.KeyCollection jugadores = inventarioSalas[codigoSala].JugadoresSalaCallback.Keys;
                string primero = jugadores.First();
                string ultimo = jugadores.Last();
                inventarioSalas[codigoSala].JugadoresSalaCallback[primero].JugarMultigugador(codigoSala);
                inventarioSalas[codigoSala].JugadoresSalaCallback[ultimo].JugarMultigugador(codigoSala);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        private string GenerarCodigoDeSala()
        {
            try
            {
                string codigoGenerado;
                string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] arregloCaracteres = new char[4];
                Random random = new Random();

                for (int posicion = 0; posicion < arregloCaracteres.Length; posicion++)
                {
                    arregloCaracteres[posicion] = abecedario[random.Next(abecedario.Length)];
                }

                codigoGenerado = new String(arregloCaracteres);

                return codigoGenerado;
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }
    }
}
