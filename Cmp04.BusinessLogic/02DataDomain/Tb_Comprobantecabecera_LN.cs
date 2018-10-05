/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Comprobantecabecera_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Comprobantecabecera
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
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Comprobantecabecera_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Comprobantecabecera
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Comprobantecabecera</returns>
        public List<Tb_Comprobantecabecera> List()
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Tb_Comprobantecabecera> ListxCliente(String Cod_Cliente)
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().List(Cod_Cliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Comprobantecabecera basado en su clave primaria
        /// </summary>
        /// <param name="Id_Comprobante">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Comprobantecabecera GetRegistry(int vId_Comprobante)
        {
            try
            {
                Tb_Comprobantecabecera Temp;
                if (vId_Comprobante == 0)
                {
                    Temp = new Tb_Comprobantecabecera()
                    {
                        Id_Comprobante = 0,
                        Tipo_Documentosunat = (int)EnumTipoDocSunat.BOLETA,
                        Id_Moneda = (int)EnumTipoMoneda.SOLES,
                        Id_Tipo_Pago = (int)EnumTipoPago.EFECTIVO,
                        Id_CondicionPago = Variables.Contado,
                        Id_EstadoComprobante = (int)EnumEstadoComprobante.BORRADOR,
                        Flg_Activo = Variables.Activo,
                        Fecha = Variables.Hoy,
                        Fecha_Vencimiento = Variables.Hoy,
                        Fec_Ingreso = Variables.Hoy,
                        Fec_Modifica = Variables.Hoy
                    };
                    Temp.Detalle = new List<Tb_Comprobantedetalle>();
                }
                else
                {
                    Temp = new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante);
                    Temp.Detalle = new Tb_Comprobantedetalle_AD().List(vId_Comprobante, 0/*LISTAR PARA MOSTRAR EN VISTA*/);
                }
                return Temp;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Comprobantecabecera basado en su clave primaria
        /// </summary>
        /// <param name="Id_Comprobante">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Comprobantecabecera GetRegistryResumen(int vId_Comprobante)
        {
            try
            {
                Tb_Comprobantecabecera Temp;
                if (vId_Comprobante == 0)
                {
                    Temp = new Tb_Comprobantecabecera() { Id_Comprobante = 0, Tipo_Documentosunat = (int)EnumTipoDocSunat.BOLETA, Id_Moneda = (int)EnumTipoMoneda.SOLES, Id_Tipo_Pago = (int)EnumTipoPago.EFECTIVO, Id_CondicionPago = Variables.Contado };
                    Temp.Detalle = new List<Tb_Comprobantedetalle>();
                }
                else
                {
                    Temp = new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante);
                    var Detalle = new Tb_Comprobantedetalle_AD().List(vId_Comprobante,0/*LISTAR PARA MOSTRAR EN VISTA*/);

                    Tb_Comprobantedetalle Registro = new Tb_Comprobantedetalle();
                    foreach (var item in Detalle)
                    {
                        Registro.Cantidad = item.Cantidad;
                        Registro.Cantidad = item.Cantidad;
                        Registro.Cantidad = item.Cantidad;
                        Registro.Cantidad = item.Cantidad;
                    }


                    Temp.Detalle = new Tb_Comprobantedetalle_AD().List(vId_Comprobante, 0/*LISTAR PARA MOSTRAR EN VISTA*/);
                }
                return Temp;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


        /// <summary>
        /// Inserta un Objeto del tipo Tb_Comprobantecabecera
        /// </summary>
        /// <param name="Tb_Comprobantecabecera">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Comprobantecabecera Insert(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().Insert(vTb_Comprobantecabecera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Comprobantecabecera
        /// </summary>
        /// <param name="Tb_Comprobantecabecera">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Comprobantecabecera Update(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().Update(vTb_Comprobantecabecera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Comprobantecabecera en base a su clave primaria
        /// </summary>
        /// <param name="Id_Comprobante">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Comprobante, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().Delete(vId_Comprobante, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos
        public Tb_Comprobantecabecera Grabar(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            try
            {
                vTb_Comprobantecabecera.Fec_Ingreso = vTb_Comprobantecabecera.Fec_Modifica = Variables.Hoy;
                vTb_Comprobantecabecera.Flg_Activo = Variables.Activo;
                vTb_Comprobantecabecera.Id_EstadoComprobante = (int)EnumEstadoComprobante.GUARDADO;
                vTb_Comprobantecabecera.Nrodocumento_Gp = vTb_Comprobantecabecera.Opcional + "-" + vTb_Comprobantecabecera.Nro_Documento;
                if (vTb_Comprobantecabecera.Id_Clientepagador == 0) vTb_Comprobantecabecera.Id_Clientepagador = Variables.EmpresaNoExiste;

                if (new Tb_Comprobantecabecera_AD().GetRegistry(vTb_Comprobantecabecera.Tipo_Documentosunat, vTb_Comprobantecabecera.Nro_Documento) == null)
                {
                    if (vTb_Comprobantecabecera.Id_Comprobante == 0)
                    {
                        vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().Insert(vTb_Comprobantecabecera);
                        //var xxxxxxxx = new Tb_Correlativos_AD().GetNumero(vTb_Comprobantecabecera.Id_Sitio_Destino, vTb_Comprobantecabecera.Tipo_Documentosunat, vTb_Comprobantecabecera.Serie);
                    }
                    else
                    {
                        vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().Update(vTb_Comprobantecabecera);
                    }
                }
                else if (vTb_Comprobantecabecera.Id_Comprobante == 0)
                {
                    //vTb_Comprobantecabecera.Nro_Documento = new Tb_Correlativos_AD().GetNumero(vTb_Comprobantecabecera.Id_Sitio_Destino, vTb_Comprobantecabecera.Tipo_Documentosunat, vTb_Comprobantecabecera.Serie);
                    vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().Insert(vTb_Comprobantecabecera);
                }
                else
                {
                    vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().Update(vTb_Comprobantecabecera);
                }


                vTb_Comprobantecabecera.Detalle = new Tb_Comprobantedetalle_AD().List(vTb_Comprobantecabecera.Id_Comprobante, 0/*LISTAR PARA MOSTRAR EN VISTA*/);
                vTb_Comprobantecabecera.Opcional = "OK";
                return vTb_Comprobantecabecera;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                vTb_Comprobantecabecera.Opcional = "ERR";
                throw;
            }
        }

        public Tb_Comprobantecabecera GetRegistry_Matricula(int vId_Persona)
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().GetRegistry_Matricula(vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Comprobantecabecera GetRegistry(int vTipo_Documentosunat, string vNro_Documento)
        {
            Tb_Comprobantecabecera Temp;
            try
            {
                if (vTipo_Documentosunat == 0 || vNro_Documento.Length == 0)
                {
                    Temp = new Tb_Comprobantecabecera() { Id_Comprobante = 0 };
                    Temp.Detalle = new List<Tb_Comprobantedetalle>();
                }
                else
                {
                    Temp = new Tb_Comprobantecabecera_AD().GetRegistry(vTipo_Documentosunat, vNro_Documento);
                    if (Temp == null)
                    {
                        Temp = new Tb_Comprobantecabecera() { Id_Comprobante = 0 };
                        Temp.Detalle = new List<Tb_Comprobantedetalle>();
                        Temp.Opcional = "FOUND";
                    }
                    else
                    {
                        Temp.Detalle = new Tb_Comprobantedetalle_AD().List(Temp.Id_Comprobante, 0/*LISTAR PARA MOSTRAR EN VISTA*/);
                        Temp.Opcional = "OK";
                    }

                }
                return Temp;
            }
            catch (Exception ex)
            {
                //Temp.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Comprobantecabecera Anular(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            try
            {
                vTb_Comprobantecabecera.Fec_Modifica = Variables.Hoy;
                vTb_Comprobantecabecera.Flg_Activo = Variables.Activo;
                vTb_Comprobantecabecera.Id_EstadoComprobante = (int)EnumEstadoComprobante.ANULADO;
                if (vTb_Comprobantecabecera.Id_Clientepagador == 0) vTb_Comprobantecabecera.Id_Clientepagador = 30;
                vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().Update(vTb_Comprobantecabecera);
                vTb_Comprobantecabecera.Opcional = "OK";
                return vTb_Comprobantecabecera;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                vTb_Comprobantecabecera.Opcional = "ERR";
                throw;
            }
        }

        public int Tiene_Matricula(int vId_Comprobante)
        {
            try
            {
                var Temp = new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante);
                if (Temp == null)
                    return 0;
                else
                    return new Tb_Comprobantecabecera_AD().Tiene_Matricula(new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante).Id_Colegiado);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        //public Tb_Comprobantecabecera EmitirFactura(int vId_Comprobante, string vUsuario)
        //{
        //    Tb_Comprobantecabecera vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante);
        //    try
        //    {
        //        vTb_Comprobantecabecera.Fec_Modifica = Variables.Hoy;
        //        vTb_Comprobantecabecera.Flg_Activo = Variables.Activo;
        //        vTb_Comprobantecabecera.Id_EstadoComprobante = (int)EnumEstadoComprobante.EMITIDO;
        //        vTb_Comprobantecabecera.Usu_Modifica = vUsuario;
        //        vTb_Comprobantecabecera = new Tb_Comprobantecabecera_AD().Update(vTb_Comprobantecabecera);

        //        List<Tb_Cobranza> vLstCobranza = new Tb_Cobranza_AD().List("", vId_Comprobante);

        //        if (vLstCobranza.Count == 0)
        //        {
        //            Tb_Cobranza Temp = new Tb_Cobranza_AD().GetRegistry_UltimaCuota(vTb_Comprobantecabecera.Id_Colegiado);

        //            if (Temp == null)
        //            {

        //            }
        //            else
        //            {
        //                if (Temp.Mes == 12)
        //                {
        //                    Temp.Mes = 1;
        //                    Temp.Año = Temp.Año + 1;
        //                }
        //                else
        //                {
        //                    Temp.Mes = Temp.Mes + 1;
        //                }
        //                Temp.Fecha_Pagado = Temp.Fecha = Temp.Fec_Ingreso = Temp.Fec_Modifica = Variables.Hoy;
        //                Temp.Fecha_Envio = Temp.Fecha_Pagado = null;
        //                Temp.Id_Comprobante = vTb_Comprobantecabecera.Id_Comprobante;
        //            }
        //        }
        //        else
        //        {
        //            foreach (var item in vLstCobranza)
        //            {
        //                item.Fec_Modifica = Variables.Hoy;
        //                item.Flg_Activo = Variables.Activo;
        //                item.Usu_Modifica = vUsuario;
        //                item.Fecha_Pagado = Variables.Hoy;
        //                new Tb_Cobranza_AD().Update(item);
        //            }
        //        }
        //        vTb_Comprobantecabecera.Opcional = "OK";
        //        return vTb_Comprobantecabecera;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        vTb_Comprobantecabecera.Opcional = "ERR";
        //        throw;
        //    }
        //}

        public int Procesar_Planilla(string vId_Comprobante, string vMontos, string vRecibo, string vUsuario)
        {
            try
            {
                return new Tb_Comprobantecabecera_AD().Procesar_Planilla(vId_Comprobante, vMontos, vRecibo, vUsuario, Variables.Hoy);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion
    }
}
