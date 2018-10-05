/*----------------------------------------------------------------------------------------
ARCHIVO MODELO    : Entidad
Objetivo          : Clase Parcial entidad que identifica a la tabla de la base de datos
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using System;
using Utildatatool;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Cmp02.Entities
{
    public partial class Tb_Comprobantecabecera : Base
    {
        #region Peticiones

        public Tb_Comprobantecabecera() { }

        public Tb_Comprobantecabecera(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_COMPROBANTE")) Id_Comprobante = Convert.ToInt32(Reader["ID_COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_DOCUMENTOSUNAT")) Tipo_Documentosunat = Convert.ToInt32(Reader["ID_TIPO_DOCUMENTOSUNAT"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "NRODOCUMENTO_GP")) Nrodocumento_Gp = Convert.ToString(Reader["NRODOCUMENTO_GP"]);
            if (ReadCol.Exist(Reader, "ID_CLIENTEPAGADOR")) Id_Clientepagador = Convert.ToInt32(Reader["ID_CLIENTEPAGADOR"]);
            if (ReadCol.Exist(Reader, "RAZONSOCIAL")) Razonsocial = Convert.ToString(Reader["RAZONSOCIAL"]);
            if (ReadCol.Exist(Reader, "ID_COLEGIADO")) Id_Colegiado = Convert.ToInt32(Reader["ID_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "COLEGIATURA")) Colegiatura = Convert.ToString(Reader["COLEGIATURA"]);
            if (ReadCol.Exist(Reader, "APELLIDOS_COLEGIADO")) Apellidos_Colegiado = Convert.ToString(Reader["APELLIDOS_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "NOMBRES_COLEGIADO")) Nombres_Colegiado = Convert.ToString(Reader["NOMBRES_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "ID_MONEDA")) Id_Moneda = Convert.ToInt32(Reader["ID_MONEDA"]);
            if (ReadCol.Exist(Reader, "ID_SITIO_DESTINO")) Id_Sitio_Destino = Convert.ToInt32(Reader["ID_SITIO_DESTINO"]);
            if (ReadCol.Exist(Reader, "ID_SITIO_ORIGEN")) Id_Sitio_Origen = Convert.ToInt32(Reader["ID_SITIO_ORIGEN"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_PAGO")) Id_Tipo_Pago = Convert.ToInt32(Reader["ID_TIPO_PAGO"]);
            if (ReadCol.Exist(Reader, "OBSERVACION")) Observacion = Convert.ToString(Reader["OBSERVACION"]);
            if (ReadCol.Exist(Reader, "MONTO")) Monto = Convert.ToDecimal(Reader["MONTO"]);
            if (ReadCol.Exist(Reader, "IGV")) Igv = Convert.ToDecimal(Reader["IGV"]);
            if (ReadCol.Exist(Reader, "DESCUENTO")) Descuento = Convert.ToDecimal(Reader["DESCUENTO"]);
            if (ReadCol.Exist(Reader, "TOTAL")) Total = Convert.ToDecimal(Reader["TOTAL"]);
            if (ReadCol.Exist(Reader, "EQUIPO")) Equipo = Convert.ToString(Reader["EQUIPO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO_COMPROBANTE")) Id_EstadoComprobante = Convert.ToInt32(Reader["ID_ESTADO_COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "DNI")) DNI = Convert.ToString(Reader["DNI"]);
            if (ReadCol.Exist(Reader, "RUC")) RUC = Convert.ToString(Reader["RUC"]);
            if (ReadCol.Exist(Reader, "COMPROBANTE")) Comprobante = Convert.ToString(Reader["COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "DETALLE_COMPROBANTE")) Detalle_Comprobante = Convert.ToString(Reader["DETALLE_COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "SERIE")) Serie = Convert.ToInt32(Reader["SERIE"]);
            if (ReadCol.Exist(Reader, "DIRECCIÓN")) Direccion = Convert.ToString(Reader["DIRECCIÓN"]);
            if (ReadCol.Exist(Reader, "FECHA_RECIBO")) Fecha = Convert.ToDateTime(Reader["FECHA_RECIBO"]);
            if (ReadCol.Exist(Reader, "NRO_CHEQUE")) Nro_Cheque = Convert.ToString(Reader["NRO_CHEQUE"]);
            if (ReadCol.Exist(Reader, "FECHA_VENCIMIENTO")) Fecha_Vencimiento = Convert.ToDateTime(Reader["FECHA_VENCIMIENTO"]);
            if (ReadCol.Exist(Reader, "ID_CONDICIONPAGO")) Id_CondicionPago = Convert.ToString(Reader["ID_CONDICIONPAGO"]);
            if (ReadCol.Exist(Reader, "ESTADO")) Estado = Convert.ToString(Reader["ESTADO"]);

            if (ReadCol.Exist(Reader, "ID_CHEQUERA")) Id_Chequera = Convert.ToString(Reader["ID_CHEQUERA"]);
            if (ReadCol.Exist(Reader, "CORREO")) Correo = Convert.ToString(Reader["CORREO"]);
            if (ReadCol.Exist(Reader, "CELULAR")) Celular = Convert.ToString(Reader["CELULAR"]);
            
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        [StringLength(11, ErrorMessage = "El número de RUC no debe pasar los 11 caracteres")]
        public string RUC { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el número de DNI")]
        [StringLength(10, ErrorMessage = "El número de DNI no debe psar los 10 caracteres")]
        public string DNI { get; set; }
        public List<Tb_Comprobantedetalle> Detalle { get; set; }

        [DataMember]
        public string Comprobante { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Nro_Cheque { get; set; }

        [DataMember]
        public DateTime Fecha_Vencimiento { get; set; }

        [DataMember]
        public string Cta_Contable { get; set; }

        [DataMember]
        public string Detalle_Comprobante { get; set; }

        [DataMember]
        public string Estado { get; set; }
        
        #endregion
    }
}