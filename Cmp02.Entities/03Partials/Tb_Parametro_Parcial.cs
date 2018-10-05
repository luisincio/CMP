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
    public partial class Tb_Parametro : Base
    {
        #region Peticiones

        public Tb_Parametro() { }

        public Tb_Parametro(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PARAMETRO")) Id_Parametro = Convert.ToInt32(Reader["ID_PARAMETRO"]);
            if (ReadCol.Exist(Reader, "ID_SUCURSAL")) Id_Sucursal = Convert.ToInt32(Reader["ID_SUCURSAL"]);
            if (ReadCol.Exist(Reader, "DESCRIPCION")) Descripcion = Convert.ToString(Reader["DESCRIPCION"]);
            if (ReadCol.Exist(Reader, "VALOR_TEXTO")) Valor_Texto = Convert.ToString(Reader["VALOR_TEXTO"]);
            if (ReadCol.Exist(Reader, "VALOR_NUMERICO")) Valor_Numerico = Convert.ToDecimal(Reader["VALOR_NUMERICO"]);
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