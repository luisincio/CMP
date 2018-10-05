#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class ClienteNJ
    {
        #region Atributos Básicos

        [DataMember]
        public int TipoPersona { get; set; }
        [DataMember]
        public string NroDocumento { get; set; }
        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string PrimerNombre { get; set; }
        [DataMember]
        public string SegundoNombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Distrito { get; set; }

        #endregion
    }

}
