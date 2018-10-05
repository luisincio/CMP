/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase Parcial entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using Utildatatool;
using System.Runtime.Serialization;
#endregion

namespace Cmp02.Entities
{
    public partial class Tb_Comprobantedetalle : Base
    {
        #region Peticiones

        public Tb_Comprobantedetalle() { }

        public Tb_Comprobantedetalle(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_DETALLE")) Id_Detalle = Convert.ToInt32(Reader["ID_DETALLE"]);
            if (ReadCol.Exist(Reader, "ID_COMPROBANTE")) Id_Comprobante = Convert.ToInt32(Reader["ID_COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "ID_SERVICIO")) Id_Servicio = Convert.ToInt64(Reader["ID_SERVICIO"]);
            if (ReadCol.Exist(Reader, "CODIGO_SERVICIO")) Codigo_Servicio = Convert.ToString(Reader["CODIGO_SERVICIO"]);
            if (ReadCol.Exist(Reader, "DESCRIPCION")) Descripcion = Convert.ToString(Reader["DESCRIPCION"]);
            if (ReadCol.Exist(Reader, "CANTIDAD")) Cantidad = Convert.ToDecimal(Reader["CANTIDAD"]);
            if (ReadCol.Exist(Reader, "PRECIO")) Precio = Convert.ToDecimal(Reader["PRECIO"]);
            if (ReadCol.Exist(Reader, "DESCUENTO")) Descuento = Convert.ToDecimal(Reader["DESCUENTO"]);
            if (ReadCol.Exist(Reader, "MONTO")) Monto = Convert.ToDecimal(Reader["MONTO"]);
            if (ReadCol.Exist(Reader, "IGV")) Igv = Convert.ToDecimal(Reader["IGV"]);
            if (ReadCol.Exist(Reader, "SUBTOTAL")) Subtotal = Convert.ToDecimal(Reader["SUBTOTAL"]);

            if (ReadCol.Exist(Reader, "OPCIONAL")) FechaCuota = Convert.ToString(Reader["OPCIONAL"]);
        }

        #endregion

        #region Atributos Adicionales
        public string FechaCuota { get; set; }
        #endregion
    }
}