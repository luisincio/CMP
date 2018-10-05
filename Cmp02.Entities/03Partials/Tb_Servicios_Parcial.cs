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
    public partial class Tb_Servicios: Base
    {
        #region Peticiones

        public Tb_Servicios () { }

        public Tb_Servicios (System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_SERVICIO")) Id_Servicio = Convert.ToInt32(Reader["ID_SERVICIO"]); 
		if (ReadCol.Exist(Reader, "CODIGO_SERVICIO")) Codigo_Servicio = Convert.ToString(Reader["CODIGO_SERVICIO"]); 
		if (ReadCol.Exist(Reader, "DESCRIPCION")) Descripcion = Convert.ToString(Reader["DESCRIPCION"]); 
		if (ReadCol.Exist(Reader, "PRECIO")) Precio = Convert.ToDecimal(Reader["PRECIO"]); 
		if (ReadCol.Exist(Reader, "DESCUENTO")) Descuento = Convert.ToDecimal(Reader["DESCUENTO"]); 
		if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]); 
		if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]); 
		if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]); 
		if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]); 
		if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]); 
		
        }

        #endregion

        #region Atributos Adicionales

        #endregion
    }
}