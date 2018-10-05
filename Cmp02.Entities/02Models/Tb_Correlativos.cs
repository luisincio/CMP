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
    public partial class Tb_Correlativos
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Sucursal { get; set; }  
		[DataMember]  
		public int Id_Tidodocumento { get; set; }  
		[DataMember]  
		public int Serie { get; set; }  
		[DataMember]  
		public int Valor_Actual { get; set; }  
		[DataMember]  
		public int? Inicio { get; set; }  
		[DataMember]  
		public int? Fin { get; set; }  
		[DataMember]  
		public string Id_Documento_GP { get; set; }
        [DataMember]
        public int Id_Persona { get; set; }

        #endregion
    }
}