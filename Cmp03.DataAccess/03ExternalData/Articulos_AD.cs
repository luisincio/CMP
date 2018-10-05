/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Articulos_AD.cs
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
#endregion

namespace Cmp03.DataAccess
{
    public partial class Articulos_AD : Base
    {
        #region Métodos Públicos Generales

        public List<Articulo> List_Articulo(string vTipoOperacion, string vFiltro, string vConsejo,int origen,string Documento,string TipoArticulo)
        {
            List<Articulo> vLista = new List<Articulo>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_ARTICULOS"))
            {
                vCmd.Parameters.AddWithValue("@Tipo", vTipoOperacion);
                vCmd.Parameters.AddWithValue("@Filtro", vFiltro);
                vCmd.Parameters.AddWithValue("@CentroCosto", vConsejo);
                vCmd.Parameters.AddWithValue("@Origen", origen);
                vCmd.Parameters.AddWithValue("@Documento", Documento);
                vCmd.Parameters.AddWithValue("@TipoArticulo", TipoArticulo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    //if (vRdr)
                    //{
                        while (vRdr.Read())
                        {
                            vLista.Add(new Articulo(vRdr));
                        }
                    //}
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose();
                AdoGP.Dispose();
            }
            return vLista;
        }

        public Articulo Get_Articulo(string vTipoOperacion, string vFiltro)
        {
            Articulo vLista = new Articulo();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_OBTENER_ARTICULOS"))
            {
                vCmd.Parameters.AddWithValue("@Tipo", vTipoOperacion);
                vCmd.Parameters.AddWithValue("@Filtro", vFiltro);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vLista = new Articulo(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose();
                AdoNet.Dispose();
            }
            return vLista;
        }

        #endregion
    }
}