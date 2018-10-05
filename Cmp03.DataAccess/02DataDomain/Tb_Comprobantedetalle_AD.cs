/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Comprobantedetalle_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Comprobantedetalle
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete
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
    public partial class Tb_Comprobantedetalle_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Comprobantedetalle
        /// </summary>
        /// <returns>Listado de Tb_Comprobantedetalle</returns>
        public List<Tb_Comprobantedetalle> List()
        {
            List<Tb_Comprobantedetalle> vLista = new List<Tb_Comprobantedetalle>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COMPROBANTEDETALLE"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Comprobantedetalle(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Comprobantedetalle basado en su clave primaria
        /// </summary>
        /// <param name="ID_DETALLE">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Comprobantedetalle GetRegistry(int vId_Detalle)
        {
            Tb_Comprobantedetalle vTb_Comprobantedetalle = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COMPROBANTEDETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vId_Detalle);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Comprobantedetalle = new Tb_Comprobantedetalle(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Comprobantedetalle;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Comprobantedetalle
        /// </summary>
        /// <param name="Tb_Comprobantedetalle">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Comprobantedetalle Insert(Tb_Comprobantedetalle vTb_Comprobantedetalle)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COMPROBANTEDETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Comprobantedetalle.Id_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Comprobantedetalle.Id_Servicio);
                vCmd.Parameters.AddWithValue("@CODIGO_SERVICIO", vTb_Comprobantedetalle.Codigo_Servicio);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Comprobantedetalle.Descripcion);
                vCmd.Parameters.AddWithValue("@CANTIDAD", vTb_Comprobantedetalle.Cantidad);
                vCmd.Parameters.AddWithValue("@PRECIO", vTb_Comprobantedetalle.Precio);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Comprobantedetalle.Descuento);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Comprobantedetalle.Monto);
                vCmd.Parameters.AddWithValue("@IGV", vTb_Comprobantedetalle.Igv);
                vCmd.Parameters.AddWithValue("@SUBTOTAL", vTb_Comprobantedetalle.Subtotal);
                vTb_Comprobantedetalle.Id_Detalle = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Comprobantedetalle.Id_Detalle > 0) return vTb_Comprobantedetalle; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Comprobantedetalle
        /// </summary>
        /// <param name="Tb_Comprobantedetalle">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Comprobantedetalle Update(Tb_Comprobantedetalle vTb_Comprobantedetalle)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COMPROBANTEDETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vTb_Comprobantedetalle.Id_Detalle);
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Comprobantedetalle.Id_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Comprobantedetalle.Id_Servicio);
                vCmd.Parameters.AddWithValue("@CODIGO_SERVICIO", vTb_Comprobantedetalle.Codigo_Servicio);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Comprobantedetalle.Descripcion);
                vCmd.Parameters.AddWithValue("@CANTIDAD", vTb_Comprobantedetalle.Cantidad);
                vCmd.Parameters.AddWithValue("@PRECIO", vTb_Comprobantedetalle.Precio);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Comprobantedetalle.Descuento);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Comprobantedetalle.Monto);
                vCmd.Parameters.AddWithValue("@IGV", vTb_Comprobantedetalle.Igv);
                vCmd.Parameters.AddWithValue("@SUBTOTAL", vTb_Comprobantedetalle.Subtotal);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Comprobantedetalle; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Comprobantedetalle en base a su clave primaria
        /// </summary>
        /// <param name="ID_DETALLE">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Detalle, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COMPROBANTEDETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vId_Detalle);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        public List<Tb_Comprobantedetalle> List(int vId_Comprobante,int procesar)
        {
            /*
              procesar = 0  >> Busqueda solo para listar
              procesar = 1  >> Busqueda para procesar en GP
             */
            List<Tb_Comprobantedetalle> vLista = new List<Tb_Comprobantedetalle>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COMPROBANTEDETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                vCmd.Parameters.AddWithValue("@PROCESAR", procesar);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Comprobantedetalle(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public Tb_Comprobantedetalle GetRegistry(int vId_Detalle, int vId_Comprobante, long vId_Servicio,string tipoArt)
        {
            Tb_Comprobantedetalle vTb_Comprobantedetalle = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COMPROBANTEDETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vId_Detalle);
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vId_Servicio);
                vCmd.Parameters.AddWithValue("@TIPO_ARTICULO", tipoArt);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Comprobantedetalle = new Tb_Comprobantedetalle(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Comprobantedetalle;
        }


        public bool UpdateService(int vId, decimal vDescuento, string vUsuario)
        {
            int vRsp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_TB_FACTURA_COBRANZA"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vId);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vDescuento);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vRsp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vRsp >= 0) return true; else return false;
        }

        #endregion
    }
}