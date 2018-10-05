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
    public partial class Tb_Colegiado_Estudio
    {
        #region Atributos Básicos

        [DataMember]
        public int Id_Estudio { get; set; }  
        [DataMember]  
		public int Id_Persona { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar un origen")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un origen")]
		public int Id_Origen { get; set; }
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar una universidad")]
        [StringLength(150, ErrorMessage = "El Nombre de la universidad no debe pasar los 150 caracteres")]
		public string Universidad { get; set; }  
		[DataMember]
        //[Required(ErrorMessage = "Debe ingresar un número de titulo")]
        [StringLength(20, ErrorMessage = "El número de titulo no debe pasar los 20 caracteres")]
		public string Nro_Titulo { get; set; }
        [DataMember]
        //[Required(ErrorMessage = "Debe ingresar un número de resolución")]
        [StringLength(30, ErrorMessage = "El número de resolución no debe pasar los 20 caracteres")]
		public string Nro_Resolucion { get; set; } 
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar una situación")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar una situación")]
		public int Id_Situacion { get; set; }  
		[DataMember]
        //[Required(ErrorMessage = "Debe ingresar fecha de egreso")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "01/01/1920", "01/03/2017", ErrorMessage = "Fecha fuera de rango")]
		public DateTime Fecha_Egreso { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar fecha de expedición")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "01/01/1920", "01/01/2030", ErrorMessage = "Fecha fuera de rango")]
		public DateTime Fecha_Exp_Titulo { get; set; }  
		[DataMember]
        public string Observacion_Est { get; set; }
        [DataMember]
        public string Entidad_Acreditada { get; set; }  
        #endregion
    }
}