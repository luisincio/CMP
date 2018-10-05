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
    public partial class Tb_Persona_Imagen
    {
        #region Atributos Básicos

        [DataMember]
		public int Id_Persona { get; set; }
        [DataMember]
        public int Id_Tipo_Imagen { get; set; }
		[DataMember]
        public byte[] Foto { get; set; }
		
        #endregion
    }
}