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
    public partial class Tb_Parametro
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Parametro { get; set; }  
		[DataMember]  
		public int Id_Sucursal { get; set; }  
		[DataMember]  
		public string Descripcion { get; set; }  
		[DataMember]  
		public string Valor_Texto { get; set; }  
		[DataMember]  
		public decimal? Valor_Numerico { get; set; }  
		
        #endregion
    }
}