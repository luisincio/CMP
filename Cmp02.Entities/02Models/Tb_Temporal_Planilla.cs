/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public partial class Tb_Temporal_Planilla
    {
        #region Atributos Básicos

        [DataMember]  
		public string Id_Seguro { get; set; }
        [DataMember]
        public string Nro_Recibo { get; set; }
        [DataMember]
        public int Id_Consejo { get; set; }
        [DataMember]
        public int Id_EntidadPagadora { get; set; }  

		[DataMember]  
		public string Id_Colegiado { get; set; }  
		[DataMember]  
		public string Dni { get; set; }  
		[DataMember]  
		public string Nombre_Completo { get; set; }  
		[DataMember]  
		public string Movimiento { get; set; }  
		[DataMember]  
		public decimal? Importe { get; set; }  
		[DataMember]  
		public string Periodo { get; set; }
        [DataMember]
        public string Tipo { get; set; }

        #endregion
    }
}