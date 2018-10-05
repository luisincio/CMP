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
    public partial class Tb_Maestras
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Maestras { get; set; }  
		[DataMember]  
		public int Id_General { get; set; }  
		[DataMember]  
		public int Id_Detalle { get; set; }  
		[DataMember]  
		public string Descripcion { get; set; }  
		[DataMember]  
		public string Valor1 { get; set; }  
		[DataMember]  
		public string Valor2 { get; set; }  
		[DataMember]  
		public string Valor3 { get; set; }  
		
        #endregion
    }
}