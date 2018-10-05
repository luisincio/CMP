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
    public partial class Tb_Colegiado_Estudio : Base
    {
        #region Peticiones

        public Tb_Colegiado_Estudio() { }

        public Tb_Colegiado_Estudio(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_ESTUDIO")) Id_Estudio = Convert.ToInt32(Reader["ID_ESTUDIO"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_ORIGEN")) Id_Origen = Convert.ToInt32(Reader["ID_ORIGEN"]);
            if (ReadCol.Exist(Reader, "UNIVERSIDAD")) Universidad = Convert.ToString(Reader["UNIVERSIDAD"]);
            if (ReadCol.Exist(Reader, "NRO_TITULO")) Nro_Titulo = Convert.ToString(Reader["NRO_TITULO"]);
            if (ReadCol.Exist(Reader, "NRO_RESOLUCION")) Nro_Resolucion = Convert.ToString(Reader["NRO_RESOLUCION"]);
            if (ReadCol.Exist(Reader, "ID_SITUACION")) Id_Situacion = Convert.ToInt32(Reader["ID_SITUACION"]);
            if (ReadCol.Exist(Reader, "FECHA_EGRESO")) Fecha_Egreso = Convert.ToDateTime(Reader["FECHA_EGRESO"]);
            if (ReadCol.Exist(Reader, "FECHA_EXP_TITULO")) Fecha_Exp_Titulo = Convert.ToDateTime(Reader["FECHA_EXP_TITULO"]);
            if (ReadCol.Exist(Reader, "OBSERVACION")) Observacion_Est = Convert.ToString(Reader["OBSERVACION"]);
            if (ReadCol.Exist(Reader, "ENTIDAD_ACREDITADA")) Entidad_Acreditada = Convert.ToString(Reader["ENTIDAD_ACREDITADA"]);
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