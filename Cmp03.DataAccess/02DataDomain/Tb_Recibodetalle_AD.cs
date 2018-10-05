/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Comprobantedetalle_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Comprobantedetalle
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 05/07/2017
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
    public partial class Tb_Recibodetalle_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Comprobantedetalle
        /// </summary>
        /// <returns>Listado de Tb_Comprobantedetalle</returns>
        public List<Tb_Comprobantedetalle> List(int vIdRecibo)
        {
            List<Tb_Comprobantedetalle> vLista = new List<Tb_Comprobantedetalle>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_RECIBODETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vIdRecibo);
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
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_RECIBODETALLE"))
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
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_RECIBODETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Comprobantedetalle.Id_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Comprobantedetalle.Id_Servicio);
                vCmd.Parameters.AddWithValue("@CODIGO_SERVICIO", vTb_Comprobantedetalle.Codigo_Servicio);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Comprobantedetalle.Descripcion);
                vCmd.Parameters.AddWithValue("@CANTIDAD", vTb_Comprobantedetalle.Cantidad);
                vCmd.Parameters.AddWithValue("@PRECIO", vTb_Comprobantedetalle.Precio);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Comprobantedetalle.Monto);
                vCmd.Parameters.AddWithValue("@IGV", vTb_Comprobantedetalle.Igv);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Comprobantedetalle.Descuento);
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
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_RECIBODETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vTb_Comprobantedetalle.Id_Detalle);
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Comprobantedetalle.Id_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Comprobantedetalle.Id_Servicio);
                vCmd.Parameters.AddWithValue("@CODIGO_SERVICIO", vTb_Comprobantedetalle.Codigo_Servicio);
                vCmd.Parameters.AddWithValue("@DESCRIPCION", vTb_Comprobantedetalle.Descripcion);
                vCmd.Parameters.AddWithValue("@CANTIDAD", vTb_Comprobantedetalle.Cantidad);
                vCmd.Parameters.AddWithValue("@PRECIO", vTb_Comprobantedetalle.Precio);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Comprobantedetalle.Monto);
                vCmd.Parameters.AddWithValue("@IGV", vTb_Comprobantedetalle.Igv);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Comprobantedetalle.Descuento);
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
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_RECIBODETALLE"))
            {
                vCmd.Parameters.AddWithValue("@ID_DETALLE", vId_Detalle);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        #endregion
    }
}