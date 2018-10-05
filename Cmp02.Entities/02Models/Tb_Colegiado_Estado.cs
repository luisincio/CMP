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
    public partial class Tb_Colegiado_Estado
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Estado { get; set; }  
		[DataMember]  
		public int Id_Persona { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar un estado")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un estado")]
		public int Id_Estado_Colegiado { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar una observación")]
        [StringLength(500, ErrorMessage = "La observación no debe pasar los 500 caracteres")]
		public string ObservacionEstado { get; set; }
        [DataMember]
        public DateTime? Fec_Inicio { get; set; }
        [DataMember]
        public DateTime? Fec_Fin { get; set; }

        #endregion
    }
}