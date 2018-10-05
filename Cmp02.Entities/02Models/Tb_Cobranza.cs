/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Cmp02.Entities
{
    [DataContract]
    [Serializable]
    public partial class Tb_Cobranza
    {
        #region Atributos Básicos

        [DataMember]
        public int Id_Cobro { get; set; }
        [DataMember]
        public int Id_Colegiado { get; set; }
        [DataMember]
        public int Id_Estado_Colegiado { get; set; }
        [DataMember]
        public string Colegiatura { get; set; }
        [DataMember]
        public int Año { get; set; }
        [DataMember]
        public int Mes { get; set; }
        [DataMember]
        public int Id_Servicio { get; set; }
        [DataMember]
        public decimal Descuento { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime? Fecha_Envio { get; set; }
        [DataMember]
        public DateTime? Fecha_Recibido { get; set; }
        [DataMember]
        public DateTime? Fecha_Pagado { get; set; }
        [DataMember]
        public int? Id_Comprobante { get; set; }
        [DataMember]
        public string Flg_VaPagar { get; set; }
        #endregion
    }
}