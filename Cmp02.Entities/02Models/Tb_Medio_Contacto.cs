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
    public partial class Tb_Medio_Contacto
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Medio_Contacto { get; set; }  
		[DataMember]  
		public int Id_Persona { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su tipo de contacto")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un tipo de contacto")]
		public int Id_Tipo_Medio_Contacto { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar un contenido del medio de contacto")]
        [StringLength(100, ErrorMessage = "El contenido del medio del contacto no debe pasar los 100 caracteres")]
		public string Nombre_Medio_Contacto { get; set; }  
		
        #endregion
    }
}