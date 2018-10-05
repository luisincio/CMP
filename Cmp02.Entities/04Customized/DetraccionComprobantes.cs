/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Utildatatool;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public partial class DetraccionComprobantes
    {
        #region Atributos Básicos

        [DataMember]
        public int Id_Comprobante { get; set; }
        [DataMember]
        public int Id_Tipo_Documentosunat { get; set; }
        [DataMember]
        public string Tipo_Documentosunat { get; set; }
        [DataMember]
        public string Nro_Documento { get; set; }
        [DataMember]
        public int Id_Cliente { get; set; }
        [DataMember]
        public int Id_Moneda { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public decimal Detraccion { get; set; }

        #endregion

        public DetraccionComprobantes(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_COMPROBANTE")) Id_Comprobante = Convert.ToInt32(Reader["ID_COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_DOCUMENTOSUNAT")) Id_Tipo_Documentosunat = Convert.ToInt32(Reader["ID_TIPO_DOCUMENTOSUNAT"]);
            if (ReadCol.Exist(Reader, "TIPO_DOCUMENTOSUNAT")) Tipo_Documentosunat = Convert.ToString(Reader["TIPO_DOCUMENTOSUNAT"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "ID_MONEDA")) Id_Moneda = Convert.ToInt32(Reader["ID_MONEDA"]);
            if (ReadCol.Exist(Reader, "MONEDA")) Moneda = Convert.ToString(Reader["MONEDA"]);
            if (ReadCol.Exist(Reader, "FECHA")) Fecha = Convert.ToDateTime(Reader["FECHA"]);
            if (ReadCol.Exist(Reader, "TOTAL")) Total = Convert.ToDecimal(Reader["TOTAL"]);
            if (ReadCol.Exist(Reader, "DETRACCION")) Detraccion = Convert.ToDecimal(Reader["DETRACCION"]);
        }

        public DetraccionComprobantes() { }
    }
}