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
    public partial class Tb_Ubigeo
    {
        #region Atributos Básicos

        [DataMember]
		public string Id_Ubigeo { get; set; }
		[DataMember]
		public int Id_Pais { get; set; }  
		[DataMember]
		public string Departamento { get; set; }
		[DataMember]
		public string Provincia { get; set; }
		[DataMember]
		public string Distrito { get; set; }
		
        #endregion
    }
}