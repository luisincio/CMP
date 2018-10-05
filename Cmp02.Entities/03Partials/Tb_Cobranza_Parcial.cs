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
#endregion

namespace Cmp02.Entities
{
    public partial class Tb_Cobranza : Base
    {
        #region Peticiones

        public Tb_Cobranza() { }

        public Tb_Cobranza(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_COBRO")) Id_Cobro = Convert.ToInt32(Reader["ID_COBRO"]);
            if (ReadCol.Exist(Reader, "ID_COLEGIADO")) Id_Colegiado = Convert.ToInt32(Reader["ID_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO_COLEGIADO")) Id_Estado_Colegiado = Convert.ToInt32(Reader["ID_ESTADO_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "COLEGIATURA")) Colegiatura = Convert.ToString(Reader["COLEGIATURA"]);
            if (ReadCol.Exist(Reader, "AÑO")) Año = Convert.ToInt32(Reader["AÑO"]);
            if (ReadCol.Exist(Reader, "MES")) Mes = Convert.ToInt32(Reader["MES"]);
            if (ReadCol.Exist(Reader, "ID_SERVICIO")) Id_Servicio = Convert.ToInt32(Reader["ID_SERVICIO"]);
            if (ReadCol.Exist(Reader, "DESCUENTO")) Descuento = Convert.ToDecimal(Reader["DESCUENTO"]);
            if (ReadCol.Exist(Reader, "MONTO")) Monto = Convert.ToDecimal(Reader["MONTO"]);
            if (ReadCol.Exist(Reader, "FECHA")) Fecha = Convert.ToDateTime(Reader["FECHA"]);
            if (ReadCol.Exist(Reader, "FECHA_ENVIO")) Fecha_Envio = Convert.ToDateTime(Reader["FECHA_ENVIO"]);
            if (ReadCol.Exist(Reader, "FECHA_RECIBIDO")) Fecha_Recibido = Convert.ToDateTime(Reader["FECHA_RECIBIDO"]);
            if (ReadCol.Exist(Reader, "FECHA_PAGADO")) Fecha_Pagado = Convert.ToDateTime(Reader["FECHA_PAGADO"]);
            if (ReadCol.Exist(Reader, "ID_COMPROBANTE")) Id_Comprobante = Convert.ToInt32(Reader["ID_COMPROBANTE"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);

            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "SERVICIO")) Servicio = Convert.ToString(Reader["SERVICIO"]);
            if (ReadCol.Exist(Reader, "CONSEJO_REGIONAL")) Consejo_Regional = Convert.ToString(Reader["CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO_REGIONAL")) Id_Consejo_Regional = Convert.ToInt32(Reader["ID_CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "ID_ENTIDAD_PAGA")) Id_Entidad_Paga = Convert.ToInt32(Reader["ID_ENTIDAD_PAGA"]);
        }

        #endregion

        #region Atributos Adicionales
        [DataMember]
        public string Nombre_Completo { get; set; }
        [DataMember]
        public string Nro_Documento { get; set; }
        [DataMember]
        public string Servicio { get; set; }
        [DataMember]
        public string Consejo_Regional { get; set; }
        [DataMember]
        public int Id_Consejo_Regional { get; set; }
        [DataMember]
        public int Id_Entidad_Paga { get; set; }
        [DataMember]
        public string Nro_Recibo { get; set; }

        #endregion
    }
}