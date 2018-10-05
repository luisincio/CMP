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
    public partial class Tb_Maestras : Base
    {
        #region Peticiones

        public Tb_Maestras() { }

        public Tb_Maestras(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_MAESTRAS")) Id_Maestras = Convert.ToInt32(Reader["ID_MAESTRAS"]);
            if (ReadCol.Exist(Reader, "ID_GENERAL")) Id_General = Convert.ToInt32(Reader["ID_GENERAL"]);
            if (ReadCol.Exist(Reader, "ID_DETALLE")) Id_Detalle = Convert.ToInt32(Reader["ID_DETALLE"]);
            if (ReadCol.Exist(Reader, "DESCRIPCION")) Descripcion = (Convert.ToString(Reader["DESCRIPCION"]).Length > 100) ? Convert.ToString(Reader["DESCRIPCION"]).Substring(0, 100) : Convert.ToString(Reader["DESCRIPCION"]);
            if (ReadCol.Exist(Reader, "VALOR1")) Valor1 = Convert.ToString(Reader["VALOR1"]);
            if (ReadCol.Exist(Reader, "VALOR2")) Valor2 = Convert.ToString(Reader["VALOR2"]);
            if (ReadCol.Exist(Reader, "VALOR3")) Valor3 = Convert.ToString(Reader["VALOR3"]);
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