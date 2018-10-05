/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Recibodetalle_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Recibodetalle
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 05/07/2017
Métodos           : List, GetRegistry, Insert, Update, Delete   
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using Cmp01.Utilities;
using System;
using System.Collections.Generic;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Recibodetalle_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Recibodetalle
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Recibodetalle</returns>
        public List<Tb_Comprobantedetalle> List(int vIdRecibo)
        {
            try
            {
                return new Tb_Recibodetalle_AD().List(vIdRecibo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Recibodetalle basado en su clave primaria
        /// </summary>
        /// <param name="Id_Detalle">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Comprobantedetalle GetRegistry(int vId_Detalle)
        {
            try
            {
                return new Tb_Recibodetalle_AD().GetRegistry(vId_Detalle);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Recibodetalle
        /// </summary>
        /// <param name="Tb_Recibodetalle">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Comprobantedetalle Insert(Tb_Comprobantedetalle vTb_Recibodetalle)
        {
            try
            {
                return new Tb_Recibodetalle_AD().Insert(vTb_Recibodetalle);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Recibodetalle
        /// </summary>
        /// <param name="Tb_Recibodetalle">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Comprobantedetalle Update(Tb_Comprobantedetalle vTb_Recibodetalle)
        {
            try
            {
                return new Tb_Recibodetalle_AD().Update(vTb_Recibodetalle);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Recibodetalle en base a su clave primaria
        /// </summary>
        /// <param name="Id_Detalle">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Detalle, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Recibodetalle_AD().Delete(vId_Detalle, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Procesar_Pedido(string vServicios, int vId)
        {
            int vEstado = 0;
            //int vTieneMatricula = new Tb_Comprobantecabecera_LN().Tiene_Matricula(vId);
            string[] array = vServicios.Split(',');

            //using (TransactionScope tx = new TransactionScope())
            //{
            foreach (var item in array)
            {
                var arrayValores = item.Split('|');
                string IdArticulo = arrayValores[0];

                //Tb_Servicios Temp = new Tb_Servicios_AD().GetRegistry(Convert.ToInt32(IdArticulo));
                Articulo Temp = new Articulos_AD().Get_Articulo("VENTA", IdArticulo);
                int Cantidad = Convert.ToInt32(arrayValores[1]);

                new Tb_Recibodetalle_AD().Insert(new Tb_Comprobantedetalle()
                {
                    Cantidad = Cantidad,
                    Codigo_Servicio = Temp.Codigo,
                    Descripcion = Temp.Descripcion,
                    Descuento = 0,
                    Fec_Ingreso = Variables.Hoy,
                    Fec_Modifica = Variables.Hoy,
                    Flg_Activo = Variables.Activo,
                    Id_Comprobante = vId,
                    Id_Servicio = Temp.IdArticulo,
                    Precio = Temp.PrecioUnitario,
                    Monto = Temp.PrecioUnitario * Cantidad,
                    Igv = ((Temp.PrecioUnitario * Cantidad) * Variables.Igv),
                    Subtotal = (Temp.PrecioUnitario * Cantidad) + ((Temp.PrecioUnitario * Cantidad) * Variables.Igv)
                });
            }

            vEstado = new Tb_Recibocabecera_AD().Actualizar_Montos(vId);

            return vEstado;
            //    tx.Complete();
            //}
        }

        public bool UpdateServicio(int vId, string vDescripcion)
        {
            try
            {
                var vTemp = new Tb_Recibodetalle_AD().GetRegistry(vId);
                vTemp.Descripcion = vDescripcion;
                new Tb_Recibodetalle_AD().Update(vTemp);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateMonto(int vId, decimal vMonto)
        {
            try
            {
                var vTemp = new Tb_Recibodetalle_AD().GetRegistry(vId);
                vTemp.Monto = vMonto;
                new Tb_Recibodetalle_AD().Update(vTemp);

                new Tb_Recibocabecera_AD().Actualizar_Montos(vId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
