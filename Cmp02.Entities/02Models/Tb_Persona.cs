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
    public partial class Tb_Persona
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Persona { get; set; }  
		[DataMember]  
		public string Id_Tipo_Persona { get; set; }  
		[DataMember]  
		public string Nombre_Comercial { get; set; }  
		[DataMember]  
		public string Nombre_Completo { get; set; }  
		[DataMember]  
		public string Ruc { get; set; }  
		[DataMember]  
		public string Flg_Nacionalidad { get; set; }  
		
        #endregion
    }
}