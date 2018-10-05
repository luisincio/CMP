/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public partial class Tb_Colegiado_Laboral
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Informacion_Laboral { get; set; }  
		[DataMember]  
		public int Id_Persona { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar un sector")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un sector")]
		public int Id_Sector { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar un grupo ocupacional")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un grupo ocupacional")]
		public int Id_Grupo_Ocupacional { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar una empresa")]
        [StringLength(150, ErrorMessage = "La empresa no debe pasar los 150 caracteres")]
        public string Empresa { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar una dirección laboral")]
        [StringLength(250, ErrorMessage = "La dirección laboral no debe pasar los 250 caracteres")]
		public string Direccion { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar la ubicación geográfica")]
        [StringLength(6, ErrorMessage = "La ubicación geográfica es incorrecta")]
		public string Id_Ubigeo_Laboral { get; set; }  
        //[DataMember]
        //[Required(ErrorMessage = "Debe ingresar un punto de atención")]
        //[Range(1, 1000, ErrorMessage = "Debe Seleccionar un punto de atención")]
        //public int Id_Punto_Atencion { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar el número de teléfono")]
        [StringLength(15, ErrorMessage = "El teléfono no debe pasar los 15 caracteres")]
		public string Telefono { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar el número de fax")]
        [StringLength(15, ErrorMessage = "El fax no debe pasar los 15 caracteres")]
		public string Fax { get; set; }
        [DataMember]
        [StringLength(15, ErrorMessage = "El teléfono no debe pasar los 15 caracteres")]
        public string Telefono2 { get; set; }
        [DataMember]
        [StringLength(15, ErrorMessage = "El fax no debe pasar los 15 caracteres")]
        public string Fax2 { get; set; }
		[DataMember]
        //[Required(ErrorMessage = "Debe ingresar la glosa")]
        [StringLength(500, ErrorMessage = "La glosa no debe pasar los 500 caracteres")]
		public string Glosa { get; set; }  
		
        #endregion
    }
}