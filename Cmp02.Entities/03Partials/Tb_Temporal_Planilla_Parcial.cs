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
    public partial class Tb_Temporal_Planilla : Base
    {
        #region Peticiones

        public Tb_Temporal_Planilla() { }

        public Tb_Temporal_Planilla(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_SEGURO")) Id_Seguro = Convert.ToString(Reader["ID_SEGURO"]);
            if (ReadCol.Exist(Reader, "NRO_RECIBO")) Nro_Recibo = Convert.ToString(Reader["NRO_RECIBO"]);

            if (ReadCol.Exist(Reader, "ID_CONSEJO")) Id_Consejo = Convert.ToInt32(Reader["ID_CONSEJO"]);
            if (ReadCol.Exist(Reader, "ID_ENTIDADPAGADORA")) Id_EntidadPagadora = Convert.ToInt32(Reader["ID_ENTIDADPAGADORA"]);
            if (ReadCol.Exist(Reader, "ID_COLEGIADO")) Id_Colegiado = Convert.ToString(Reader["ID_COLEGIADO"]);
            if (ReadCol.Exist(Reader, "DNI")) Dni = Convert.ToString(Reader["DNI"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "MOVIMIENTO")) Movimiento = Convert.ToString(Reader["MOVIMIENTO"]);
            if (ReadCol.Exist(Reader, "IMPORTE")) Importe = Convert.ToDecimal(Reader["IMPORTE"]);
            if (ReadCol.Exist(Reader, "PERIODO")) Periodo = Convert.ToString(Reader["PERIODO"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);

            if (ReadCol.Exist(Reader, "PAGINA")) Pagina = Convert.ToInt32(Reader["PAGINA"]);
            if (ReadCol.Exist(Reader, "TOTAL")) Total_Reg = Convert.ToInt32(Reader["TOTAL"]);
            if (ReadCol.Exist(Reader, "TOTAL_PAGINAS")) Total_Pag = Convert.ToInt32(Reader["TOTAL_PAGINAS"]);
            if (ReadCol.Exist(Reader, "MONTO_TOTAL")) Monto_Total = Convert.ToDecimal(Reader["MONTO_TOTAL"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public decimal? Monto_Total { get; set; }  


        #endregion
    }
}