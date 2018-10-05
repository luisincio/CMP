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
    public partial class Pagos_Manuales_AD : Base
    {
        #region Métodos Públicos Generales

        public string Get_Nro_Documento()
        {
            string vResp = "";
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_OBTENER_CORRELATIVO_PAGOS"))
            {
                vResp = vCmd.ExecuteScalar().ToString();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public List<Tb_Maestras> List_SunatDocumento()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_TIPO_PAGO_SUNAT"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Valor1 = vRdr["IDSUNAT"].ToString(), Descripcion = vRdr["DESCRIPCION"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Maestras> List_Chequera()
        {
            List<Tb_Maestras> vLista = new List<Tb_Maestras>();
            using (SqlCommand vCmd = AdoGP.GetCommand("DBO.DIN_SP_SEL_LISTA_CHEQUERA"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Maestras() { Valor1 = vRdr["idChequera"].ToString(), Descripcion = vRdr["DesChequera"].ToString() });
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public int Grabar(Pagos_Manuales Pagos_Manuales)
        {
            int vRst = 0;
            using (var txscope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (SqlConnection vCnn = new SqlConnection(Cmp01.Utilities.Variables.CnnGP))
                    {
                        vCnn.Open();
                        SqlCommand vCmd2 = new SqlCommand("DIN_SP_INTERFACE_PAGO_MANUAL", vCnn);
                        vCmd2.CommandType = CommandType.StoredProcedure;
                        vCmd2.Parameters.AddWithValue("@LOTE", Pagos_Manuales.Lote);
                        vCmd2.Parameters.AddWithValue("@NROPAGO", Pagos_Manuales.Nropago);
                        vCmd2.Parameters.AddWithValue("@IDPROVEEDOR", Pagos_Manuales.Idproveedor);
                        vCmd2.Parameters.AddWithValue("@NRODOCUMENTO", Pagos_Manuales.Nrodocumento);
                        vCmd2.Parameters.AddWithValue("@FECHAPAGO", Pagos_Manuales.Fechapago);
                        vCmd2.Parameters.AddWithValue("@FORMAPAGO", Pagos_Manuales.Formapago);
                        vCmd2.Parameters.AddWithValue("@TIPOPAGOSUNAT", Pagos_Manuales.Tipopagosunat);
                        vCmd2.Parameters.AddWithValue("@MONEDA", Pagos_Manuales.Moneda);
                        vCmd2.Parameters.AddWithValue("@CHEQUERA", Pagos_Manuales.Chequera);
                        vCmd2.Parameters.AddWithValue("@DESCRIPCION", Pagos_Manuales.Descripcion);
                        vCmd2.Parameters.AddWithValue("@TIPOCAMBOP", Pagos_Manuales.Tipocambop);
                        vCmd2.Parameters.AddWithValue("@MONTO", Pagos_Manuales.Monto);
                        vCmd2.Parameters.AddWithValue("@Consejo", Pagos_Manuales.IdConsejo);
                        
                        vRst = Convert.ToInt32(vCmd2.ExecuteScalar());
                        if (vRst == 0)
                        {
                            txscope.Complete();
                            vCnn.Close();
                            return 1;
                        }
                    }
                    txscope.Dispose();
                    return vRst;
                }
                catch (Exception)
                {
                    txscope.Dispose();
                    return vRst;
                }
            }
        }



        #endregion
    }
}