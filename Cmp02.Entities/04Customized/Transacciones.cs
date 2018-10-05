#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class Transacciones
    {
        #region Atributos Básicos

        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public int Tipodoc { get; set; }
        [DataMember]
        public string Nrocomp { get; set; }
        [DataMember]
        public string Idproveedor { get; set; }
        [DataMember]
        public string Iddocsunat { get; set; }
        [DataMember]
        public string Nrodocumento  { get; set; }
        [DataMember]
        public string Idimpuesto { get; set; }
        [DataMember]
        public string Codicion { get; set; }
        [DataMember]
        public decimal Montocompra { get; set; }
        [DataMember]
        public decimal Montimpuesto { get; set; }
        [DataMember]
        public decimal Montomiscelaneo { get; set; }
        [DataMember]
        public decimal Montoflete { get; set; }
        [DataMember]
        public decimal MontoDescuento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Ordencompra { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public decimal Tc { get; set; }
        [DataMember]
        public bool Afectaregcompra { get; set; }
        [DataMember]
        public bool Afectaretencion { get; set; }
        [DataMember]
        public int Iddetracccion { get; set; }
        [DataMember]
        public decimal Pordetraccion { get; set; }
        [DataMember]
        public decimal Montodetraccion { get; set; }
        [DataMember]
        public string Tipdocref { get; set; }
        [DataMember]
        public string Nrodocref { get; set; }
        [DataMember]
        public DateTime? Fechadocref { get; set; }
        [DataMember]
        public string IdConsejo { get; set; }
        [DataMember]
        public string IdConceptoGasto { get; set; }

        #endregion
    }
}
