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
    public partial class Tb_Permiso
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Permiso { get; set; }  
		[DataMember]  
		public string Etiqueta { get; set; }  
		[DataMember]  
		public string Accion { get; set; }  
		[DataMember]  
		public string Controladora { get; set; }  
		[DataMember]  
		public string Descripcion { get; set; }  
		
        #endregion
    }
}