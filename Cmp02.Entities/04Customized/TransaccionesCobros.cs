#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class TransaccionesCobros
    {
        #region Atributos Básicos
        
        [DataMember]
        public int TipodeDocumento { get; set; }
        [DataMember]
        public string NumerodeDocumento { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public DateTime FechaDocumento { get; set; }
        [DataMember]
        public DateTime FechaContabilizacion { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public string IdDireccion { get; set; }
        [DataMember]
        public string IdTerritorio { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public decimal TipodeCambio { get; set; }
        [DataMember]
        public string Condicion { get; set; }
        [DataMember]
        public string MetododeEnvio { get; set; }
        [DataMember]
        public string IdPlanImpuestos { get; set; }
        [DataMember]
        public string IdPlanImpuestosVentas { get; set; }
        [DataMember]
        public string IdPlanImpuestosFlete { get; set; }
        [DataMember]
        public string IdPlanImpuestosMiscelaneo { get; set; }
        [DataMember]
        public string NumOrdenCompra { get; set; }

        [DataMember]
        public decimal Costo { get; set; }
        [DataMember]
        public decimal Ventas { get; set; }
        [DataMember]
        public decimal DtoComercial { get; set; }
        [DataMember]
        public decimal Flete { get; set; }
        [DataMember]
        public decimal Miscelaneo { get; set; }
        [DataMember]
        public string CuentaContable { get; set; }
        [DataMember]
        public string TipoDocSunat { get; set; }
        
        #endregion
    }
}
