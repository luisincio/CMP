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
    public partial class Tb_Persona_Imagen : Base
    {
        #region Peticiones

        public Tb_Persona_Imagen() { }

        public Tb_Persona_Imagen(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "ID_PERSONA")) Id_Persona = Convert.ToInt32(Reader["ID_PERSONA"]);
            if (ReadCol.Exist(Reader, "ID_TIPO_IMAGEN")) Id_Tipo_Imagen = Convert.ToInt32(Reader["ID_TIPO_IMAGEN"]);
            if (ReadCol.Exist(Reader, "FOTO")) Foto = (byte[])Reader["FOTO"];
        }

        #endregion

        #region Atributos Adicionales

        #endregion
    }
}