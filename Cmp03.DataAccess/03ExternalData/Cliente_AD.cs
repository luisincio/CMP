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
    public partial class Cliente_AD : Base
    {
        #region Métodos Públicos Generales

        public int Grabar(ClienteNJ vCliente)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        SqlCommand vCmd2 = new SqlCommand("DIN_SP_REGISTRO_CLIENTE", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@TipoPersona", vCliente.TipoPersona);
                        vCmd2.Parameters.AddWithValue("@NroDocumento", vCliente.NroDocumento);
                        vCmd2.Parameters.AddWithValue("@TipoDocumento", vCliente.TipoDocumento);
                        vCmd2.Parameters.AddWithValue("@RazonSocial", vCliente.RazonSocial);
                        vCmd2.Parameters.AddWithValue("@ApellidoPaterno", vCliente.ApellidoPaterno);
                        vCmd2.Parameters.AddWithValue("@ApellidoMaterno", vCliente.ApellidoMaterno);
                        vCmd2.Parameters.AddWithValue("@PrimerNombre", vCliente.PrimerNombre);
                        vCmd2.Parameters.AddWithValue("@SegundoNombre", vCliente.SegundoNombre);
                        vCmd2.Parameters.AddWithValue("@Direccion", vCliente.Direccion);
                        vCmd2.Parameters.AddWithValue("@Departamento", vCliente.Departamento);
                        vCmd2.Parameters.AddWithValue("@Provincia", vCliente.Provincia);
                        vCmd2.Parameters.AddWithValue("@Distrito", vCliente.Distrito);
                        
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

        #region Grabar Cmp Clover

        public int GrabarDatos(ClienteClover vCliente)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        SqlCommand vCmd2 = new SqlCommand("usp_SS_RM_taUpdateCreateCustomerRcd", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@CUSTNMBR", vCliente.NroDocumento);
                        vCmd2.Parameters.AddWithValue("@CUSTNAME", vCliente.NombreCompleto);
                        vCmd2.Parameters.AddWithValue("@CUSTCLAS", vCliente.Clase);
                        vCmd2.Parameters.AddWithValue("@COUNTRY", vCliente.Pais);
                        vCmd2.Parameters.AddWithValue("@Departamento", vCliente.Departamento);
                        vCmd2.Parameters.AddWithValue("@Provincia", vCliente.Provincia);
                        vCmd2.Parameters.AddWithValue("@Distrito", vCliente.Distrito);
                        vCmd2.Parameters.AddWithValue("@Direccion1", vCliente.Direccion1);
                        vCmd2.Parameters.AddWithValue("@Direccion2", vCliente.Direccion2);
                        vCmd2.Parameters.AddWithValue("@Telefono1", vCliente.Celular);
                        vCmd2.Parameters.AddWithValue("@Telefono2", vCliente.Celular);
                        vCmd2.Parameters.AddWithValue("@Telefono3", vCliente.Celular);
                        vCmd2.Parameters.AddWithValue("@CorreoElectronico", vCliente.Email);
                        vCmd2.Parameters.AddWithValue("@TipoPersona", vCliente.TipoPersona);
                        vCmd2.Parameters.AddWithValue("@TipoDocumento", vCliente.TipoDocumento);
                        vCmd2.Parameters.AddWithValue("@PrimerNombre", vCliente.PrimerNombre);
                        vCmd2.Parameters.AddWithValue("@SegundoNombre", vCliente.SegundoNombre);
                        vCmd2.Parameters.AddWithValue("@ApellidoPaterno", vCliente.ApellidoPaterno);
                        vCmd2.Parameters.AddWithValue("@ApellidoMaterno", vCliente.ApellidoMaterno);
                        vCmd2.Parameters.AddWithValue("@FormaPago", vCliente.FormaPago.Trim());
                        vCmd2.Parameters.AddWithValue("@DefUsuario1", vCliente.Colegiado);

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
                catch (Exception ex)
                {
                    txscope.Dispose();
                    return 0;
                }
            }
        }


        public List<ClienteClover> List_Cliente(string vValor)
        {
            List<ClienteClover> vLista = new List<ClienteClover>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_GP"))
            {
                vCmd.Parameters.AddWithValue("@Valor", vValor);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new ClienteClover(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose();
                AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Direccion(string vIdCliente)
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_DIRECCIONCLIENTE_GP"))
            {
                vCmd.Parameters.AddWithValue("@IdCliente", vIdCliente);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Descripcion = vRdr["DESCRIPCION"].ToString(), Valor1 = vRdr["ID"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        #endregion
    }
}