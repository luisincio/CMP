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
    public partial class Tb_Correlativos : Base
    {
        #region Peticiones

        public Tb_Correlativos() { }

        public Tb_Correlativos(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_SUCURSAL")) Id_Sucursal = Convert.ToInt32(Reader["ID_SUCURSAL"]);
            if (ReadCol.Exist(Reader, "ID_TIDODOCUMENTO")) Id_Tidodocumento = Convert.ToInt32(Reader["ID_TIDODOCUMENTO"]);
            if (ReadCol.Exist(Reader, "SERIE")) Serie = Convert.ToInt32(Reader["SERIE"]);
            if (ReadCol.Exist(Reader, "VALOR_ACTUAL")) Valor_Actual = Convert.ToInt32(Reader["VALOR_ACTUAL"]);
            if (ReadCol.Exist(Reader, "INICIO")) Inicio = Convert.ToInt32(Reader["INICIO"]);
            if (ReadCol.Exist(Reader, "FIN")) Fin = Convert.ToInt32(Reader["FIN"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "ID_DOCUMENTO_GP")) Id_Documento_GP = Convert.ToString(Reader["ID_DOCUMENTO_GP"]);
            if (ReadCol.Exist(Reader, "OPCIONAL")) Opcional = Convert.ToString(Reader["OPCIONAL"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "NOMBRE_COMPLETO")) NombreCompleto = Convert.ToString(Reader["NOMBRE_COMPLETO"]);
            if (ReadCol.Exist(Reader, "TIPODOCUMENTO")) TipoDocumento = Convert.ToString(Reader["TIPODOCUMENTO"]);
            if (ReadCol.Exist(Reader, "SUCURSAL")) Sucursal = Convert.ToString(Reader["SUCURSAL"]);

        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public string NombreCompleto { get; set; }
        [DataMember]
        public bool Accion { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string Sucursal { get; set; }

        #endregion
    }
}