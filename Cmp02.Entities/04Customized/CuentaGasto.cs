using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cmp02.Entities
{
    public class CuentaGasto
    {
        #region Atributos Básicos

        [DataMember]
        public int Indice { get; set; }
        [DataMember]
        public string Cuenta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        
        #endregion
    }
}
