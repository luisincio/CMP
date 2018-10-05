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
    public partial class Tb_Colegiado_Laboral : Base
    {
        #region Peticiones

        public Tb_Colegiado_Laboral() { }

        public Tb_Colegiado_Laboral(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_INFORMACION_LABORAL")) Id_Informacion_Laboral = Convert.ToInt32(Reader["ID_INFORMACION_LABORAL"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_SECTOR")) Id_Sector = Convert.ToInt32(Reader["ID_SECTOR"]);
            if (ReadCol.Exist(Reader, "ID_GRUPO_OCUPACIONAL")) Id_Grupo_Ocupacional = Convert.ToInt32(Reader["ID_GRUPO_OCUPACIONAL"]);
            if (ReadCol.Exist(Reader, "EMPRESA")) Empresa = Convert.ToString(Reader["EMPRESA"]);
            if (ReadCol.Exist(Reader, "DIRECCION")) Direccion = Convert.ToString(Reader["DIRECCION"]);
            if (ReadCol.Exist(Reader, "ID_UBIGEO")) Id_Ubigeo_Laboral = Convert.ToString(Reader["ID_UBIGEO"]);
            //if (ReadCol.Exist(Reader, "ID_PUNTO_ATENCION")) Id_Punto_Atencion = Convert.ToInt32(Reader["ID_PUNTO_ATENCION"]);
            if (ReadCol.Exist(Reader, "TELEFONO")) Telefono = Convert.ToString(Reader["TELEFONO"]);
            if (ReadCol.Exist(Reader, "FAX")) Fax = Convert.ToString(Reader["FAX"]);
            if (ReadCol.Exist(Reader, "TELEFONO2")) Telefono2 = Convert.ToString(Reader["TELEFONO2"]);
            if (ReadCol.Exist(Reader, "FAX2")) Fax2 = Convert.ToString(Reader["FAX2"]);
            if (ReadCol.Exist(Reader, "GLOSA")) Glosa = Convert.ToString(Reader["GLOSA"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "SECTOR_NOMBRE")) Sector_Nombre = Convert.ToString(Reader["SECTOR_NOMBRE"]);
            if (ReadCol.Exist(Reader, "GRUPO_NOMBRE")) Grupo_Nombre  = Convert.ToString(Reader["GRUPO_NOMBRE"]);
            if (ReadCol.Exist(Reader, "UBIGEO_NOMBRE")) Ubigeo_Laboral_Nombre = Convert.ToString(Reader["UBIGEO_NOMBRE"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public string Sector_Nombre { get; set; }
        [DataMember]
        public string Grupo_Nombre { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar un ubigeo")]
        public string Ubigeo_Laboral_Nombre { get; set; }  

        #endregion
    }
}