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
    public partial class Tb_Persona_Directivo : Base
    {
        #region Peticiones

        public Tb_Persona_Directivo() { }

        public Tb_Persona_Directivo(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_DIRECTIVO")) Id_Directivo = Convert.ToInt32(Reader["ID_DIRECTIVO"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO")) Id_Consejo = Convert.ToInt32(Reader["ID_CONSEJO"]);
            if (ReadCol.Exist(Reader, "COLEGIADO")) Colegiado = Convert.ToString(Reader["COLEGIADO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_PATERNO")) Apellido_Paterno = Convert.ToString(Reader["APELLIDO_PATERNO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_MATERNO")) Apellido_Materno = Convert.ToString(Reader["APELLIDO_MATERNO"]);
            if (ReadCol.Exist(Reader, "NOMBRES")) Nombres = Convert.ToString(Reader["NOMBRES"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_DOCUMENTO")) Id_Tipo_Documento = Convert.ToInt32(Reader["ID_TIPO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "ID_CARGO")) Id_Cargo = Convert.ToInt32(Reader["ID_CARGO"]);
            if (ReadCol.Exist(Reader, "FEC_INICIO")) Fec_Inicio = Convert.ToDateTime(Reader["FEC_INICIO"]);
            if (ReadCol.Exist(Reader, "FEC_TERMINO")) Fec_Termino = Convert.ToDateTime(Reader["FEC_TERMINO"]);
            if (ReadCol.Exist(Reader, "PERIODO")) Periodo = Convert.ToString(Reader["PERIODO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO")) Id_Estado = Convert.ToInt32(Reader["ID_ESTADO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO_DIRECTIVO")) Id_Estado_Directivo = Convert.ToInt32(Reader["ID_ESTADO_DIRECTIVO"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);

            if (ReadCol.Exist(Reader, "CARGO")) Cargo = Convert.ToString(Reader["CARGO"]);
            if (ReadCol.Exist(Reader, "ESTADO")) Estado = Convert.ToString(Reader["ESTADO"]);
        }

        #endregion

        #region Atributos Adicionales

        public string Cargo { get; set; }
        public string Estado { get; set; }
        #endregion
    }
}