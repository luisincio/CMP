#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class Pagos_Manuales
    {
        #region Atributos Básicos

        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public string Nropago { get; set; }
        [DataMember]
        public string Idproveedor { get; set; }
        [DataMember]
        public string Nrodocumento  { get; set; }
        [DataMember]
        public DateTime Fechapago { get; set; }
        [DataMember]
        public int Formapago { get; set; }
        [DataMember]
        public string Tipopagosunat { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public string Chequera { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal Tipocambop { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public string IdConsejo { get; set; }
        #endregion
    }



}
