#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class NotaCreditoDebitoCaja
    {
        #region Atributos Básicos
        
        [DataMember]
        public int TipodeDocumento { get; set; }
        [DataMember]
        public string NumerodeDocumento { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string IddeLote { get; set; }
        [DataMember]
        public DateTime FechaDocumento { get; set; }
        [DataMember]
        public DateTime FechaContabilizacion { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public string IddeMoneda { get; set; }
        [DataMember]
        public string NumOrdenCompra { get; set; }
        [DataMember]
        public decimal Ventas { get; set; }
        [DataMember]
        public decimal DtoComercial { get; set; }
        [DataMember]
        public decimal NumeroDocaAplicar { get; set; }
        [DataMember]
        public decimal MontoAplicacion { get; set; }
        
        #endregion
    }
}
