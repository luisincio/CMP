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
    public partial class Tb_Domicilio : Base
    {
        #region Peticiones

        public Tb_Domicilio() { }

        public Tb_Domicilio(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_DOMICILIO")) Id_Domicilio = Convert.ToInt32(Reader["ID_DOMICILIO"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_PAIS")) Id_Pais = Convert.ToInt32(Reader["ID_PAIS"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_VIA")) Id_Tipo_Via = Convert.ToInt32(Reader["ID_TIPO_VIA"]);
            if (ReadCol.Exist(Reader, "NOMBRE_VIA")) Nombre_Via = Convert.ToString(Reader["NOMBRE_VIA"]);
            if (ReadCol.Exist(Reader, "NRO_VIA")) Nro_Via = Convert.ToString(Reader["NRO_VIA"]);
            if (ReadCol.Exist(Reader, "NRO_KM")) Nro_Km = Convert.ToString(Reader["NRO_KM"]);
            if (ReadCol.Exist(Reader, "MANZANA")) Manzana = Convert.ToString(Reader["MANZANA"]);
            if (ReadCol.Exist(Reader, "LOTE")) Lote = Convert.ToString(Reader["LOTE"]);
            if (ReadCol.Exist(Reader, "NRO_INTERIOR")) Nro_Interior = Convert.ToString(Reader["NRO_INTERIOR"]);
            if (ReadCol.Exist(Reader, "NRO_DEPARTAMENTO")) Nro_Departamento = Convert.ToString(Reader["NRO_DEPARTAMENTO"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_ZONA")) Id_Tipo_Zona = Convert.ToInt32(Reader["ID_TIPO_ZONA"]);
            if (ReadCol.Exist(Reader, "NOMBRE_ZONA")) Nombre_Zona = Convert.ToString(Reader["NOMBRE_ZONA"]);
            if (ReadCol.Exist(Reader, "REFERENCIA")) Referencia = Convert.ToString(Reader["REFERENCIA"]);
            if (ReadCol.Exist(Reader, "DOMICILIO_COMPLETO")) Domicilio_Completo = Convert.ToString(Reader["DOMICILIO_COMPLETO"]);
            if (ReadCol.Exist(Reader, "ID_UBIGEO")) Id_Ubigeo = Convert.ToString(Reader["ID_UBIGEO"]);
            if (ReadCol.Exist(Reader, "FLG_DOMICILIO_FISCAL")) Flg_Domicilio_Fiscal = Convert.ToString(Reader["FLG_DOMICILIO_FISCAL"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "NOMBRE_UBIGEO")) Nombre_Ubigeo = Convert.ToString(Reader["NOMBRE_UBIGEO"]);

            if (ReadCol.Exist(Reader, "DEPARTAMENTO")) Departamento = Convert.ToString(Reader["DEPARTAMENTO"]);
            if (ReadCol.Exist(Reader, "PROVINCIA")) Provincia = Convert.ToString(Reader["PROVINCIA"]);
            if (ReadCol.Exist(Reader, "DISTRITO")) Distrito = Convert.ToString(Reader["DISTRITO"]);
            if (ReadCol.Exist(Reader, "SECCION")) Seccion = Convert.ToString(Reader["SECCION"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la ubicación geográfica")]
        public string Nombre_Ubigeo { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Distrito { get; set; }

        #endregion
    }
}