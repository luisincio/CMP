#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utildatatool;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public class ClienteClover: Base
    {
        #region Atributos Básicos

        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Tipo de Persona")]
        public int TipoPersona { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Nro de Documento")]
        public string NroDocumento { get; set; }
        [DataMember]
        //[Required(ErrorMessage = "Debe ingresar el Nombre Completo")]
        public string NombreCompleto { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la Clase")]
        public string Clase { get; set; }
        [DataMember]
        //[Required(ErrorMessage = "Debe ingresar el Pais")]
        public string Pais { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Distrito { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la Dirección")]
        public string Direccion1 { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la Ubicación Geografica")]
        public string Direccion2 { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Tipo de Documento")]
        public int TipoDocumento { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Nombre")]
        public string PrimerNombre { get; set; }
        [DataMember]
        public string SegundoNombre { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string FormaPago { get; set; }
        [DataMember]
        public string Colegiado { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la Ubicación Geografica")]
        public string Id_Ubigeo { get; set; }

        [DataMember]
        public int Id_Sector { get; set; }
        [DataMember]
        public int Id_Grupo { get; set; }
        [DataMember]
        public int Id_Consejo { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Celular")]
        public string Celular { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Correo")]
        public string Email { get; set; }

        [DataMember]
        public string IdPersona { get; set; }

        #endregion

        public ClienteClover(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "IdPersona")) IdPersona = Convert.ToString(Reader["IdPersona"]);
            if (ReadCol.Exist(Reader, "NombreCompleto")) NombreCompleto = Convert.ToString(Reader["NombreCompleto"]);
            if (ReadCol.Exist(Reader, "TipoPersona")) TipoPersona = Convert.ToInt32(Reader["TipoPersona"]);
            if (ReadCol.Exist(Reader, "TipoDocumento")) TipoDocumento = Convert.ToInt32(Reader["TipoDocumento"]);
            if (ReadCol.Exist(Reader, "NroDocumento")) NroDocumento = Convert.ToString(Reader["NroDocumento"]);
        }

        public ClienteClover() { }
    }

}
