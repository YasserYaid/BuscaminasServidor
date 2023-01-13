using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Contratos
{
    [DataContract]
    public class Sala
    {
        [DataMember]
        public string codigoSala { get; set; }
        [DataMember]
        public Dictionary<string, ISalaServiceCallback> JugadoresSalaCallback { get; set; }
        [DataMember]
        public Dictionary<string, IChatServiceCallback> JugadoresChatCallback { get; set; }
        [DataMember]
        public Dictionary<string, IJuegoServiceCallback> JugadoresJuegoCallback { get; set; }
    }
}
