/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Comprobantedetalle_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Comprobantedetalle
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018
Métodos           : List, GetRegistry, Insert, Update, Delete   
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Cmp03.DataAccess;
using Cmp02.Entities;
using Cmp01.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Comprobantedetalle_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Comprobantedetalle
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Comprobantedetalle</returns>
        public List<Tb_Comprobantedetalle> List()
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Comprobantedetalle basado en su clave primaria
        /// </summary>
        /// <param name="Id_Detalle">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Comprobantedetalle GetRegistry(int vId_Detalle)
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().GetRegistry(vId_Detalle);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Comprobantedetalle
        /// </summary>
        /// <param name="Tb_Comprobantedetalle">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Comprobantedetalle Insert(Tb_Comprobantedetalle vTb_Comprobantedetalle)
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().Insert(vTb_Comprobantedetalle);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Comprobantedetalle
        /// </summary>
        /// <param name="Tb_Comprobantedetalle">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Comprobantedetalle Update(Tb_Comprobantedetalle vTb_Comprobantedetalle)
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().Update(vTb_Comprobantedetalle);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Comprobantedetalle en base a su clave primaria
        /// </summary>
        /// <param name="Id_Detalle">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Detalle, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().Delete(vId_Detalle, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        public List<Tb_Comprobantedetalle> List(int vId_Comprobante)
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().List(vId_Comprobante, 0/*LISTAR PARA MOSTRAR EN VISTA*/);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int Procesar_Pedido(string vServicios, int vId, string vConsejo,string documento , string TipoArticulo)
        {
            int vEstado = 0;
            int vTieneMatricula = new Tb_Comprobantecabecera_LN().Tiene_Matricula(vId);
            string[] array = vServicios.Split(',');
            //using (var Full = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
            try
            {
                foreach (var item in array)
                {
                    var arrayValores = item.Split('|');
                    string IdArticulo = arrayValores[0];
                    

                    if ((vTieneMatricula == 0 && IdArticulo == Variables.Matricula) ||
                        (vTieneMatricula == 0 && IdArticulo != Variables.Matricula) ||
                        (vTieneMatricula > 0 && IdArticulo != Variables.Matricula))
                    {
                        Articulo Temp = new Articulos_AD().List_Articulo("VENTA", IdArticulo, vConsejo,0/*Origen del documento referencia*/, documento, TipoArticulo)[0];
                        
                        int Cantidad = Convert.ToInt32(arrayValores[1]);

                        if (Cantidad > Variables.MaxUnidades)
                        {
                            vEstado = 2;
                            break;
                        }
                        else
                        {
                            Tb_Comprobantedetalle Detalle = null;
                            if (TipoArticulo=="") {
                                Detalle = new Tb_Comprobantedetalle_AD().GetRegistry(0, vId, Temp.IdArticulo, TipoArticulo);
                            }
                            else
                            {
                                Detalle = new Tb_Comprobantedetalle_AD().GetRegistry(0, vId, int.Parse(Temp.Codigo), TipoArticulo);
                            }
                             

                            if (Detalle == null)
                            {
                                new Tb_Comprobantedetalle_AD().Insert(new Tb_Comprobantedetalle()
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
                            else
                            {
                                int TotalArticulos = 0;
                                int Año = 0;
                                int Mes = 0;
                                //List<Tb_Cobranza> vTemp;
                                if (Temp.IdArticulo == Convert.ToInt32(EnumTipoArticuloCuota.CUOTA_PENSION) || Temp.IdArticulo == Convert.ToInt32(EnumTipoArticuloCuota.CUOTA_SEMEFA))
                                {
                                    //TotalArticulos = (from Comp in new Tb_Comprobantedetalle_AD().List(vId) where Comp.Id_Servicio == Temp.IdArticulo && Comp.Flg_Activo == Variables.Activo select Comp).Count();
                                    //vTemp = new Tb_Cobranza_AD().List(vId, Temp.IdArticulo);
                                    //TotalArticulos = vTemp.Count();
                                    Tuple<int, int, int> Felpa = new Tb_Cobranza_AD().GetUltimaCobranza(vId, Temp.IdArticulo);
                                    TotalArticulos = Felpa.Item1;
                                    Año = Felpa.Item2;
                                    Mes = Felpa.Item3;
                                }


                                if (TotalArticulos > 0)
                                {
                                    var xxx = (from Comp in new Tb_Comprobantedetalle_AD().List(vId, 0/*LISTAR PARA MOSTRAR EN VISTA*/) where Comp.Id_Servicio == Temp.IdArticulo select Comp).Count();

                                    if (Mes == 12)
                                    {
                                        Año = Año + 1;
                                        Mes = 1;
                                    }
                                    else
                                    {
                                        Mes = (TotalArticulos == xxx) ? Mes + 1 : 1;
                                    }

                                    new Tb_Comprobantedetalle_AD().Insert(new Tb_Comprobantedetalle()
                                    {
                                        Cantidad = Cantidad,
                                        Codigo_Servicio = Temp.Codigo,
                                        Descripcion = Temp.Descripcion + " " + Año.ToString() + "-" + new CultureInfo("es-ES", false).DateTimeFormat.GetMonthName(Mes).Substring(3).ToUpper(),
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
                                else
                                {
                                    Detalle.Flg_Activo = Variables.Activo;
                                    Detalle.Cantidad = Cantidad;
                                    Detalle.Fec_Modifica = Variables.Hoy;
                                    Detalle.Precio = Temp.PrecioUnitario;
                                    Detalle.Monto = Temp.PrecioUnitario * Cantidad;
                                    Detalle.Igv = ((Temp.PrecioUnitario * Cantidad) * Variables.Igv);
                                    Detalle.Subtotal = (Temp.PrecioUnitario * Cantidad) + ((Temp.PrecioUnitario * Cantidad) * Variables.Igv);
                                    new Tb_Comprobantedetalle_AD().Update(Detalle);

                                }
                            }
                        }
                    }
                    else
                    {
                        vEstado = 1;
                    }
                }

                if (vEstado < 2 )
                new Tb_Comprobantecabecera_AD().Actualizar_Montos(vId);
                //Full.Complete();
                //Full.Dispose();
                return vEstado;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                new Tb_Comprobantecabecera_AD().Actualizar_Montos(vId);
                //Full.Dispose();
                throw;
            }

            //}
        }

        public bool DescuentoServicio(int vId, decimal vDescuento, string vUsuario)
        {
            try
            {
                return new Tb_Comprobantedetalle_AD().UpdateService(vId, vDescuento, vUsuario);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
