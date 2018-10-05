#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{

    public class OtraCobranza
    {
        #region Atributos Básicos

        [DataMember]
        public string IdRecibo { get; set; }
        [DataMember]
        public string IdLote { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public string IdMoneda { get; set; }
        [DataMember]
        public int Tipo { get; set; }
        [DataMember]
        public string IdChequera { get; set; }
        [DataMember]
        public string NumChequeTarjeta { get; set; }
        [DataMember]
        public string IdTarjetaCredito { get; set; }
        [DataMember]
        public string TipoPagoSunat { get; set; }
        [DataMember]
        public string Comentario { get; set; }
        [DataMember]
        public string NumeroFacturaVenta { get; set; }
        [DataMember]
        public decimal MontoAplicacion { get; set; }
        #endregion
    }

    
}
