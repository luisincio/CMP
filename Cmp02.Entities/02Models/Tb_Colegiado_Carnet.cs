/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public partial class Tb_Colegiado_Carnet
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Carnet { get; set; }  
		[DataMember]  
		public int Id_Persona { get; set; }  
		[DataMember]  
		public int Correlativo { get; set; }  
		[DataMember]  
		public string Id_Colegiado { get; set; }  
		[DataMember]  
		public int Id_Tipocarnet { get; set; }  
		[DataMember]  
		public DateTime? Fec_Emision { get; set; }  
		[DataMember]  
		public DateTime? Fec_Entrega { get; set; }  
		[DataMember]  
		public int Id_Consejo { get; set; }  
		
        #endregion
    }
}