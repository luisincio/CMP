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
using System.ComponentModel.DataAnnotations;
#endregion

namespace Cmp02.Entities
{
    public partial class Tb_Persona_Natural : Base
    {
        #region Peticiones

        public Tb_Persona_Natural() { }

        public Tb_Persona_Natural(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "COLEGIADO")) Colegiado = Convert.ToString(Reader["COLEGIADO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_PATERNO")) Apellido_Paterno = Convert.ToString(Reader["APELLIDO_PATERNO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_MATERNO")) Apellido_Materno = Convert.ToString(Reader["APELLIDO_MATERNO"]);
            if (ReadCol.Exist(Reader, "NOMBRES")) Nombres = Convert.ToString(Reader["NOMBRES"]);
            if (ReadCol.Exist(Reader, "ID_GRUPO_SANGUINEO")) Id_Grupo_Sanguineo = Convert.ToInt32(Reader["ID_GRUPO_SANGUINEO"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_DOCUMENTO")) Id_Tipo_Documento = Convert.ToInt32(Reader["ID_TIPO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_ESTADO_CIVIL")) Id_Tipo_Estado_Civil = Convert.ToInt32(Reader["ID_TIPO_ESTADO_CIVIL"]);
            if (ReadCol.Exist(Reader, "SEXO")) Sexo = Convert.ToString(Reader["SEXO"]);
            if (ReadCol.Exist(Reader, "FECHA_NACIO")) Fecha_Nacio = Convert.ToDateTime(Reader["FECHA_NACIO"]);
            if (ReadCol.Exist(Reader, "LUGAR_NACIMIENTO")) Lugar_Nacimiento = Convert.ToString(Reader["LUGAR_NACIMIENTO"]);
            if (ReadCol.Exist(Reader, "OBSERVACION")) Observacion = Convert.ToString(Reader["OBSERVACION"]);
            if (ReadCol.Exist(Reader, "FEC_COLEGIADO")) Fec_Colegiado = Convert.ToDateTime(Reader["FEC_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO")) Id_Estado_Actual = Convert.ToInt32(Reader["ID_ESTADO"]);
            if (ReadCol.Exist(Reader, "ID_CARNET")) Id_Carnet = Convert.ToInt32(Reader["ID_CARNET"]);
            if (ReadCol.Exist(Reader, "ID_HABILIDAD")) Id_Habilidad = Convert.ToInt32(Reader["ID_HABILIDAD"]);
            if (ReadCol.Exist(Reader, "ID_ENTIDAD_PAGA")) Id_Entidad_Paga = Convert.ToInt32(Reader["ID_ENTIDAD_PAGA"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "ESTADO_ACTUAL")) Estado_Actual = Convert.ToString(Reader["ESTADO_ACTUAL"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO_ACTUAL")) IdConsejo_Actual = Convert.ToInt32(Reader["ID_CONSEJO_ACTUAL"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar su origén")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar su origen")]
        public int Origen { get; set; }
        [DataMember]
        public string Estado_Actual { get; set; }
        [DataMember]
        public int IdConsejo_Actual { get; set; }
        #endregion
    }
}