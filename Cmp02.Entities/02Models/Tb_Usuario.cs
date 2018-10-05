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
    public partial class Tb_Usuario
    {
        #region Atributos Básicos

        [DataMember]
        [Key]
		public int Id_Usuario { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar el Usuario")]
        [StringLength(20, ErrorMessage = "El usuario no debe pasar los 20 caracteres")]
		public string Usuario { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar la clave")]
        [StringLength(20, ErrorMessage = "La clave no debe pasar los 20 caracteres")]
		public string Contraseña { get; set; }  
		
        #endregion
    }
}