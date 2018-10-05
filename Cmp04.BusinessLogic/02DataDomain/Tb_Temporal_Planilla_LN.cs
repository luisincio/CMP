/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Temporal_Planilla_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Temporal_Planilla
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
    public class Tb_Temporal_Planilla_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Temporal_Planilla
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Temporal_Planilla</returns>
        public List<Tb_Temporal_Planilla> List(string vNro_Recibo, int vId_Consejo, int vId_EntidadPagadora, int vPagina, int vRegistros)
        {
            try
            {
                return new Tb_Temporal_Planilla_AD().List(vNro_Recibo, vId_Consejo, vId_EntidadPagadora, vPagina, vRegistros);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Temporal_Planilla basado en su clave primaria
        /// </summary>

        /// <returns>Objeto recuperado</returns>
        public Tb_Temporal_Planilla GetRegistry(string vId_Seguro, string vDni, string vPeriodo)
        {
            try
            {
                return new Tb_Temporal_Planilla_AD().GetRegistry(vId_Seguro, vDni, vPeriodo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Temporal_Planilla
        /// </summary>
        /// <param name="Tb_Temporal_Planilla">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Temporal_Planilla Insert(Tb_Temporal_Planilla vTb_Temporal_Planilla)
        {
            try
            {
                return new Tb_Temporal_Planilla_AD().Insert(vTb_Temporal_Planilla);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        //public List<Tb_Temporal_Planilla> Save(Excel.IExcelDataReader vLista, string vUsuario)
        //public bool Save(Excel.IExcelDataReader vLista, string vUsuario, int vEntidad, int vConsejo)
        public bool Save(Excel.IExcelDataReader vLista, string vRecibo, string vUsuario)
        {
            try
            {
                int vHeader = 1;
                //List<Tb_Temporal_Planilla> ReturnLst = new List<Tb_Temporal_Planilla>();
                while (vLista.Read())
                {
                    if (vLista[0] == null) break;
                    if (vHeader == 0)
                    {
                        var Tempo = new Tb_Temporal_Planilla()
                        {
                            Id_Seguro = vLista[0].ToString(),
                            Nro_Recibo = vRecibo,
                            Id_Colegiado = vLista[1].ToString(),
                            Id_Consejo = Convert.ToInt32(vLista[2].ToString()),
                            Id_EntidadPagadora = Convert.ToInt32(vLista[3].ToString()),
                            Dni = vLista[4].ToString(),
                            Nombre_Completo = vLista[5].ToString(),
                            Movimiento = vLista[6].ToString(),
                            Importe = Convert.ToDecimal(vLista[7].ToString()),
                            Periodo = vLista[8].ToString(),
                            Flg_Activo = Variables.Activo,
                            Usu_Ingreso = vUsuario,
                            Usu_Modifica = vUsuario,
                            Fec_Ingreso = Variables.Hoy,
                            Fec_Modifica = Variables.Hoy, 
                            Tipo = "M"
                        };

                        new Tb_Temporal_Planilla_AD().Insert(Tempo);
                        //ReturnLst.Add(Tempo);
                    }
                    else
                    {
                        vHeader = 0;
                    }
                }
                //return ReturnLst;
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public bool Save(List<Tb_Temporal_Planilla> vLista, string vUsuario)
        {
            try
            {
                foreach (var item in vLista)
                {
                    if (item.Flg_Activo == null)
                    {
                        item.Usu_Modifica = vUsuario;
                        item.Fec_Modifica = Variables.Hoy;
                        item.Flg_Activo = Variables.Activo;
                        new Tb_Temporal_Planilla_AD().Update(item);
                    }
                    else if (item.Flg_Activo.ToUpper() == "TRUE")
                    {
                        new Tb_Temporal_Planilla_AD().Delete(item.Id_Seguro, item.Id_Consejo, item.Id_EntidadPagadora, item.Dni, item.Periodo);
                    }
                    else
                    {
                        item.Usu_Modifica = vUsuario;
                        item.Fec_Modifica = Variables.Hoy;
                        new Tb_Temporal_Planilla_AD().Update(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public bool Procesar(string vDocumento, int vIdConsejo, int vIdEntidad, string vUsuario, int vId_Persona)
        {
            try
            {
                //insertar en comprobante
                //insertar en cobranza
                //eliminar planilla
                List<Tb_Temporal_Planilla> Temp = new Tb_Temporal_Planilla_LN().List(vDocumento, vIdConsejo, vIdEntidad, 1, Int32.MaxValue);
                foreach (var item in Temp)
                {
                    Tb_Persona_Natural Medico = new Tb_Persona_Natural_AD().GetRegistry(0, item.Dni);
                    if (Medico != null)
                    {
                        if (Convert.ToInt64(Medico.Colegiado) > 0)
                        {
                            Tb_Cobranza Cobranza = new Tb_Cobranza_AD().GetRegistry(Medico.Id_Persona, Convert.ToInt32(Variables.Hoy.Year.ToString().Substring(0, 2) + item.Periodo.Substring(2, 2)), Convert.ToInt32(item.Periodo.Substring(0, 2)), (int)EnumTipoArticuloCuota.CUOTA_PENSION);

                            if (Cobranza == null)
                            {
                                //var Cobros = new Tb_Cobranza_LN().Insert(new Tb_Cobranza()
                                //{
                                //    Id_Colegiado = Medico.Id_Persona,
                                //    Id_Estado_Colegiado = Medico.Id_Estado_Actual,
                                //    Colegiatura = item.Id_Colegiado,
                                //    Año =  Convert.ToInt32(Variables.Hoy.Year.ToString().Substring(0, 2) + item.Periodo.Substring(2, 2)),
                                //    Mes = Convert.ToInt32(item.Periodo.Substring(0, 2)),
                                //    Id_Servicio = Variables.IdPension,
                                //    Descuento = Variables.Pension - Convert.ToDecimal(item.Importe),
                                //    Monto = Convert.ToDecimal(item.Importe),
                                //    Fecha = item.Fec_Ingreso,
                                //    Fecha_Envio = Variables.Hoy,
                                //    Fecha_Pagado = Variables.Hoy,
                                //    Fecha_Recibido = Variables.Hoy,
                                //    Id_Comprobante = null,
                                //    Flg_Activo = Variables.Activo,
                                //    Usu_Ingreso = vUsuario,
                                //    Usu_Modifica = vUsuario,
                                //    Fec_Ingreso = Variables.Hoy,
                                //    Fec_Modifica = Variables.Hoy
                                //});
                            }
                            else
                            {
                                if (Cobranza.Fecha_Pagado == null)
                                {
                                    Cobranza.Descuento = Variables.Pension - Convert.ToDecimal(item.Importe);
                                    Cobranza.Monto = Convert.ToDecimal(item.Importe);
                                    Cobranza.Fecha_Pagado = null;
                                    Cobranza.Id_Comprobante = null;
                                    Cobranza.Flg_Activo = Variables.Activo;
                                    Cobranza.Usu_Modifica = vUsuario;
                                    Cobranza.Fec_Modifica = Variables.Hoy;
                                    Cobranza.Id_Entidad_Paga = vIdEntidad;
                                    Cobranza.Nro_Recibo = vDocumento;
                                    var Cobros = new Tb_Cobranza_AD().Update(Cobranza);

                                    int vComprobante = new Tb_Cobranza_LN().Generar_Comprobante(Cobros.Id_Cobro.ToString(), vUsuario, vId_Persona);
                                }
                                
                                //Cobros.Id_Comprobante = vComprobante;
                                //new Tb_Cobranza_LN().Update(Cobros);
                            }
                        }
                    }


                    
                    
                    new Tb_Temporal_Planilla_AD().Delete(item.Id_Seguro, item.Id_Consejo, item.Id_EntidadPagadora, item.Dni, item.Periodo);
                }
                return true;
                

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }



        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Temporal_Planilla en base a su clave primaria
        /// </summary>

        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        //public int Delete(string vId_Seguro, string vDni, string vPeriodo)
        //{
        //    try
        //    {
        //        return new Tb_Temporal_Planilla_AD().Delete(vId_Seguro, vDni, vPeriodo);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message, ex);
        //        throw;
        //    }
        //}

        #endregion
    }
}
