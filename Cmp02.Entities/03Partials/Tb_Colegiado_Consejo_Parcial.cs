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
    public partial class Tb_Colegiado_Consejo : Base
    {
        #region Peticiones

        public Tb_Colegiado_Consejo() { }

        public Tb_Colegiado_Consejo(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_CONSEJO")) Id_Consejo = Convert.ToInt32(Reader["ID_CONSEJO"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO_REGIONAL")) Id_Consejo_Regional = Convert.ToInt32(Reader["ID_CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "CONSEJO_NOMBRE")) Consejo_Nombre = Convert.ToString(Reader["CONSEJO_NOMBRE"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public string Consejo_Nombre { get; set; }

        #endregion
    }
}