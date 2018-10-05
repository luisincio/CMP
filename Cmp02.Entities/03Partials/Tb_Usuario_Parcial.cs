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
using System.ComponentModel.DataAnnotations;
#endregion

namespace Cmp02.Entities
{
    public partial class Tb_Usuario : Base
    {
        #region Peticiones

        public Tb_Usuario() { }

        public Tb_Usuario(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_USUARIO")) Id_Usuario = Convert.ToInt32(Reader["ID_USUARIO"]);
            if (ReadCol.Exist(Reader, "USUARIO")) Usuario = Convert.ToString(Reader["USUARIO"]);
            if (ReadCol.Exist(Reader, "CONTRASEÑA")) Contraseña = Convert.ToString(Reader["CONTRASEÑA"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);

            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) Nombre_Completo = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "NRO_DOCUMENTO")) Nro_Documento = Convert.ToString(Reader["NRO_DOCUMENTO"]);
            if (ReadCol.Exist(Reader, "ID_PERFIL")) Id_Perfil = Convert.ToInt32(Reader["ID_PERFIL"]);
            if (ReadCol.Exist(Reader, "ID_CONSEJO_REGIONAL")) Id_Consejo_Regional = Convert.ToInt32(Reader["ID_CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "CONSEJO_REGIONAL")) Consejo_Regional = Convert.ToString(Reader["CONSEJO_REGIONAL"]);
            if (ReadCol.Exist(Reader, "CONSEJO_NOMBRE")) Consejo_Nombre = Convert.ToString(Reader["CONSEJO_NOMBRE"]);
            if (ReadCol.Exist(Reader, "CLASE")) Clase = Convert.ToString(Reader["CLASE"]);
        }

        #endregion

        #region Atributos Adicionales
        [DataMember]
        public string Nombre_Completo { get; set; }
        [DataMember]
        public string Nro_Documento { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar la clave")]
        [StringLength(20, ErrorMessage = "La clave no debe pasar los 20 caracteres")]
        public string Confirmacion { get; set; }
        [DataMember]
        public int Id_Perfil { get; set; }
        [DataMember]
        public int Id_Consejo_Regional { get; set; }
        [DataMember]
        public string Consejo_Regional { get; set; }
        [DataMember]
        public string Consejo_Nombre { get; set; }
        [DataMember]
        public string Clase { get; set; }
        #endregion
    }
}