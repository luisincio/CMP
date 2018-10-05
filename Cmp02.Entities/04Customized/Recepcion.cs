#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class Re_Cabecera
    {
        #region Atributos Básicos

        [DataMember]
        public int TipoRecepcion { get; set; }
        [DataMember]
        public string NroRecepcion { get; set; }
        [DataMember]
        public string TipoDocSunat { get; set; }
        [DataMember]
        public string NroDocumento { get; set; }
        [DataMember]
        public DateTime FechaRecepcion { get; set; }
        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public string IdProveedor { get; set; }
        [DataMember]
        public string NombreProveedor { get; set; }
        [DataMember]
        public string IdCondicion { get; set; }
        [DataMember]
        public string IdMoneda { get; set; }
        [DataMember]
        public decimal TipoCambio { get; set; }
        [DataMember]
        public bool NoafectaKArdex { get; set; }
        [DataMember]
        public bool NoafectaRegCompra { get; set; }
        [DataMember]
        public bool Retencion { get; set; }
        [DataMember]
        public string IdConsejo { get; set; }

        #endregion
    }

    public class Re_Detalle
    {
        #region Atributos Básicos

        [DataMember]
        public int TipoRecepcion { get; set; }
        [DataMember]
        public string NroRecepcion { get; set; }
        [DataMember]
        public string IdProveedor { get; set; }
        [DataMember]
        public string OrdenCompra { get; set; }
        [DataMember]
        public int LineaItemRecepcion { get; set; }
        [DataMember]
        public int LineaItemorden { get; set; }
        [DataMember]
        public string IdProducto { get; set; }
        [DataMember]
        public string DesCripcionItem { get; set; }
        [DataMember]
        public string UnidadMedida { get; set; }
        [DataMember]
        public string CodigoAlmacen { get; set; }
        [DataMember]
        public decimal CantidadEnvio { get; set; }
        [DataMember]
        public decimal CantidadFactura { get; set; }
        [DataMember]
        public decimal Costo { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public string IdMoneda { get; set; }

        #endregion
    }

    public class Recepcion
    {
        public Re_Cabecera Cabecera { get; set; }
        public List<Re_Detalle> Detalle { get; set; }

        public List<Oc_Transaccion> Orden { get; set; }
    }
}
