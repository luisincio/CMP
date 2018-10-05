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
    public partial class Tb_Colegiado_Estado : Base
    {
        #region Peticiones

        public Tb_Colegiado_Estado() { }

        public Tb_Colegiado_Estado(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_ESTADO")) Id_Estado = Convert.ToInt32(Reader["ID_ESTADO"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO_COLEGIADO")) Id_Estado_Colegiado = Convert.ToInt32(Reader["ID_ESTADO_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "OBSERVACION")) ObservacionEstado = Convert.ToString(Reader["OBSERVACION"]);
            if (ReadCol.Exist(Reader, "FEC_INICIO")) Fec_Inicio = Convert.ToDateTime(Reader["FEC_INICIO"]);
            if (ReadCol.Exist(Reader, "FEC_FIN")) Fec_Fin = Convert.ToDateTime(Reader["FEC_FIN"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "ESTADO_NOMBRE")) Estado_Nombre = Convert.ToString(Reader["ESTADO_NOMBRE"]);
            if (ReadCol.Exist(Reader, "FEC_FALLECIO")) Fec_Fallecio = Convert.ToDateTime(Reader["FEC_FALLECIO"]);
        }

        #endregion

        #region Atributos Adicionales

        public string Estado_Nombre { get; set; }

        public DateTime? Fec_Fallecio { get; set; }
        #endregion
    }
}