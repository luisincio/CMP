using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Utildatatool;

namespace Cmp02.Entities
{
    public class FullConsulta
    {
        [DataMember]
        public string Colegiado { get; set; }
        [DataMember]
        public string Apellido_Paterno { get; set; }
        [DataMember]
        public string Apellido_Materno { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Nombre_Completo { get; set; }
        [DataMember]
        public string Tipo_Documento { get; set; }
        [DataMember]
        public string Nro_Documento { get; set; }
        [DataMember]
        public string Grupo_Sanguineo { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public DateTime Fecha_Nacio { get; set; }
        [DataMember]
        public int? Edad { get; set; }
        [DataMember]
        public string Lugar_Nacimiento { get; set; }
        [DataMember]
        public string Estado_Civil { get; set; }
        [DataMember]
        public DateTime Fec_Colegiado { get; set; }
        [DataMember]
        public DateTime Fec_Ingreso { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Habilidad { get; set; }
        [DataMember]
        public string Entidad_Pagadora { get; set; }
        [DataMember]
        public string Domicilio_Completo { get; set; }
        [DataMember]
        public string Distrito { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Universidad { get; set; }
        [DataMember]
        public string Origen { get; set; }
        [DataMember]
        public string Situacion { get; set; }
        [DataMember]
        public string Nro_Titulo { get; set; }
        [DataMember]
        public string Nro_Resolucion { get; set; }
        [DataMember]
        public DateTime? Fecha_Egreso { get; set; }
        [DataMember]
        public DateTime? Fecha_Exp_Titulo { get; set; }
        [DataMember]
        public string Entidad_Acreditada { get; set; }
        [DataMember]
        public string Consejo_Regional { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string Telefono_Domiciliario { get; set; }
        [DataMember]
        public string Telefono_Trabajo { get; set; }
        [DataMember]
        public string Pagina_Web { get; set; }  

        public FullConsulta(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "COLEGIADO")) Colegiado = Convert.ToString(Reader["COLEGIADO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_PATERNO")) Apellido_Paterno = Convert.ToString(Reader["APELLIDO_PATERNO"]);
            if (ReadCol.Exist(Reader, "APELLIDO_MATERNO")) Apellido_Materno = Convert.ToString(Reader["APELLIDO_MATERNO"]);
            if (ReadCol.Exist(Reader, "NOMBRES")) Nombres = Convert.ToString(Reader["NOMBRES"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "TIPO_DOCUMENTO")) Tipo_Documento = Convert.ToString(Reader["TIPO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "GRUPO_SANGUINEO")) Grupo_Sanguineo = Convert.ToString(Reader["GRUPO_SANGUINEO"]);
            if (ReadCol.Exist(Reader, "SEXO")) Sexo = Convert.ToString(Reader["SEXO"]);
            if (ReadCol.Exist(Reader, "FECHA_NACIO")) Fecha_Nacio = Convert.ToDateTime(Reader["FECHA_NACIO"]);
            if (ReadCol.Exist(Reader, "EDAD")) Edad = Convert.ToInt32(Reader["EDAD"]);
            if (ReadCol.Exist(Reader, "LUGAR_NACIMIENTO")) Lugar_Nacimiento = Convert.ToString(Reader["LUGAR_NACIMIENTO"]);
            if (ReadCol.Exist(Reader, "ESTADO_CIVIL")) Estado_Civil = Convert.ToString(Reader["ESTADO_CIVIL"]);
            if (ReadCol.Exist(Reader, "FEC_COLEGIADO")) Fec_Colegiado = Convert.ToDateTime(Reader["FEC_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "ESTADO")) Estado = Convert.ToString(Reader["ESTADO"]);
            if (ReadCol.Exist(Reader, "HABILIDAD")) Habilidad = Convert.ToString(Reader["HABILIDAD"]);
            if (ReadCol.Exist(Reader, "ENTIDAD_PAGADORA")) Entidad_Pagadora = Convert.ToString(Reader["ENTIDAD_PAGADORA"]);
            if (ReadCol.Exist(Reader, "DOMICILIO_COMPLETO")) Domicilio_Completo = Convert.ToString(Reader["DOMICILIO_COMPLETO"]);
            if (ReadCol.Exist(Reader, "DISTRITO")) Distrito = Convert.ToString(Reader["DISTRITO"]);
            if (ReadCol.Exist(Reader, "PROVINCIA")) Provincia = Convert.ToString(Reader["PROVINCIA"]);
            if (ReadCol.Exist(Reader, "DEPARTAMENTO")) Departamento = Convert.ToString(Reader["DEPARTAMENTO"]);
            if (ReadCol.Exist(Reader, "UNIVERSIDAD")) Universidad = Convert.ToString(Reader["UNIVERSIDAD"]);
            if (ReadCol.Exist(Reader, "ORIGEN")) Origen = Convert.ToString(Reader["ORIGEN"]);
            if (ReadCol.Exist(Reader, "SITUACION")) Situacion = Convert.ToString(Reader["SITUACION"]);
            if (ReadCol.Exist(Reader, "NRO_TITULO")) Nro_Titulo = Convert.ToString(Reader["NRO_TITULO"]);
            if (ReadCol.Exist(Reader, "NRO_RESOLUCION")) Nro_Resolucion = Convert.ToString(Reader["NRO_RESOLUCION"]);
            if (ReadCol.Exist(Reader, "FECHA_EGRESO")) Fecha_Egreso = Convert.ToDateTime(Reader["FECHA_EGRESO"]);
            if (ReadCol.Exist(Reader, "FECHA_EXP_TITULO")) Fecha_Exp_Titulo = Convert.ToDateTime(Reader["FECHA_EXP_TITULO"]);
            if (ReadCol.Exist(Reader, "ENTIDAD_ACREDITADA")) Entidad_Acreditada = Convert.ToString(Reader["ENTIDAD_ACREDITADA"]);
            if (ReadCol.Exist(Reader, "CONSEJO_REGIONAL")) Consejo_Regional = Convert.ToString(Reader["CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "CELULAR")) Celular = Convert.ToString(Reader["CELULAR"]);
            if (ReadCol.Exist(Reader, "CORREO")) Correo = Convert.ToString(Reader["CORREO"]);
            if (ReadCol.Exist(Reader, "FAX")) Fax = Convert.ToString(Reader["FAX"]);
            if (ReadCol.Exist(Reader, "TELEFONO_DOMICILIARIO")) Telefono_Domiciliario = Convert.ToString(Reader["TELEFONO_DOMICILIARIO"]);
            if (ReadCol.Exist(Reader, "TELEFONO_TRABAJO")) Telefono_Trabajo = Convert.ToString(Reader["TELEFONO_TRABAJO"]);
            if (ReadCol.Exist(Reader, "PAGINA_WEB")) Pagina_Web = Convert.ToString(Reader["PAGINA_WEB"]); 
        }

        public FullConsulta() { }
    }
}
