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
    public partial class Tb_Colegiado_Especialidad : Base
    {
        #region Peticiones

        public Tb_Colegiado_Especialidad() { }

        public Tb_Colegiado_Especialidad(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_ESPECIALIDAD")) Id_Especialidad = Convert.ToInt32(Reader["ID_ESPECIALIDAD"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "NRO_ESPECIALIDAD")) Nro_Especialidad = Convert.ToString(Reader["NRO_ESPECIALIDAD"]);
            if (ReadCol.Exist(Reader, "ID_TIPO")) Id_Tipo = Convert.ToInt32(Reader["ID_TIPO"]);
            if (ReadCol.Exist(Reader, "ESPECIALIDAD")) Especialidad = Convert.ToString(Reader["ESPECIALIDAD"]);
            if (ReadCol.Exist(Reader, "ID_ORIGEN")) Id_Origen_Especialidad = Convert.ToInt32(Reader["ID_ORIGEN"]);
            if (ReadCol.Exist(Reader, "UNIVERSIDAD")) Universidad_Especialidad = Convert.ToString(Reader["UNIVERSIDAD"]);
            if (ReadCol.Exist(Reader, "ID_SITUACION")) Id_Situacion_Especialidad = Convert.ToInt32(Reader["ID_SITUACION"]);
            if (ReadCol.Exist(Reader, "FECHA_REGISTRO")) Fecha_Registro = Convert.ToDateTime(Reader["FECHA_REGISTRO"]);
            if (ReadCol.Exist(Reader, "FECHA_CADUCIDAD")) Fecha_Caducidad = Convert.ToDateTime(Reader["FECHA_CADUCIDAD"]);
            if (ReadCol.Exist(Reader, "RESOLUCION")) Resolucion = Convert.ToString(Reader["RESOLUCION"]);
            if (ReadCol.Exist(Reader, "FECHA_RESOLUCION")) Fecha_Resolucion = Convert.ToDateTime(Reader["FECHA_RESOLUCION"]);
            if (ReadCol.Exist(Reader, "ID_CONS_REG_TRAMITE")) Id_Cons_Reg_Tramite = Convert.ToInt32(Reader["ID_CONS_REG_TRAMITE"]);
            if (ReadCol.Exist(Reader, "FLG_RECERTIFICADO")) Flg_Recertificado = Convert.ToString(Reader["FLG_RECERTIFICADO"]);
            if (ReadCol.Exist(Reader, "FECHA_ESPECIALIDAD")) Fecha_Especialidad = Convert.ToDateTime(Reader["FECHA_ESPECIALIDAD"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "TIPO_NOMBRE")) Tipo_Nombre = Convert.ToString(Reader["TIPO_NOMBRE"]);
            if (ReadCol.Exist(Reader, "SITUACION_NOMBRE")) Situacion_Nombre = Convert.ToString(Reader["SITUACION_NOMBRE"]);

            if (ReadCol.Exist(Reader, "ENTIDAD_ACREDITADA")) Entidad_Acreditada_Esp = Convert.ToString(Reader["ENTIDAD_ACREDITADA"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public string Tipo_Nombre { get; set; }
        [DataMember]
        public string Situacion_Nombre { get; set; }  

        #endregion
    }
}