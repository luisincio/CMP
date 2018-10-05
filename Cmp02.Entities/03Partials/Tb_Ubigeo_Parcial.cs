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
    public partial class Tb_Ubigeo : Base
    {
        #region Peticiones

        public Tb_Ubigeo() { }

        public Tb_Ubigeo(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_UBIGEO")) Id_Ubigeo = Convert.ToString(Reader["ID_UBIGEO"]);
            if (ReadCol.Exist(Reader, "ID_PAIS")) Id_Pais = Convert.ToInt32(Reader["ID_PAIS"]);
            if (ReadCol.Exist(Reader, "DEPARTAMENTO")) Departamento = Convert.ToString(Reader["DEPARTAMENTO"]);
            if (ReadCol.Exist(Reader, "PROVINCIA")) Provincia = Convert.ToString(Reader["PROVINCIA"]);
            if (ReadCol.Exist(Reader, "DISTRITO")) Distrito = Convert.ToString(Reader["DISTRITO"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "NOMBRE_UBIGEO")) Nombre_Ubigeo = Convert.ToString(Reader["NOMBRE_UBIGEO"]);
        }

        #endregion

        #region Atributos Adicionales

        [DataMember]
        public string Nombre_Ubigeo { get; set; }

        #endregion
    }
}