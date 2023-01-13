using Datos.BuscaminasModelos;
using System.Data.Entity.Infrastructure;
using System;
using System.Linq;
using Datos.Contexto;
using System.Data.Entity.Core;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class AmigosServiceMgtLogica
    {

        public AmigosServiceMgtLogica()
        {
        }
        public static List<string> ObtenerListaAmigos(int idJugador)
        {
            List<string> listaAmigosJugador = new List<string>();
            try
            {
                using (var contextoBaseDatos = new BuscaminasModeloContexto())
                {
                    var amistades = from Amistad in contextoBaseDatos.Amistades
                                 where (Amistad.idJugadorSolicitante == idJugador && Amistad.estadoSolicitud == 1)
                                 || (Amistad.idJugadorReceptor == idJugador && Amistad.estadoSolicitud == 1)
                                 select Amistad;
                    foreach (var amistad in amistades)
                    {
                        if (idJugador != amistad.idJugadorSolicitante)
                        {
                            string nombreUsuario = CuentaUsuarioServiceMgtLogica.ObtenerNombreUsuario(amistad.idJugadorSolicitante);
                            listaAmigosJugador.Add(nombreUsuario);
                        }
                        else
                        {
                            string usuario = CuentaUsuarioServiceMgtLogica.ObtenerNombreUsuario(amistad.idJugadorReceptor);
                            listaAmigosJugador.Add(usuario);
                        }
                    }
                }
            }
            catch (EntitySqlException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            return listaAmigosJugador;
        }

        public List<Tuple<string, string>> ObtenerEstadoListaAmigos(int idJugador)
        {
            List<Tuple<string, string>> listaJugadores = new List<Tuple<string, string>>();

            try
            {
                using (var contexto = new BuscaminasModeloContexto())
                {
                    var amistades = from Amistad in contexto.Amistades
                                    where (Amistad.idJugadorSolicitante == idJugador && Amistad.estadoSolicitud == 1)
                                    || (Amistad.idJugadorReceptor == idJugador && Amistad.estadoSolicitud == 1)
                                    select Amistad;

                    foreach (var amistad in amistades)
                    {
                        if (idJugador != amistad.idJugadorSolicitante)
                        {
                            string usuario = CuentaUsuarioServiceMgtLogica.ObtenerNombreUsuario(amistad.idJugadorSolicitante);
                            string estado;
                            if (CuentaUsuarioServiceMgtLogica.ObtenerEstadoJugador(amistad.idJugadorSolicitante) == 1)
                            {
                                estado = "Baneado";
                            }
                            else
                            {
                                estado = "Normal";
                            }
                            listaJugadores.Add(new Tuple<string, string>(usuario, estado));
                        }
                        else
                        {
                            string usuario = CuentaUsuarioServiceMgtLogica.ObtenerNombreUsuario(amistad.idJugadorReceptor);
                            string estado;
                            if (CuentaUsuarioServiceMgtLogica.ObtenerEstadoJugador(amistad.idJugadorReceptor) == 1)
                            {
                                estado = "Baneado";
                            }
                            else
                            {
                                estado = "Normal";
                            }
                            listaJugadores.Add(new Tuple<string, string>(usuario, estado));
                        }
                    }
                }
            }
            catch (EntitySqlException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            return listaJugadores;
        }

        public static List<string> ObtenerListaSolicitudes(int idJugador)
        {

            List<string> listaSolicitudesJugador = new List<string>();
            try
            {
                using (var contextoBaseDatos = new BuscaminasModeloContexto())
                {
                    var amigos = from Amigo in contextoBaseDatos.Amistades
                                 where (Amigo.idJugadorReceptor == idJugador && Amigo.estadoSolicitud == 0)
                                 select Amigo;

                    foreach (var amigo in amigos)
                    {
                        if (idJugador != amigo.idJugadorSolicitante)
                        {
                            string usuario = CuentaUsuarioServiceMgtLogica.ObtenerNombreUsuario(amigo.idJugadorSolicitante);
                            listaSolicitudesJugador.Add(usuario);
                        }
                    }
                }
            }
            catch (EntitySqlException e)
            {
                Console.WriteLine("Excepcion: " + e);
            }
            return listaSolicitudesJugador;
        }

        public EstadoOperacion EnviarSolicitud(int idSolicitante, int idReceptor)
        {
            EstadoOperacion estadoOperacionSolicitud = EstadoOperacion.FALLIDO;
            try
            {
                using (var contextoBaseDatos = new BuscaminasModeloContexto())
                {
                    Amistad solicitudAmistad = new Amistad()
                    {
                        idJugadorSolicitante = idSolicitante,
                        idJugadorReceptor = idReceptor,
                        estadoSolicitud = 0
                    };

                    contextoBaseDatos.Amistades.Add(solicitudAmistad);
                    int entradas = contextoBaseDatos.SaveChanges();
                    contextoBaseDatos.SaveChanges();

                    if (entradas > 0)
                    {
                        estadoOperacionSolicitud = EstadoOperacion.EXITOSO;
                    }
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("Excepcion: " + e);
                estadoOperacionSolicitud = EstadoOperacion.FALLIDO;
            }
            return estadoOperacionSolicitud;
        }

        public EstadoOperacion BorrarSolicitud(int idSolicitante, int idReceptor)
        {
            EstadoOperacion estadoEliminacionSolicitud = EstadoOperacion.FALLIDO;
            try
            {
                using (var contextoBaseDatos = new BuscaminasModeloContexto())
                {
                    var amigos = (from Amistad in contextoBaseDatos.Amistades
                                  where (Amistad.idJugadorSolicitante == idSolicitante && Amistad.idJugadorReceptor == idReceptor)
                                  || (Amistad.idJugadorSolicitante == idReceptor && Amistad.idJugadorReceptor == idSolicitante)
                                  select Amistad);
                    if (amigos.Count() > 0)
                    {
                        contextoBaseDatos.Amistades.Remove(amigos.First());
                        contextoBaseDatos.SaveChanges();
                        estadoEliminacionSolicitud = EstadoOperacion.EXITOSO;
                    }
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("Excepcion: " + e);
                estadoEliminacionSolicitud = EstadoOperacion.FALLIDO;
            }
            return estadoEliminacionSolicitud;
        }

        public EstadoOperacion ExisteSolicitud(int idSolicitante, int idReceptor)
        {
            EstadoOperacion estadoOperacionConsultaExistencia = EstadoOperacion.FALLIDO;
            try
            {
                using (var contexto = new BuscaminasModeloContexto())
                {
                    var amigos = from Amigo in contexto.Amistades
                                 where (Amigo.idJugadorSolicitante == idSolicitante && Amigo.idJugadorReceptor == idReceptor)
                                 || (Amigo.idJugadorSolicitante == idReceptor && Amigo.idJugadorReceptor == idSolicitante)
                                 select Amigo;
                    if (amigos.Count() == 0)
                    {
                        estadoOperacionConsultaExistencia = EstadoOperacion.EXITOSO;
                    }
                }
            }
            catch (EntitySqlException e)
            {
                Console.WriteLine("Excepcion: " + e);
                estadoOperacionConsultaExistencia = EstadoOperacion.FALLIDO;
            }
            return estadoOperacionConsultaExistencia;
        }

        public EstadoOperacion AceptarSolicitud(int idSolicitante, int idReceptor)
        {
            EstadoOperacion estadoOperacionAceptacionSolicitud = EstadoOperacion.FALLIDO;
            try
            {
                using (var contexto = new BuscaminasModeloContexto())
                {
                    var amigos = from Amigo in contexto.Amistades
                                 where (Amigo.idJugadorSolicitante == idSolicitante && Amigo.idJugadorReceptor == idReceptor)
                                 select Amigo;
                    amigos.First().estadoSolicitud = 1;
                    int var = contexto.SaveChanges();
                    if (var > 0)
                    {
                        estadoOperacionAceptacionSolicitud = EstadoOperacion.EXITOSO;
                    }
                }
            }
            catch (EntitySqlException e)
            {
                Console.WriteLine("Excepcion: " + e);
                estadoOperacionAceptacionSolicitud = EstadoOperacion.FALLIDO;
            }
            return estadoOperacionAceptacionSolicitud;
        }
    }
}
