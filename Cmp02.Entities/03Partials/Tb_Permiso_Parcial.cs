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
    public partial class Tb_Permiso : Base
    {
        #region Peticiones

        public Tb_Permiso() { }

        public Tb_Permiso(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERMISO")) Id_Permiso = Convert.ToInt32(Reader["ID_PERMISO"]);
            if (ReadCol.Exist(Reader, "ETIQUETA")) Etiqueta = Convert.ToString(Reader["ETIQUETA"]);
            if (ReadCol.Exist(Reader, "ACCION")) Accion = Convert.ToString(Reader["ACCION"]);
            if (ReadCol.Exist(Reader, "CONTROLADORA")) Controladora = Convert.ToString(Reader["CONTROLADORA"]);
            if (ReadCol.Exist(Reader, "DESCRIPCION")) Descripcion = Convert.ToString(Reader["DESCRIPCION"]);
            if (ReadCol.Exist(Reader, "FLG_ACTIVO")) Flg_Activo = Convert.ToString(Reader["FLG_ACTIVO"]);
            if (ReadCol.Exist(Reader, "USU_INGRESO")) Usu_Ingreso = Convert.ToString(Reader["USU_INGRESO"]);
            if (ReadCol.Exist(Reader, "FEC_INGRESO")) Fec_Ingreso = Convert.ToDateTime(Reader["FEC_INGRESO"]);
            if (ReadCol.Exist(Reader, "USU_MODIFICA")) Usu_Modifica = Convert.ToString(Reader["USU_MODIFICA"]);
            if (ReadCol.Exist(Reader, "FEC_MODIFICA")) Fec_Modifica = Convert.ToDateTime(Reader["FEC_MODIFICA"]);
            if (ReadCol.Exist(Reader, "EXISTE")) Seleccionado = Convert.ToBoolean(Reader["EXISTE"]);
            if (ReadCol.Exist(Reader, "PERFIL")) Perfil = Convert.ToString(Reader["PERFIL"]);
        }

        #endregion

        #region Atributos Adicionales
        [DataMember]
        public bool Seleccionado { get; set; }
        [DataMember]
        public int Id_Usuario { get; set; }
        [DataMember]
        public string Perfil { get; set; }
        #endregion
    }
}