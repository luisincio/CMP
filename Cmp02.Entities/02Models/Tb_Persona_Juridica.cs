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
    public partial class Tb_Persona_Juridica
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Persona { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresar su tipo de origen")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un tipo de origen")]
        public int Id_Origen_Juridico { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar un grupo")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un grupo")]
        public int Id_Grupo_Juridico { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar un consejo")]
        public int Id_Consejo_Juridico { get; set; } 

		[DataMember]
        [Required(ErrorMessage = "Debe ingresar la Razón Social")]
        [StringLength(100, ErrorMessage = "La Razón Social no debe pasar los 100 caracteres")]
		public string Razon_Social { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar dirección")]
        [StringLength(250, ErrorMessage = "La dirección no debe pasar los 250 caracteres")]
		public string Direccion { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar Ubigeo")]
        [StringLength(6, ErrorMessage = "El Ubigeo no debe pasar los 6 caracteres")]
		public string Id_Ubigeo { get; set; }  
		
        #endregion
    }
}