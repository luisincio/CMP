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
    public partial class Tb_Medio_Contacto : Base
    {
        #region Peticiones

        public Tb_Medio_Contacto() { }

        public Tb_Medio_Contacto(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_MEDIO_CONTACTO")) Id_Medio_Contacto = Convert.ToInt32(Reader["ID_MEDIO_CONTACTO"]);
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_MEDIO_CONTACTO")) Id_Tipo_Medio_Contacto = Convert.ToInt32(Reader["ID_TIPO_MEDIO_CONTACTO"]);
            if (ReadCol.Exist(Reader, "NOMBRE_MEDIO_CONTACTO")) Nombre_Medio_Contacto = Convert.ToString(Reader["NOMBRE_MEDIO_CONTACTO"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "TIPOMEDIO_DESCRIPCION")) TipoMedio_Desripcion = Convert.ToString(Reader["TIPOMEDIO_DESCRIPCION"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public string TipoMedio_Desripcion { get; set; }  

        #endregion
    }
}