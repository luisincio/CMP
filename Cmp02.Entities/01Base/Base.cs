/*----------------------------------------------------------------------------------------
ARCHIVO CLASE   : Base.cs
Objetivo        : Clase base donde se extenderá las clases parciales
Autor           : Omar Rodriguez Muñoz (FRR)
Fecha Creación  : 17/02/2017
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public class Base
    {
        #region Atributos Extendidos
        //[DataMember]
        //public int Item { get; set; }
        //[DataMember]
        //public int Registros { get; set; }
        [DataMember]
        public int Pagina { get; set; }
        [DataMember]
        public int Total_Reg { get; set; }
        [DataMember]
        public int Total_Pag { get; set; }
        [DataMember]
        public string Flg_Activo { get; set; }
        [DataMember]
        public DateTime Fec_Ingreso { get; set; }
        [DataMember]
        public string Usu_Ingreso { get; set; }
        [DataMember]
        public DateTime Fec_Modifica { get; set; }
        [DataMember]
        public string Usu_Modifica { get; set; }
        [DataMember]
        public string Opcional { get; set; }

        #endregion
    }
}
