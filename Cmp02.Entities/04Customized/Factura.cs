#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class Co_Cabecera
    {
        #region Atributos Básicos

        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public string IdDocumento { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public string IdCondicionPago { get; set; }
        [DataMember]
        public DateTime FechaEmision { get; set; }
        [DataMember]
        public DateTime FechaEnvio { get; set; }
        [DataMember]
        public string IdSitio { get; set; }
        [DataMember]
        public string IdMoneda { get; set; }
        [DataMember]
        public string IdVendedor { get; set; }
        [DataMember]
        public string IdTerritorio { get; set; }
        [DataMember]
        public string NumOCCliente { get; set; }
        [DataMember]
        public string NroGuia { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string IdLote { get; set; }
        [DataMember]
        public string Reference { get; set; }

        #endregion
    }

    public class Co_Detalle
    {
        #region Atributos Básicos

        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string IdSitio { get; set; }
        [DataMember]
        public int Secuencia { get; set; }
        [DataMember]
        public string NumArticulo { get; set; }
        [DataMember]
        public decimal PrecioUnitario { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public string DesArticulo { get; set; }
        [DataMember]
        public string UnidadMedida { get; set; }
        [DataMember]
        public string NumeroTelefono { get; set; }
        [DataMember]
        public string SerLotProducto { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public decimal Descuento { get; set; }

        #endregion
    }

    public class Co_Cobros
    {
        #region Atributos Básicos

        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public string IdDocumento { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string IdSitio { get; set; }
        [DataMember]
        public string TipoPAgo { get; set; }
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public DateTime FechaEmision { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public string NroOperacion { get; set; }
        [DataMember]
        public string Chequera { get; set; }

        #endregion
    }

    public class Factura
    {
        public Co_Cabecera Cabecera { get; set; }
        public List<Co_Detalle> Detalle { get; set; }
        public Co_Cobros Cobranza { get; set; }
    }
}
