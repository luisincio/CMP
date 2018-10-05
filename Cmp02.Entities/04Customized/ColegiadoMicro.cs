using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Utildatatool;

namespace Cmp02.Entities
{
    public class ColegiadoMicro: Base
    {
        #region Atributos
        [DataMember]
        public int Id_Persona { get; set; }
        [DataMember]
        public string Colegiado { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar el Apellido Paterno")]        [StringLength(50, ErrorMessage = "El Apellido Paterno no debe pasar los 50 caracteres")]
        public string Apellido_Paterno { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar el Apellido Materno")]        [StringLength(50, ErrorMessage = "El Apellido Materno no debe pasar los 50 caracteres")]
        public string Apellido_Materno { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar Nombre")]        [StringLength(50, ErrorMessage = "El Nombre no debe pasar los 50 caracteres")]
        public string Nombres { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar su tipo de documento")]        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un tipo de documeto")]
        public int Id_Tipo_Documento { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar el Nro. de documento")]        [StringLength(20, ErrorMessage = "El número de documento no debe pasar los 20 caracteres")]
        public string Nro_Documento { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar fecha de nacimiento")]        [DataType(DataType.Date)]        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacio { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar el lugar de nacimiento")]        [StringLength(100, ErrorMessage = "El Nombre no debe pasar los 100 caracteres")]
        public string Lugar_Nacimiento { get; set; }
        [DataMember]        public int Id_Estado_Actual { get; set; }
        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar su origén")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar su origen")]
        public int Origen { get; set; }
        [DataMember]
        public string Estado_Actual { get; set; }

        [DataMember]        [Required(ErrorMessage = "Debe ingresar el tipo de vía")]        [Range(1, 1000, ErrorMessage = "Debe Seleccionar tipo de vía")]
        public int Id_Tipo_Via { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar el nombre de la vía")]        [StringLength(100, ErrorMessage = "El nombre de la vía no debe pasar los 100 caracteres")]
        public string Nombre_Via { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar el número de la vía")]        [StringLength(5, ErrorMessage = "El número de la vía es incorrecto")]
        public string Nro_Via { get; set; }
        [DataMember]
        public string Nro_Km { get; set; }
        [DataMember]
        public string Manzana { get; set; }
        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public string Nro_Interior { get; set; }
        [DataMember]
        public string Nro_Departamento { get; set; }
        [DataMember]
        public int? Id_Tipo_Zona { get; set; }
        [DataMember]
        public string Nombre_Zona { get; set; }
        [DataMember]
        public string Referencia { get; set; }
        [DataMember]
        public string Domicilio_Completo { get; set; }
        [DataMember]        [Required(ErrorMessage = "Debe ingresar la ubicación geográfica")]        [StringLength(6, ErrorMessage = "La ubicación geográfica es incorrecta")]
        public string Id_Ubigeo { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la ubicación geográfica")]
        public string Nombre_Ubigeo { get; set; }

        public List<Tb_Medio_Contacto> Medios { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }

        #endregion


        public ColegiadoMicro(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "COLEGIADO")) Colegiado = Convert.ToString(Reader["COLEGIADO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_PATERNO")) Apellido_Paterno = Convert.ToString(Reader["APELLIDO_PATERNO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_MATERNO")) Apellido_Materno = Convert.ToString(Reader["APELLIDO_MATERNO"]);
            if (ReadCol.Exist(Reader, "NOMBRES")) Nombres = Convert.ToString(Reader["NOMBRES"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_DOCUMENTO")) Id_Tipo_Documento = Convert.ToInt32(Reader["ID_TIPO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "FECHA_NACIO")) Fecha_Nacio = Convert.ToDateTime(Reader["FECHA_NACIO"]);
            if (ReadCol.Exist(Reader, "LUGAR_NACIMIENTO")) Lugar_Nacimiento = Convert.ToString(Reader["LUGAR_NACIMIENTO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO")) Id_Estado_Actual = Convert.ToInt32(Reader["ID_ESTADO"]);

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
            if (ReadCol.Exist(Reader, "NOMBRE_UBIGEO")) Nombre_Ubigeo = Convert.ToString(Reader["NOMBRE_UBIGEO"]);

            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "ESTADO_ACTUAL")) Estado_Actual = Convert.ToString(Reader["ESTADO_ACTUAL"]);
        }

        public ColegiadoMicro() { }
    }

}
