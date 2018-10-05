#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class CaEntradaTransaccion
    {
        #region Atributos Básicos

        [DataMember]
        public int EntradaDiario { get; set; }
        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public int TipoTransaccion { get; set; }
        [DataMember]
        public DateTime FechaTransaccion { get; set; }
        [DataMember]
        public string DocumentoOrigen { get; set; }
        [DataMember]
        public string Referencia { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public bool Intercompañia { get; set; }
        [DataMember]
        public string IdConsejo { get; set; }
        #endregion
    }

    public class DeEntradaTransaccion
    {
        #region Atributos Básicos

        [DataMember]
        public string IdCuenta { get; set; }
        [DataMember]
        public string Cuenta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal Debito { get; set; }
        [DataMember]
        public decimal Credito { get; set; }
        
        #endregion
    }

    public class EntradaTransaccion
    {
        #region Atributos Básicos
        public CaEntradaTransaccion Cabecera { get; set; }
        public List<DeEntradaTransaccion> Detalle { get; set; }
        #endregion
    }
}
