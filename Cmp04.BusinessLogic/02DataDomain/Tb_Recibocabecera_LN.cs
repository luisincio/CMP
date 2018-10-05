/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Recibocabecera_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Recibocabecera
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
    public class Tb_Recibocabecera_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Recibocabecera
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Recibocabecera</returns>
        public List<Tb_Comprobantecabecera> List()
        {
            try
            {
                return new Tb_Recibocabecera_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Recibocabecera basado en su clave primaria
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
                    Temp = new Tb_Comprobantecabecera() { Id_Comprobante = 0, Tipo_Documentosunat = (int)EnumTipoDocSunat.RECIBO, Id_Moneda = (int)EnumTipoMoneda.SOLES, Id_Tipo_Pago = (int)EnumTipoPago.EFECTIVO, Id_CondicionPago = Variables.Contado };
                    Temp.Detalle = new List<Tb_Comprobantedetalle>();
                }
                else
                {
                    Temp = new Tb_Recibocabecera_AD().GetRegistry(vId_Comprobante);
                    Temp.Detalle = new Tb_Recibodetalle_AD().List(vId_Comprobante);
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
        /// Inserta un Objeto del tipo Tb_Recibocabecera
        /// </summary>
        /// <param name="Tb_Recibocabecera">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Comprobantecabecera Insert(Tb_Comprobantecabecera vTb_Recibocabecera)
        {
            try
            {
                return new Tb_Recibocabecera_AD().Insert(vTb_Recibocabecera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Recibocabecera
        /// </summary>
        /// <param name="Tb_Recibocabecera">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Comprobantecabecera Update(Tb_Comprobantecabecera vTb_Recibocabecera)
        {
            try
            {
                return new Tb_Recibocabecera_AD().Update(vTb_Recibocabecera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }
                
        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Recibocabecera en base a su clave primaria
        /// </summary>
        /// <param name="Id_Comprobante">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Comprobante, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Recibocabecera_AD().Delete(vId_Comprobante, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Comprobantecabecera Grabar(Tb_Comprobantecabecera vTb_Comprobantecabecera)
        {
            try
            {
                vTb_Comprobantecabecera.Fec_Ingreso = vTb_Comprobantecabecera.Fec_Modifica = Variables.Hoy;
                vTb_Comprobantecabecera.Flg_Activo = Variables.Activo;
                vTb_Comprobantecabecera.Id_EstadoComprobante = (int)EnumEstadoComprobante.EMITIDO;
                vTb_Comprobantecabecera.Nrodocumento_Gp = vTb_Comprobantecabecera.Opcional + "-" + vTb_Comprobantecabecera.Nro_Documento;
                
                if (vTb_Comprobantecabecera.Id_Comprobante == 0)
                {
                    vTb_Comprobantecabecera.Nro_Documento = new Tb_Correlativos_AD().GetNumero(vTb_Comprobantecabecera.Id_Sitio_Destino, Convert.ToInt32(EnumTipoDocSunat.RECIBO) , vTb_Comprobantecabecera.Serie);
                    vTb_Comprobantecabecera = new Tb_Recibocabecera_AD().Insert(vTb_Comprobantecabecera);
                }
                else
                {
                    
                    vTb_Comprobantecabecera = new Tb_Recibocabecera_AD().Update(vTb_Comprobantecabecera);
                }

                vTb_Comprobantecabecera.Detalle = new Tb_Recibodetalle_AD().List(vTb_Comprobantecabecera.Id_Comprobante);
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

        public Tb_Comprobantecabecera GetRegistry_Nro(string vNumeroRecibo)
        {
            try
            {
                Tb_Comprobantecabecera Temp = new Tb_Comprobantecabecera();
                if (vNumeroRecibo.Trim().Length > 0)
                {
                    Temp = new Tb_Recibocabecera_AD().GetRegistry_Nro(vNumeroRecibo);
                    if (Temp != null) Temp.Detalle = new Tb_Recibodetalle_AD().List(Temp.Id_Comprobante);
                }
                return Temp;
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
