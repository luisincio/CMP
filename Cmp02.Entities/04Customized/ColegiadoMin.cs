using System;
using System.Runtime.Serialization;
using Utildatatool;

namespace Cmp02.Entities
{
    public class ColegiadoMin: Tb_Persona
    {
        [DataMember]
        public string Colegiado { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Tipo_Documento { get; set; }
        [DataMember]
        public string Nro_Documento { get; set; }
        [DataMember]
        public DateTime Fecha_Fin { get; set; }
        [DataMember]
        public int Id_Consejo_Regional { get; set; }
        [DataMember]
        public int Id_Estado { get; set; }
        [DataMember]
        public string Correo { get; set; }

        public ColegiadoMin(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_PERSONA")) Id_Tipo_Persona = Convert.ToString(Reader["ID_TIPO_PERSONA"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMERCIAL")) Nombre_Comercial = Convert.ToString(Reader["NOMBRE_COMERCIAL"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "RUC")) Ruc = Convert.ToString(Reader["RUC"]);
            if (ReadCol.Exist(Reader, "FLG_NACIONALIDAD")) Flg_Nacionalidad = Convert.ToString(Reader["FLG_NACIONALIDAD"]);
            if (ReadCol.Exist(Reader, "COLEGIADO")) Colegiado = Convert.ToString(Reader["COLEGIADO"]);
            if (ReadCol.Exist(Reader, "TIPO_DOCUMENTO")) Tipo_Documento = Convert.ToString(Reader["TIPO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "DIRECCION")) Direccion = Convert.ToString(Reader["DIRECCION"]);
            if (ReadCol.Exist(Reader, "ESTADO")) Estado = Convert.ToString(Reader["ESTADO"]);
            if (ReadCol.Exist(Reader, "ID_ESTADO")) Id_Estado = Convert.ToInt32(Reader["ID_ESTADO"]);

            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);

            if (ReadCol.Exist(Reader, "FECHA_TERMINO")) Fecha_Fin = Convert.ToDateTime(Reader["FECHA_TERMINO"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO_REGIONAL")) Id_Consejo_Regional = Convert.ToInt32(Reader["ID_CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "CORREO")) Correo = Convert.ToString(Reader["CORREO"]);
        }
    }
}
