using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Utildatatool;

namespace Cmp02.Entities
{
    public class EmpresaMin : Tb_Persona_Juridica
    {
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el Ruc")]
        [StringLength(11, ErrorMessage = "El Ruc no debe pasar los 11 caracteres")]
        public string Ruc { get; set; }
        [DataMember]
        public string Direccion_Completa { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar una ubicación geográfica")]
        public string Ubigeo_Nombre { get; set; }


        public EmpresaMin(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_ORIGEN")) Id_Origen_Juridico = Convert.ToInt32(Reader["ID_ORIGEN"]);
            if (ReadCol.Exist(Reader, "ID_GRUPO")) Id_Grupo_Juridico = Convert.ToInt32(Reader["ID_GRUPO"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO")) Id_Consejo_Juridico = Convert.ToInt32(Reader["ID_CONSEJO"]);
            if (ReadCol.Exist(Reader, "RAZON_SOCIAL")) Razon_Social = Convert.ToString(Reader["RAZON_SOCIAL"]);
            if (ReadCol.Exist(Reader, "DIRECCION")) Direccion = Convert.ToString(Reader["DIRECCION"]);
            if (ReadCol.Exist(Reader, "ID_UBIGEO")) Id_Ubigeo = Convert.ToString(Reader["ID_UBIGEO"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "RUC")) Ruc = Convert.ToString(Reader["RUC"]);
            if (ReadCol.Exist(Reader, "DIRECCIONCOMPLETA")) Direccion_Completa = Convert.ToString(Reader["DIRECCIONCOMPLETA"]);
            if (ReadCol.Exist(Reader, "UBIGEO_NOMBRE")) Ubigeo_Nombre = Convert.ToString(Reader["UBIGEO_NOMBRE"]);
        }

        public EmpresaMin() { }
    }
}
