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
    public partial class Tb_Pais
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Pais { get; set; }  
		[DataMember]  
		public string Iso2 { get; set; }  
		[DataMember]  
		public string Iso3 { get; set; }  
		[DataMember]  
		public string Descripcion { get; set; }  
		
        #endregion
    }
}