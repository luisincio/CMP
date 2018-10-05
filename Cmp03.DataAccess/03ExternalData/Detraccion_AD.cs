/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Recepcion_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase de GP
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp02.Entities;
using Utildatatool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cmp01.Utilities;
#endregion

namespace Cmp03.DataAccess
{
    public partial class Detraccion_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de DetraccionComprobantes
        /// </summary>
        /// <returns>Listado de DetraccionComprobantes</returns>
        public List<DetraccionComprobantes> List(int vId_Clciente)
        {
            List<DetraccionComprobantes> vLista = new List<DetraccionComprobantes>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COMPROBANTECABECERA_DETRACCION"))
            {
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vId_Clciente);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new DetraccionComprobantes(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        #endregion
    }
}