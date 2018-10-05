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
    public partial class Tb_Comprobantecabecera
    {
        #region Atributos Básicos

        [DataMember]  
		public int Id_Comprobante { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su tipo de documento")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un tipo de documeto")]
		public int Tipo_Documentosunat { get; set; }  
		[DataMember]
        //[Required(ErrorMessage = "Debe ingresar el Nro. de documento")]
        [StringLength(20, ErrorMessage = "El número de documento no debe pasar los 20 caracteres")]
		public string Nro_Documento { get; set; }  
		[DataMember]  
		public string Nrodocumento_Gp { get; set; }  
		[DataMember]
		public int Id_Clientepagador { get; set; }  
		[DataMember]  
		public string Razonsocial { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su cliente")]
		public int Id_Colegiado { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su colegiatura")]
		public string Colegiatura { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar los Apellidos")]
        [StringLength(100, ErrorMessage = "Los Apellidos no debe pasar los 100 caracteres")]
		public string Apellidos_Colegiado { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar los Nombres")]
        [StringLength(100, ErrorMessage = "Los Nombres no debe pasar los 100 caracteres")]
		public string Nombres_Colegiado { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su tipo de moneda")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un tipo de moneda")]
		public int Id_Moneda { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su destino")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un destino")]
		public int Id_Sitio_Destino { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar su origen")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un origen")]
        public int Id_Sitio_Origen { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar su tipo de pago")]
        [Range(1, 1000, ErrorMessage = "Debe Seleccionar un tipo de pago")]
        public int Id_Tipo_Pago { get; set; }  
		[DataMember]  
		public string Observacion { get; set; }  
		[DataMember]  
		public decimal Monto { get; set; }  
		[DataMember]  
		public decimal Igv { get; set; }
        [DataMember]
        public decimal Descuento { get; set; } 
        [DataMember]  
		public decimal Total { get; set; }
        [DataMember]
        public string Equipo { get; set; }
        [DataMember]
        public int Id_EstadoComprobante { get; set; }
        [DataMember]
        public int Serie { get; set; }
        [DataMember]
        public string Id_CondicionPago { get; set; }

        [DataMember]
        public int? Id_Banco { get; set; }
        [DataMember]
        public string Nro_Voucher { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar una chequera destino")]
        public string Id_Chequera { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public int id_referencia { get; set; }
        [DataMember]
        public string referencia { get; set; }
        #endregion
    }
}