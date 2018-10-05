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
    public partial class Tb_Pais : Base
    {
        #region Peticiones

        public Tb_Pais() { }

        public Tb_Pais(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PAIS")) Id_Pais = Convert.ToInt32(Reader["ID_PAIS"]);
            if (ReadCol.Exist(Reader, "ISO2")) Iso2 = Convert.ToString(Reader["ISO2"]);
            if (ReadCol.Exist(Reader, "ISO3")) Iso3 = Convert.ToString(Reader["ISO3"]);
            if (ReadCol.Exist(Reader, "DESCRIPCION")) Descripcion = Convert.ToString(Reader["DESCRIPCION"]);
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