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
    public partial class Tb_Colegiado_Carnet : Base
    {
        #region Peticiones

        public Tb_Colegiado_Carnet() { }

        public Tb_Colegiado_Carnet(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_CARNET")) Id_Carnet = Convert.ToInt32(Reader["ID_CARNET"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "CORRELATIVO")) Correlativo = Convert.ToInt32(Reader["CORRELATIVO"]);
            if (ReadCol.Exist(Reader, "ID_COLEGIADO")) Id_Colegiado = Convert.ToString(Reader["ID_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "ID_TIPOCARNET")) Id_Tipocarnet = Convert.ToInt32(Reader["ID_TIPOCARNET"]);
            if (ReadCol.Exist(Reader, "FEC_EMISION")) Fec_Emision = Convert.ToDateTime(Reader["FEC_EMISION"]);
            if (ReadCol.Exist(Reader, "FEC_ENTREGA")) Fec_Entrega = Convert.ToDateTime(Reader["FEC_ENTREGA"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO")) Id_Consejo = Convert.ToInt32(Reader["ID_CONSEJO"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);

            if (ReadCol.Exist(Reader, "CONSEJO_REGIONAL")) Consejo_Regional = Convert.ToString(Reader["CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "TIPO_CARNET")) Tipo_Carnet = Convert.ToString(Reader["TIPO_CARNET"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO_REGIONAL")) Id_Consejo_Regional = Convert.ToInt32(Reader["ID_CONSEJO_REGIONAL"]);
        }

        #endregion

        #region Atributos Adicionales

        public string Consejo_Regional { get; set; }
        public int Id_Consejo_Regional { get; set; }

        public string Nombre_Completo { get; set; }

        public string Tipo_Carnet { get; set; }
        #endregion
    }
}