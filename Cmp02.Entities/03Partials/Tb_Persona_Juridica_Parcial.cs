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
    public partial class Tb_Persona_Juridica : Base
    {
        #region Peticiones

        public Tb_Persona_Juridica() { }

        public Tb_Persona_Juridica(System.Data.IDataReader Reader)
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

        }

        #endregion

        #region Atributos Adicionales

        #endregion
    }
}