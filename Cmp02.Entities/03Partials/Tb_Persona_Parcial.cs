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
    public partial class Tb_Persona : Base
    {
        #region Peticiones

        public Tb_Persona() { }

        public Tb_Persona(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_PERSONA")) Id_Tipo_Persona = Convert.ToString(Reader["ID_TIPO_PERSONA"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMERCIAL")) Nombre_Comercial = Convert.ToString(Reader["NOMBRE_COMERCIAL"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "RUC")) Ruc = Convert.ToString(Reader["RUC"]);
            if (ReadCol.Exist(Reader, "FLG_NACIONALIDAD")) Flg_Nacionalidad = Convert.ToString(Reader["FLG_NACIONALIDAD"]);
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