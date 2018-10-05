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
#endregion

namespace Cmp03.DataAccess
{
    public partial class Proveedor_AD : Base
    {
        #region Métodos Públicos Generales

        public List<Tb_Maestras> List_TipoPersona()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_TIPO_PERSOMA"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["ID"]), Descripcion = vRdr["DESCRIPCION"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_TipoDocProveedor()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_LISTA_TIPO_DOC_IDENTIDAD"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Id_Maestras = Convert.ToInt32(vRdr["ID"]), Descripcion = vRdr["DESCRIPCION"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Proveedores> List(string vFiltro)
        {
            List<Proveedores> vLista = new List<Proveedores>();
            using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
            {
                using (SqlCommand vCmd = new SqlCommand("DBO.DIN_SP_LISTA_PROVEEDORES", vCnn))
                {
                    vCmd.CommandType = CommandType.StoredProcedure;
                    vCmd.Parameters.AddWithValue("@FILTRO", vFiltro);
                    vCnn.Open();
                    using (SqlDataReader vRdr = vCmd.ExecuteReader())
                    {
                        if (vRdr.HasRows)
                        {
                            while (vRdr.Read())
                            {
                                var Temp = new Proveedores();
                                Temp.Codigo = Convert.ToString(vRdr["Ruc"]);
                                Temp.RazonSocial = Convert.ToString(vRdr["Proveedor"]);
                                Temp.Direccion = Convert.ToString(vRdr["Direccion"]);
                                vLista.Add(Temp);
                            }
                        }
                    }
                    vCnn.Close();
                    vCmd.Dispose(); AdoNet.Dispose();
                }
            }
            return vLista;
        }

        public int Grabar(Proveedores vProveedor)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        SqlCommand vCmd2 = new SqlCommand("DIN_SP_REGISTRO_PROVEEDOR", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@TipoPersona", vProveedor.TipoPersona);
                        vCmd2.Parameters.AddWithValue("@NroDocumento", vProveedor.NroDocumento);
                        vCmd2.Parameters.AddWithValue("@TipoDocumento", vProveedor.TipoDocumento);
                        vCmd2.Parameters.AddWithValue("@RazonSocial", vProveedor.RazonSocial);
                        vCmd2.Parameters.AddWithValue("@ApellidoPaterno", vProveedor.ApellidoPaterno);
                        vCmd2.Parameters.AddWithValue("@ApellidoMaterno", vProveedor.ApellidoMaterno);
                        vCmd2.Parameters.AddWithValue("@PrimerNombre", vProveedor.PrimerNombre);
                        vCmd2.Parameters.AddWithValue("@SegundoNombre", vProveedor.SegundoNombre);
                        vCmd2.Parameters.AddWithValue("@Direccion", vProveedor.Direccion);
                        vCmd2.Parameters.AddWithValue("@Departamento", vProveedor.Departamento);
                        vCmd2.Parameters.AddWithValue("@Provincia", vProveedor.Provincia);
                        vCmd2.Parameters.AddWithValue("@Distrito", vProveedor.Distrito);
                        vRst = Convert.ToInt32(vCmd2.ExecuteScalar());
                        if (vRst == 0)
                        {
                            txscope.Complete();
                            vCnn.Close();
                            return 1;
                        }
                        txscope.Dispose();
                        return 0;
                    }
                }
                catch (Exception)
                {
                    txscope.Dispose();
                    return 0;
                }
            }
        }

        #endregion
    }
}