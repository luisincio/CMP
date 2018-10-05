#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
#endregion

namespace Cmp02.Entities
{
    public class Oc_Cabecera
    {
        #region Atributos Básicos

        [DataMember]
        public int Potype { get; set; }
        [DataMember]
        public string Ponumber { get; set; }
        [DataMember]
        public string Buyerid { get; set; }
        [DataMember]
        public string Userid { get; set; }
        [DataMember]
        public DateTime Docdate { get; set; }
        [DataMember]
        public string Vendorid { get; set; }
        [DataMember]
        public string Curncyid { get; set; }
        [DataMember]
        public string IdConsejo { get; set; }

        #endregion
    }

    public class Oc_Detalle
    {
        #region Atributos Básicos

        [DataMember]
        public int Potype { get; set; }
        [DataMember]
        public string Ponumber { get; set; }
        [DataMember]
        public DateTime Docdate { get; set; }
        [DataMember]
        public string Vendorid { get; set; }
        [DataMember]
        public string Locncode { get; set; }
        [DataMember]
        public int Linenumber { get; set; }
        [DataMember]
        public string Itemnmbr { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal Unitcost { get; set; }
        [DataMember]
        public string Uofm { get; set; }
        [DataMember]
        public string Curncyid { get; set; }
        [DataMember]
        public decimal Total { get; set; }

        #endregion
    }

    public class Oc_Transaccion
    {
        #region Atributos Básicos

        [DataMember]
        public string Ponumber { get; set; }
        [DataMember]
        public string Ord { get; set; }
        [DataMember]
        public string Itemnmbr { get; set; }
        [DataMember]
        public string Itemdesc { get; set; }
        [DataMember]
        public string Uofm { get; set; }
        [DataMember]
        public string Locncode { get; set; }
        [DataMember]
        public decimal Cantidadpedida { get; set; }
        [DataMember]
        public decimal Cantfacturada { get; set; }
        [DataMember]
        public decimal Cantenviada { get; set; }
        [DataMember]
        public decimal Costounitario { get; set; }
        [DataMember]
        public decimal Costototal { get; set; }
        [DataMember]
        public decimal Procentaje { get; set; }
        [DataMember]
        public string Impuestoarticulo { get; set; }
        [DataMember]
        public string Impuestoproveedor { get; set; }
        [DataMember]
        public string Idmoneda { get; set; }

        #endregion
    }

    public class OrdenCompra
    {
        public Oc_Cabecera Cabecera { get; set; }
        public List<Oc_Detalle> Detalle { get; set; }
    }
}
