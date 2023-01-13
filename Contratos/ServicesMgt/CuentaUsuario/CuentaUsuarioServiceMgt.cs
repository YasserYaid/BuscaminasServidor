using Logica;
using System.ServiceModel;

namespace Contratos
{
    public partial class BuscaminasServicio : ICuentaUsuarioServiceMgt
    {
        public bool ComprobarCodigos(string codigoCorreo, string codigoRecibido)
        {
            bool esMismoCodigo = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoComprobacionCodigo = cuentaServiceMgtLogica.ComprobarCodigos(codigoCorreo, codigoRecibido);
                if (estadoComprobacionCodigo == EstadoOperacion.EXITOSO)
                {
                    esMismoCodigo = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esMismoCodigo;
        }

        public bool EnviarCorreo(string correo, string asunto, string mensaje, string codigo)
        {
            bool esEnvioCorreoSatisfactorio = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoEnvioCorreo = cuentaServiceMgtLogica.EnviarCorreo(correo, asunto, mensaje, codigo);

                if (estadoEnvioCorreo == EstadoOperacion.EXITOSO)
                {
                    esEnvioCorreoSatisfactorio = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esEnvioCorreoSatisfactorio;
        }

        public string GenerarCodigo()
        {
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                string codigo = cuentaServiceMgtLogica.GenerarCodigo();
                return codigo;
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public bool VerificarDisponibilidadCuenta(string nombreUsuario, string correo)
        {
            bool esCuentaDisponible = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoDisponibilidad = cuentaServiceMgtLogica.ConsultarDisponibilidad(nombreUsuario, correo);

                if (estadoDisponibilidad == EstadoOperacion.EXITOSO)
                {
                    esCuentaDisponible = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esCuentaDisponible;
        }

        public bool VerificarRegistroCuenta(string nombreUsuario, string contrasenia, string correo, bool genero)
        {
            bool esRegistroCuentaSatisfactorio = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoRegistro = cuentaServiceMgtLogica.RegistrarUsuario(nombreUsuario, contrasenia, correo, genero);

                if (estadoRegistro == EstadoOperacion.EXITOSO)
                {
                    esRegistroCuentaSatisfactorio = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esRegistroCuentaSatisfactorio;
        }

        public bool ValidarAuntentificacion(string nombreUsuario, string contrasenia)
        {
            bool esAutentificacionValida = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoValidacion = cuentaServiceMgtLogica.ValidarCredenciales(nombreUsuario, contrasenia);

                if (estadoValidacion == EstadoOperacion.EXITOSO)
                {
                    esAutentificacionValida = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esAutentificacionValida;
        }

        public bool ComprobarEstado(string nombreUsuario)
        {
            bool esEstadoComprobacionSatisfactorio = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoOperacionEstadoJugador = cuentaServiceMgtLogica.VerificarEstadoJugador(nombreUsuario);

                if (estadoOperacionEstadoJugador == EstadoOperacion.EXITOSO)
                {
                    esEstadoComprobacionSatisfactorio = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esEstadoComprobacionSatisfactorio;
        }

        public bool ActualizarEstado(string nombreUsuario, int estado)
        {
            bool esActulizacionEstadoSatisfactoria = false;
            try
            {
                CuentaUsuarioServiceMgtLogica cuentaServiceMgtLogica = new CuentaUsuarioServiceMgtLogica();
                EstadoOperacion estadoOperacionActualizacionEstado = cuentaServiceMgtLogica.ActualizarEstado(nombreUsuario, estado);

                if (estadoOperacionActualizacionEstado == EstadoOperacion.EXITOSO)
                {
                    esActulizacionEstadoSatisfactoria = true;
                }
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
            return esActulizacionEstadoSatisfactoria;
        }

        public int ObtenerIdJugador(string nombreUsuario)
        {
            try
            {                
                return CuentaUsuarioServiceMgtLogica.ObtenerIdJugador(nombreUsuario); ;
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public string ObtenerCorreoJugador(string usuario)
        {
            try
            {
                return CuentaUsuarioServiceMgtLogica.ObtenerCorreoJugador(usuario);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public string ObtenerNombreUsuario(int idJugador)
        {
            try
            {
                return CuentaUsuarioServiceMgtLogica.ObtenerNombreUsuario(idJugador);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public int ObtenerEstadoJugador(int idJugador)
        {
            try
            {
                return CuentaUsuarioServiceMgtLogica.ObtenerEstadoJugador(idJugador);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }

        public bool VerificarExisteciaJugador(string nombreUsuario)
        {
            try
            {
                return CuentaUsuarioServiceMgtLogica.VerificarExistenciaJugador(nombreUsuario);
            }
            catch (CommunicationObjectFaultedException e)
            {
                throw new FaultException("Excepcion: " + e);
            }
        }
    }
}
