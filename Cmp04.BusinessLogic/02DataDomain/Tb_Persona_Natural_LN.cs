/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Natural_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase Tb_Persona_Natural
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
using System.Transactions;
using System.Linq;
#endregion

namespace Cmp04.BusinessLogic
{
    public class Tb_Persona_Natural_LN : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Natural
        /// </summary>
        /// <returns>Retorna una lista de objetos de tipo Tb_Persona_Natural</returns>
        public List<Tb_Persona_Natural> List()
        {
            try
            {
                return new Tb_Persona_Natural_AD().List();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que recupera un regustro del tipo Tb_Persona_Natural basado en su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Natural GetRegistry(int vId_Persona)
        {
            try
            {
                return (vId_Persona == 0) ? new Tb_Persona_Natural() : new Tb_Persona_Natural_AD().GetRegistry(vId_Persona);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Inserta un Objeto del tipo Tb_Persona_Natural
        /// </summary>
        /// <param name="Tb_Persona_Natural">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizado</returns>
        public Tb_Persona_Natural Insert(Tb_Persona_Natural vTb_Persona_Natural)
        {
            try
            {
                return new Tb_Persona_Natural_AD().Insert(vTb_Persona_Natural);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Natural
        /// </summary>
        /// <param name="Tb_Persona_Natural">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Natural Update(Tb_Persona_Natural vTb_Persona_Natural)
        {
            try
            {
                vTb_Persona_Natural.Fec_Modifica = Variables.Hoy;
                return new Tb_Persona_Natural_AD().Update(vTb_Persona_Natural);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Método que eliminara un registo del tipo Tb_Persona_Natural en base a su clave primaria
        /// </summary>
        /// <param name="Id_Persona">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            try
            {
                return new Tb_Persona_Natural_AD().Delete(vId_Persona, vUsuario, vFecha);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion

        #region Métodos Extendidos

        public Tb_Persona_Natural GetRegistry(int vId_TipoDocumento, string vNumero)
        {
            try
            {
                return new Tb_Persona_Natural_AD().GetRegistry(vId_TipoDocumento, vNumero);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Cliente GetCliente(int vId_Persona)
        {
            try
            {
                Cliente Temp = new Cliente();

                Temp.Persona = (vId_Persona == 0) ? new Tb_Persona_Natural() : new Tb_Persona_Natural_AD().GetRegistry(vId_Persona);
                Temp.Domicilio = (vId_Persona == 0) ? new Tb_Domicilio() : new Tb_Domicilio_AD().GetRegistry(vId_Persona);
                Temp.Medios = (vId_Persona == 0) ? new List<Tb_Medio_Contacto>() : new Tb_Medio_Contacto_AD().List(vId_Persona);
                Temp.Estudio = (vId_Persona == 0) ? new Tb_Colegiado_Estudio() : new Tb_Colegiado_Estudio_AD().GetRegistry(vId_Persona);

                if (vId_Persona > 0)
                {
                    Temp.Persona.Origen = (new Tb_Persona_AD().GetRegistry(vId_Persona).Flg_Nacionalidad == "1") ? 54 : 55;
                    //Temp.Persona.Sexo = (Temp.Persona.Sexo == "M") ? "42" : "43";
                    //Temp.Persona.Sexo = (Temp.Persona.Sexo == "M") ? "42" : "43";
                    Temp.Persona.Sexo = ((Temp.Persona.Sexo == "M") ? (int)EnumGenero.MASCULINO : (int)EnumGenero.FEMENINO).ToString();
                    Temp.Persona.Edad = Variables.Hoy.AddTicks(-Temp.Persona.Fecha_Nacio.Ticks).Year - 1;
                    if (Temp.Domicilio == null) Temp.Domicilio = new Tb_Domicilio() { Id_Persona = Temp.Persona.Id_Persona };
                    if (Temp.Medios == null) Temp.Medios = new List<Tb_Medio_Contacto>();
                    if (Temp.Estudio == null) Temp.Estudio = new Tb_Colegiado_Estudio() { Id_Persona = Temp.Persona.Id_Persona };
                }

                return Temp;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Persona_Natural Grabar(Tb_Persona_Natural vPersona)
        {
            try
            {
                vPersona.Fec_Colegiado = vPersona.Fec_Ingreso = vPersona.Fec_Modifica = Variables.Hoy;
                if (vPersona.Id_Grupo_Sanguineo == null) vPersona.Id_Grupo_Sanguineo = 0;
                vPersona.Sexo = (Convert.ToInt32(vPersona.Sexo) == (int)EnumGenero.MASCULINO) ? "M" : "F";
                if (Convert.ToInt32(vPersona.Colegiado) == 0) vPersona.Colegiado = Variables.Colegiado;
                vPersona.Flg_Activo = Variables.Activo;

                if (vPersona.Id_Persona == 0)
                {
                    Tb_Persona Temp = new Tb_Persona_AD().Insert(new Tb_Persona()
                    {
                        Fec_Ingreso = Variables.Hoy,
                        Fec_Modifica = Variables.Hoy,
                        Flg_Activo = Variables.Activo,
                        Flg_Nacionalidad = (vPersona.Origen == (int)EnumOrigen.NACIONAL) ? "1" : "0",
                        Id_Tipo_Persona = Variables.Natural,
                        Nombre_Comercial = vPersona.Apellido_Paterno + " " + vPersona.Apellido_Materno + ", " + vPersona.Nombres,
                        Nombre_Completo = vPersona.Apellido_Paterno + " " + vPersona.Apellido_Materno + ", " + vPersona.Nombres,
                        Ruc = "",
                        Usu_Ingreso = vPersona.Usu_Ingreso,
                        Usu_Modifica = vPersona.Usu_Modifica
                    });

                    vPersona.Id_Persona = Temp.Id_Persona;

                    vPersona = new Tb_Persona_Natural_AD().Insert(vPersona);
                }
                else
                {
                    Tb_Persona Temp = new Tb_Persona_AD().GetRegistry(vPersona.Id_Persona);
                    Temp.Fec_Modifica = Variables.Hoy;
                    Temp.Flg_Activo = Variables.Activo;
                    Temp.Flg_Nacionalidad = (vPersona.Origen == (int)EnumOrigen.NACIONAL) ? "1" : "0";
                    Temp.Id_Tipo_Persona = Variables.Natural;
                    Temp.Nombre_Comercial = vPersona.Apellido_Paterno + " " + vPersona.Apellido_Materno + ", " + vPersona.Nombres;
                    Temp.Nombre_Completo = vPersona.Apellido_Paterno + " " + vPersona.Apellido_Materno + ", " + vPersona.Nombres;
                    Temp.Usu_Modifica = vPersona.Usu_Modifica;
                    new Tb_Persona_AD().Update(Temp);

                    vPersona = new Tb_Persona_Natural_AD().Update(vPersona);
                }

                vPersona.Edad = Variables.Hoy.AddTicks(-vPersona.Fecha_Nacio.Ticks).Year - 1;
                vPersona.Opcional = "OK";
                return vPersona;
            }
            catch (Exception ex)
            {
                vPersona.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Colegiado GetColegiado(int vId_Persona)
        {
            try
            {
                Colegiado Temp = new Colegiado();

                Temp.Persona = (vId_Persona == 0) ? new Tb_Persona_Natural() : new Tb_Persona_Natural_AD().GetRegistry(vId_Persona);
                Temp.Domicilio = (vId_Persona == 0) ? new Tb_Domicilio() : new Tb_Domicilio_AD().GetRegistry(vId_Persona);
                Temp.Medios = (vId_Persona == 0) ? new List<Tb_Medio_Contacto>() : new Tb_Medio_Contacto_AD().List(vId_Persona);
                Temp.Estudio = (vId_Persona == 0) ? new Tb_Colegiado_Estudio() : new Tb_Colegiado_Estudio_AD().GetRegistry(vId_Persona);
                Temp.Especialidades = (vId_Persona == 0) ? new List<Tb_Colegiado_Especialidad>() : new Tb_Colegiado_Especialidad_AD().List(vId_Persona);
                Temp.Trabajos = (vId_Persona == 0) ? new List<Tb_Colegiado_Laboral>() : new Tb_Colegiado_Laboral_AD().List(vId_Persona);
                Temp.Concejos = (vId_Persona == 0) ? new List<Tb_Colegiado_Consejo>() : new Tb_Colegiado_Consejo_AD().List(vId_Persona);
                Temp.Estados = (vId_Persona == 0) ? new List<Tb_Colegiado_Estado>() : new Tb_Colegiado_Estado_AD().List(vId_Persona);

                if (vId_Persona > 0)
                {
                    Temp.Persona.Origen = (new Tb_Persona_AD().GetRegistry(vId_Persona).Flg_Nacionalidad == "1") ? 54 : 55;
                    Temp.Persona.Sexo = (Temp.Persona.Sexo == "M") ? "42" : "43";
                    Temp.Persona.Edad = Variables.Hoy.AddTicks(-Temp.Persona.Fecha_Nacio.Ticks).Year - 1;
                    if (Temp.Domicilio == null) Temp.Domicilio = new Tb_Domicilio() { Id_Persona = Temp.Persona.Id_Persona };
                    if (Temp.Medios == null) Temp.Medios = new List<Tb_Medio_Contacto>();
                    if (Temp.Estudio == null) Temp.Estudio = new Tb_Colegiado_Estudio() { Id_Persona = Temp.Persona.Id_Persona };
                }

                return Temp;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public ColegiadoMicro GetColegiadoCaja(int vId_Persona)
        {
            try
            {
                ColegiadoMicro Temp = new Tb_Persona_Natural_AD().GetRegistryColegiado(vId_Persona);
                if (Temp != null)
                {
                    Temp.Medios = (Temp.Id_Persona == 0) ? new List<Tb_Medio_Contacto>() : new Tb_Medio_Contacto_AD().List(Temp.Id_Persona);

                    if (Temp.Id_Persona > 0)
                    {
                        Temp.Origen = (new Tb_Persona_AD().GetRegistry(Temp.Id_Persona).Flg_Nacionalidad == "1") ? 54 : 55;
                        Temp.Edad = Variables.Hoy.AddTicks(-Temp.Fecha_Nacio.Ticks).Year - 1;
                        if (Temp.Medios.Count > 0)
                        {
                            var vCelular = Temp.Medios.Where(x => x.Id_Tipo_Medio_Contacto == (int)EnumMedioContacto.CELULAR).OrderByDescending(x => x.Fec_Modifica).Select(y => y.Nombre_Medio_Contacto);
                            Temp.Celular = (vCelular.Count() == 0) ? "" : vCelular.First().ToUpper();
                            var vCorreo = Temp.Medios.Where(x => x.Id_Tipo_Medio_Contacto == (int)EnumMedioContacto.CORREO).OrderByDescending(x => x.Fec_Modifica).Select(y => y.Nombre_Medio_Contacto);
                            Temp.Correo = (vCorreo.Count() == 0) ? "" : vCorreo.First().ToUpper();
                        }
                    }
                }
                return Temp;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


        public int GenerarMatricula(int vId_Persona, string vUsuario)
        {
            int vResult = 0;
            try
            {
                new Tb_Colegiado_Estado_AD().Insert(new Tb_Colegiado_Estado()
                {
                    Fec_Ingreso = Variables.Hoy,
                    Fec_Modifica = Variables.Hoy,
                    Flg_Activo = Variables.Activo,
                    Id_Estado_Colegiado = (int)EnumEstado.ACTIVO,
                    Id_Persona = vId_Persona,
                    Usu_Ingreso = vUsuario,
                    Usu_Modifica = vUsuario,
                    ObservacionEstado = "MATRICULA ACEPTADA EL " + Variables.Hoy.ToShortDateString()
                });

                Tb_Colegiado_Carnet Temp2 = new Tb_Colegiado_Carnet_AD().Insert(new Tb_Colegiado_Carnet()
                {
                    Correlativo = 0,
                    Fec_Emision = null,
                    Fec_Entrega = null,
                    Fec_Ingreso = Variables.Hoy,
                    Fec_Modifica = Variables.Hoy,
                    Flg_Activo = Variables.Activo,
                    Id_Colegiado = "",
                    Id_Consejo = 0,
                    Id_Persona = vId_Persona,
                    Id_Tipocarnet = (int)EnumTipoCarnet.CARNETIZACION,
                    Usu_Ingreso = vUsuario,
                    Usu_Modifica = vUsuario
                });

                vResult = new Tb_Persona_Natural_AD().UpdateMatricula(vId_Persona, Temp2.Id_Carnet, vUsuario, Variables.Hoy);

                Tb_Persona_Natural Temp = new Tb_Persona_Natural_AD().GetRegistry(vId_Persona);
                Temp2.Id_Colegiado = Temp.Colegiado;

                new Tb_Colegiado_Carnet_AD().Update(Temp2);

                var ComprobanteMatricula = new Tb_Comprobantecabecera_AD().GetRegistry_Matricula(vId_Persona);

                new Tb_Cobranza_AD().Insert(new Tb_Cobranza()
                {
                    Id_Colegiado = vId_Persona,
                    Id_Estado_Colegiado = Temp.Id_Estado_Actual,
                    Colegiatura = Temp.Colegiado,
                    Año = Variables.Hoy.Year,
                    Mes = Variables.Hoy.Month,
                    Id_Servicio = (int)EnumTipoArticuloCuota.CUOTA_PENSION,
                    Descuento = 0,
                    Monto = Variables.Pension,
                    Fecha = Variables.Hoy,
                    Fecha_Pagado = Variables.Hoy,
                    Id_Comprobante = ComprobanteMatricula.Id_Comprobante,
                    Flg_Activo = Variables.Activo,
                    Fec_Ingreso = Variables.Hoy,
                    Fec_Modifica = Variables.Hoy,
                    Usu_Ingreso = vUsuario,
                    Usu_Modifica = vUsuario

                });

                var Domicilio = new Tb_Domicilio_AD().GetRegistry(vId_Persona);

                var y = new Cliente_AD().Grabar(new ClienteNJ()
                {
                    ApellidoMaterno = Temp.Apellido_Materno,
                    ApellidoPaterno = Temp.Apellido_Paterno,
                    Departamento = Domicilio.Departamento,
                    Direccion = Domicilio.Domicilio_Completo,
                    Distrito = Domicilio.Distrito,
                    NroDocumento = Temp.Nro_Documento,
                    PrimerNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(0, Temp.Nombres.IndexOf(" ")) : Temp.Nombres.Trim(),
                    Provincia = Domicilio.Provincia,
                    RazonSocial = "",
                    SegundoNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(Temp.Nombres.IndexOf(" ") + 1, Temp.Nombres.Length - (Temp.Nombres.IndexOf(" ") + 1)) : "",
                    TipoDocumento = Convert.ToInt32(new Tb_Maestras_AD().GetRegistry(Temp.Id_Tipo_Documento).Valor1),
                    TipoPersona = (int)EnumTipoPersonaGP.NATURAL
                });

                return vResult;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int ProcesarPreMatricula(int vId_Persona, int vId_Comprobante, string vUsuario)
        {
            int vRst = 0;
            //using (var Full = new TransactionScope(TransactionScopeOption.RequiresNew))
            using (var Full = new TransactionScope(TransactionScopeOption.Suppress))
            {
                try
                {
                    Tb_Persona_Natural Temp = new Tb_Persona_Natural_AD().GetRegistry(vId_Persona);

                    #region Por Matricularse
                    if (Temp != null)
                    {
                        if (Temp.Colegiado == Variables.Colegiado && Temp.Id_Estado_Actual == 0)
                        {
                            Temp.Usu_Modifica = vUsuario;
                            Temp.Fec_Modifica = Variables.Hoy;
                            Temp.Id_Estado_Actual = (int)EnumEstado.PRE_EVALUACION;
                            new Tb_Persona_Natural_AD().Update(Temp);

                            new Tb_Colegiado_Estado_AD().Insert(new Tb_Colegiado_Estado()
                            {
                                Fec_Ingreso = Variables.Hoy,
                                Fec_Modifica = Variables.Hoy,
                                Flg_Activo = Variables.Activo,
                                Id_Estado_Colegiado = (int)EnumEstado.PRE_EVALUACION,
                                Id_Persona = vId_Persona,
                                Usu_Ingreso = vUsuario,
                                Usu_Modifica = vUsuario,
                                ObservacionEstado = "MATRICULA"
                            });

                            var ComprobanteMatricula = new Tb_Comprobantecabecera_AD().GetRegistry_Matricula(vId_Persona);
                            new Tb_Colegiado_Consejo_AD().Insert(new Tb_Colegiado_Consejo()
                            {
                                Fec_Ingreso = Variables.Hoy,
                                Fec_Modifica = Variables.Hoy,
                                Flg_Activo = Variables.Activo,
                                Id_Consejo_Regional = ComprobanteMatricula.Id_Sitio_Destino,
                                Id_Persona = vId_Persona,
                                Usu_Ingreso = vUsuario,
                                Usu_Modifica = vUsuario
                            });

                            var Direccion = new Tb_Domicilio_AD().GetRegistry(vId_Persona);
                            var y = new Cliente_AD().Grabar(new ClienteNJ()
                            {
                                ApellidoMaterno = Temp.Apellido_Materno,
                                ApellidoPaterno = Temp.Apellido_Paterno,
                                Departamento = Direccion.Departamento,
                                Direccion = Direccion.Domicilio_Completo,
                                Distrito = Direccion.Distrito,
                                NroDocumento = Temp.Nro_Documento,
                                PrimerNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(0, Temp.Nombres.IndexOf(" ")) : Temp.Nombres.Trim(),
                                Provincia = Direccion.Provincia,
                                RazonSocial = "",
                                SegundoNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(Temp.Nombres.IndexOf(" ") + 1, Temp.Nombres.Length - (Temp.Nombres.IndexOf(" ") + 1)) : "",
                                TipoDocumento = Convert.ToInt32(new Tb_Maestras_AD().GetRegistry(Temp.Id_Tipo_Documento).Valor1),
                                TipoPersona = (int)EnumTipoPersonaGP.NATURAL
                            });
                        }
                    }
                    #endregion

                    var Cabecera = new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante);

                    #region Para los comprobantes que se generan automaticamente

                    if (Cabecera.Id_EstadoComprobante == (int)EnumEstadoComprobante.AUTOMATICO)
                    {
                        Cabecera.Fec_Modifica = Variables.Hoy;
                        Cabecera.Flg_Activo = Variables.Activo;
                        Cabecera.Id_EstadoComprobante = (int)EnumEstadoComprobante.EMITIDO;
                        Cabecera.Usu_Modifica = vUsuario;
                        Cabecera = new Tb_Comprobantecabecera_AD().Update(Cabecera);

                        List<Tb_Cobranza> vLstCobranza = new Tb_Cobranza_AD().List("", vId_Comprobante);

                        if (vLstCobranza.Count == 0)
                        {
                            Tb_Cobranza Cobranza = new Tb_Cobranza_AD().GetRegistry_UltimaCuota(Cabecera.Id_Colegiado);

                            if (Cobranza == null)
                            {

                            }
                            else
                            {
                                if (Cobranza.Mes == 12)
                                {
                                    Cobranza.Mes = 1;
                                    Cobranza.Año = Cobranza.Año + 1;
                                }
                                else
                                {
                                    Cobranza.Mes = Cobranza.Mes + 1;
                                }
                                Cobranza.Fecha_Pagado = Cobranza.Fecha = Cobranza.Fec_Ingreso = Cobranza.Fec_Modifica = Variables.Hoy;
                                Cobranza.Fecha_Envio = Cobranza.Fecha_Pagado = null;
                                Cobranza.Id_Comprobante = Cabecera.Id_Comprobante;
                            }
                        }
                        else
                        {
                            foreach (var item in vLstCobranza)
                            {
                                item.Fec_Modifica = Variables.Hoy;
                                item.Flg_Activo = Variables.Activo;
                                item.Usu_Modifica = vUsuario;
                                item.Fecha_Pagado = Variables.Hoy;
                                item.Nro_Recibo = (item.Nro_Recibo == null) ? "" : item.Nro_Recibo;
                                item.Flg_VaPagar = Variables.Activo;
                                new Tb_Cobranza_AD().Update(item);
                            }
                        }

                    }
                    #endregion

                    #region Procesar venta en GP

                    string vNumeroGp = new Numeracion_AD().GetVaue(Cabecera.Tipo_Documentosunat, Cabecera.Nrodocumento_Gp.Substring(0, Cabecera.Nrodocumento_Gp.IndexOf("-"))).Trim();
                    Cabecera.Nrodocumento_Gp = vNumeroGp;
                    Cabecera.Nro_Documento = Cabecera.Nrodocumento_Gp.Substring(Cabecera.Nrodocumento_Gp.IndexOf("-") + 1, Cabecera.Nrodocumento_Gp.Length - (Cabecera.Nrodocumento_Gp.IndexOf("-") + 1));
                    new Tb_Comprobantecabecera_AD().Update(Cabecera);

                    if (Cabecera.Nrodocumento_Gp == "") Cabecera.Nrodocumento_Gp = Cabecera.Opcional + "-" + Cabecera.Nro_Documento;

                    Tb_Persona TempEmpresa = null;
                    if (Temp.Id_Persona == Variables.IdClienteVarios && Cabecera.Tipo_Documentosunat == Convert.ToInt32(EnumTipoDocSunat.FACTURA))
                    {
                        TempEmpresa = new Tb_Persona_AD().GetRegistry(Cabecera.Id_Clientepagador);
                    }

                    Factura vFactura = new Factura();
                    var vConsejo = new Tb_Maestras_AD().GetConsejoRegistry(Cabecera.Id_Sitio_Destino);
                    vFactura.Cabecera = new Co_Cabecera()
                    {
                        FechaEmision = Cabecera.Fec_Ingreso,
                        FechaEnvio = Variables.Hoy,
                        IdCliente = TempEmpresa == null ? Temp.Nro_Documento : TempEmpresa.Ruc,
                        IdCondicionPago = Cabecera.Id_CondicionPago,
                        IdDocumento = Cabecera.Nrodocumento_Gp.Substring(0, Cabecera.Nrodocumento_Gp.IndexOf("-")),
                        //IdLote = xxx + " " + Cabecera.Fec_Ingreso.Year.ToString() + Cabecera.Fec_Ingreso.Month.ToString("00") + Cabecera.Fec_Ingreso.Day.ToString("00"),
                        //IdLote = vConsejo.Substring(4, 2) + vUsuario,
                        IdLote = vConsejo.Valor1 + vUsuario,
                        IdMoneda = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Moneda).Valor1,
                        IdSitio = vConsejo.Valor1, //new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor1,
                        IdTerritorio = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Origen).Valor1,
                        IdVendedor = "",
                        NroGuia = "",
                        //NumeroDocumento = Cabecera.Nrodocumento_Gp,
                        NumeroDocumento = vNumeroGp,
                        NumOCCliente = "",
                        Reference = Cabecera.Observacion,
                        TipoDocumento = Cabecera.Tipo_Documentosunat,
                        Usuario = vUsuario
                    };

                    vFactura.Detalle = new List<Co_Detalle>();
                    int Count = 0;
                    foreach (var item in new Tb_Comprobantedetalle_AD().List(vId_Comprobante,1/*LISTAR PARA PROCESAR EN GP*/))
                    {
                        Count = Count + 1;
                        vFactura.Detalle.Add(new Co_Detalle()
                        {
                            Cantidad = Convert.ToInt32(item.Cantidad),
                            DesArticulo = item.Descripcion,
                            Descuento = item.Descuento,
                            Fecha = Cabecera.Fec_Ingreso,
                            IdCliente = TempEmpresa == null ? Temp.Nro_Documento : TempEmpresa.Ruc,
                            IdSitio = vFactura.Cabecera.IdSitio,
                            Moneda = vFactura.Cabecera.IdMoneda,
                            NumArticulo = item.Codigo_Servicio,
                            NumeroDocumento = Cabecera.Nrodocumento_Gp,
                            NumeroTelefono = "",
                            PrecioUnitario = item.Precio,
                            Secuencia = Count,
                            SerLotProducto = "",
                            TipoDocumento = Cabecera.Tipo_Documentosunat,
                            UnidadMedida = Variables.UnidadMedida
                        });
                    }

                    vFactura.Cobranza = new Co_Cobros()
                    {
                        FechaEmision = Cabecera.Fec_Ingreso,
                        IdCliente = TempEmpresa == null ? Temp.Nro_Documento : TempEmpresa.Ruc,
                        IdDocumento = vFactura.Cabecera.IdDocumento,
                        IdSitio = vFactura.Cabecera.IdSitio,
                        Monto = Cabecera.Total,
                        NroOperacion = Cabecera.Id_Comprobante.ToString(),
                        NumeroDocumento = Cabecera.Nrodocumento_Gp,
                        TipoDocumento = 3,
                        Chequera = Cabecera.Id_Chequera.Trim(),
                        TipoPAgo = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Tipo_Pago).Valor1
                    };


                    var Direccion2 = new Tb_Domicilio_AD().GetRegistry(vId_Persona);

                    if (Direccion2 != null)
                    {
                        var y2 = new Cliente_AD().GrabarDatos(new ClienteClover()
                        {
                            NroDocumento = Temp.Nro_Documento,
                            NombreCompleto = Temp.Apellido_Paterno + ' ' + Temp.Apellido_Materno + ", " + Temp.Nombres,
                            //Clase = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor2,
                            Clase = vConsejo.Valor2,
                            Pais = "PERÙ",
                            Departamento = Direccion2.Departamento,
                            Provincia = Direccion2.Provincia,
                            Distrito = Direccion2.Distrito,
                            Direccion1 = Direccion2.Domicilio_Completo,
                            Direccion2 = Direccion2.Domicilio_Completo,
                            TipoPersona = (int)EnumTipoPersonaGP.NATURAL,
                            TipoDocumento = Convert.ToInt32(new Tb_Maestras_AD().GetRegistry(Temp.Id_Tipo_Documento).Valor1),
                            PrimerNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(0, Temp.Nombres.IndexOf(" ")) : Temp.Nombres.Trim(),
                            SegundoNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(Temp.Nombres.IndexOf(" ") + 1, Temp.Nombres.Length - (Temp.Nombres.IndexOf(" ") + 1)) : "",
                            ApellidoPaterno = Temp.Apellido_Paterno,
                            ApellidoMaterno = Temp.Apellido_Materno,
                            FormaPago = Cabecera.Id_CondicionPago,
                            Colegiado = Temp.Colegiado,
                            Email = (Cabecera.Correo == null) ? "cruedas@cmp.gob.pe" : Cabecera.Correo,
                            Celular = ""
                        });
                    }
                    else
                    {
                        if (TempEmpresa == null)
                        {
                            var y2 = new Cliente_AD().GrabarDatos(new ClienteClover()
                            {
                                NroDocumento = Temp.Nro_Documento,
                                NombreCompleto = Temp.Apellido_Paterno + ' ' + Temp.Apellido_Materno + ", " + Temp.Nombres,
                                //Clase = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor2,
                                Clase = vConsejo.Valor2,
                                Pais = "PERÙ",
                                Departamento = Variables.ClienteComun,
                                Provincia = Variables.ClienteComun,
                                Distrito = Variables.ClienteComun,
                                Direccion1 = Variables.ClienteComun,
                                Direccion2 = Variables.ClienteComun,
                                TipoPersona = (int)EnumTipoPersonaGP.NATURAL,
                                TipoDocumento = Convert.ToInt32(new Tb_Maestras_AD().GetRegistry(Temp.Id_Tipo_Documento).Valor1),
                                PrimerNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(0, Temp.Nombres.IndexOf(" ")) : Temp.Nombres.Trim(),
                                SegundoNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(Temp.Nombres.IndexOf(" ") + 1, Temp.Nombres.Length - (Temp.Nombres.IndexOf(" ") + 1)) : "",
                                ApellidoPaterno = Temp.Apellido_Paterno,
                                ApellidoMaterno = Temp.Apellido_Materno,
                                FormaPago = Cabecera.Id_CondicionPago,
                                Colegiado = Temp.Colegiado,
                                Email = (Cabecera.Correo == null) ? "cruedas@cmp.gob.pe" : Cabecera.Correo,
                                Celular = ""
                            });
                        }
                        else
                        {
                            var y2 = new Cliente_AD().GrabarDatos(new ClienteClover()
                            {
                                NroDocumento = TempEmpresa.Ruc,
                                NombreCompleto = TempEmpresa.Nombre_Comercial,
                                //Clase = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor2,
                                Clase = vConsejo.Valor2,
                                Pais = "PERÙ",
                                Departamento = Variables.ClienteComun,
                                Provincia = Variables.ClienteComun,
                                Distrito = Variables.ClienteComun,
                                Direccion1 = Variables.ClienteComun,
                                Direccion2 = Variables.ClienteComun,
                                TipoPersona = (int)EnumTipoPersonaGP.JURIDICA,
                                TipoDocumento = Convert.ToInt32(new Tb_Maestras_AD().GetRegistry(Convert.ToInt32(EnumTipoDocumento.RUC)).Valor1),
                                PrimerNombre = Variables.ClienteComun,
                                SegundoNombre = Variables.ClienteComun,
                                ApellidoPaterno = Variables.ClienteComun,
                                ApellidoMaterno = Variables.ClienteComun,
                                FormaPago = Cabecera.Id_CondicionPago,
                                Colegiado = Variables.Colegiado,
                                Email = (Cabecera.Correo == null) ? "cruedas@cmp.gob.pe" : Cabecera.Correo,
                                Celular = ""
                            });
                        }
                    }

                    vRst = new Factura_AD().Grabar(vFactura,vId_Comprobante);

                    #endregion
                    if (vRst == 1) Full.Complete();
                    Full.Dispose();
                    return vRst;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    Full.Dispose();
                    throw;
                }
            }
        }

        public int ProcesarCuota(int vId_Persona, int vId_Comprobante, string vUsuario)
        {
            int vRst = 0;
            using (var Full = new TransactionScope(TransactionScopeOption.Suppress))
            {
                try
                {
                    Tb_Persona_Natural Temp = new Tb_Persona_Natural_AD().GetRegistry(vId_Persona);

                    var Cabecera = new Tb_Comprobantecabecera_AD().GetRegistry(vId_Comprobante);

                    #region Para los comprobantes que se generan automaticamente

                    if (Cabecera.Id_EstadoComprobante == (int)EnumEstadoComprobante.GUARDADO)
                    {
                        Cabecera.Fec_Modifica = Variables.Hoy;
                        Cabecera.Flg_Activo = Variables.Activo;
                        Cabecera.Id_EstadoComprobante = (int)EnumEstadoComprobante.EMITIDO;
                        Cabecera.Usu_Modifica = vUsuario;
                        Cabecera = new Tb_Comprobantecabecera_AD().Update(Cabecera);

                        List<Tb_Cobranza> vLstCobranza = new Tb_Cobranza_AD().List("", vId_Comprobante);

                        if (vLstCobranza.Count == 0)
                        {
                            Tb_Cobranza Cobranza = new Tb_Cobranza_AD().GetRegistry_UltimaCuota(Cabecera.Id_Colegiado);

                            if (Cobranza == null)
                            {

                            }
                            else
                            {
                                if (Cobranza.Mes == 12)
                                {
                                    Cobranza.Mes = 1;
                                    Cobranza.Año = Cobranza.Año + 1;
                                }
                                else
                                {
                                    Cobranza.Mes = Cobranza.Mes + 1;
                                }
                                Cobranza.Fecha_Pagado = Cobranza.Fecha = Cobranza.Fec_Ingreso = Cobranza.Fec_Modifica = Variables.Hoy;
                                Cobranza.Fecha_Envio = Cobranza.Fecha_Pagado = null;
                                Cobranza.Id_Comprobante = Cabecera.Id_Comprobante;
                            }
                        }
                        else
                        {
                            foreach (var item in vLstCobranza)
                            {
                                item.Fec_Modifica = Variables.Hoy;
                                item.Flg_Activo = Variables.Activo;
                                item.Usu_Modifica = vUsuario;
                                item.Fecha_Pagado = Variables.Hoy;
                                item.Nro_Recibo = (item.Nro_Recibo == null) ? "" : item.Nro_Recibo;
                                item.Flg_VaPagar = Variables.Activo;
                                new Tb_Cobranza_AD().Update(item);
                            }
                        }

                    }
                    #endregion

                    #region Procesar venta en GP

                    string vNumeroGp = new Numeracion_AD().GetVaue(Cabecera.Tipo_Documentosunat, Cabecera.Nrodocumento_Gp.Substring(0, Cabecera.Nrodocumento_Gp.IndexOf("-"))).Trim();
                    Cabecera.Nrodocumento_Gp = vNumeroGp;
                    Cabecera.Nro_Documento = Cabecera.Nrodocumento_Gp.Substring(Cabecera.Nrodocumento_Gp.IndexOf("-") + 1, Cabecera.Nrodocumento_Gp.Length - (Cabecera.Nrodocumento_Gp.IndexOf("-") + 1));
                    new Tb_Comprobantecabecera_AD().Update(Cabecera);

                    if (Cabecera.Nrodocumento_Gp == "") Cabecera.Nrodocumento_Gp = Cabecera.Opcional + "-" + Cabecera.Nro_Documento;

                    Factura vFactura = new Factura();
                    var xxx = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor1;
                    vFactura.Cabecera = new Co_Cabecera()
                    {
                        FechaEmision = Cabecera.Fec_Ingreso,
                        FechaEnvio = Variables.Hoy,
                        IdCliente = Temp.Nro_Documento,
                        IdCondicionPago = Cabecera.Id_CondicionPago,
                        IdDocumento = Cabecera.Nrodocumento_Gp.Substring(0, Cabecera.Nrodocumento_Gp.IndexOf("-")),
                        //IdLote = xxx + " " + Cabecera.Fec_Ingreso.Year.ToString() + Cabecera.Fec_Ingreso.Month.ToString("00") + Cabecera.Fec_Ingreso.Day.ToString("00"),
                        IdLote = xxx.Substring(4, 2) + vUsuario,
                        IdMoneda = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Moneda).Valor1,
                        IdSitio = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor1,
                        IdTerritorio = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Origen).Valor1,
                        IdVendedor = "",
                        NroGuia = "",
                        //NumeroDocumento = Cabecera.Nrodocumento_Gp,
                        NumeroDocumento = vNumeroGp,
                        NumOCCliente = "",
                        Reference = Cabecera.Observacion,
                        TipoDocumento = 3,
                        Usuario = vUsuario
                    };

                    vFactura.Detalle = new List<Co_Detalle>();
                    int Count = 0;
                    foreach (var item in new Tb_Comprobantedetalle_AD().List(vId_Comprobante, 1/*LISTAR PARA PROCESAR EN GP*/))
                    {
                        Count = Count + 1;
                        vFactura.Detalle.Add(new Co_Detalle()
                        {
                            Cantidad = Convert.ToInt32(item.Cantidad),
                            DesArticulo = item.Descripcion,
                            Descuento = item.Descuento,
                            Fecha = Cabecera.Fec_Ingreso,
                            IdCliente = Temp.Nro_Documento,
                            IdSitio = vFactura.Cabecera.IdSitio,
                            Moneda = vFactura.Cabecera.IdMoneda,
                            NumArticulo = item.Codigo_Servicio,
                            NumeroDocumento = Cabecera.Nrodocumento_Gp,
                            NumeroTelefono = "",
                            PrecioUnitario = item.Precio,
                            Secuencia = Count,
                            SerLotProducto = "",
                            TipoDocumento = 3,
                            UnidadMedida = Variables.UnidadMedida
                        });
                    }

                    vFactura.Cobranza = new Co_Cobros()
                    {
                        FechaEmision = Cabecera.Fec_Ingreso,
                        IdCliente = Temp.Nro_Documento,
                        IdDocumento = vFactura.Cabecera.IdDocumento,
                        IdSitio = vFactura.Cabecera.IdSitio,
                        Monto = Cabecera.Total,
                        NroOperacion = Cabecera.Id_Comprobante.ToString(),
                        NumeroDocumento = Cabecera.Nrodocumento_Gp,
                        TipoDocumento = 3,
                        Chequera = Cabecera.Id_Chequera.Trim(),
                        TipoPAgo = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Tipo_Pago).Valor1
                    };


                    var Direccion2 = new Tb_Domicilio_AD().GetRegistry(vId_Persona);
                    var y2 = new Cliente_AD().GrabarDatos(new ClienteClover()
                    {
                        NroDocumento = Temp.Nro_Documento,
                        NombreCompleto = Temp.Apellido_Paterno + ' ' + Temp.Apellido_Materno + ", " + Temp.Nombres,
                        Clase = new Tb_Maestras_AD().GetRegistry(Cabecera.Id_Sitio_Destino).Valor2,
                        Pais = "PERÙ",
                        Departamento = Direccion2.Departamento,
                        Provincia = Direccion2.Provincia,
                        Distrito = Direccion2.Distrito,
                        Direccion1 = Direccion2.Domicilio_Completo,
                        Direccion2 = Direccion2.Domicilio_Completo,
                        TipoPersona = (int)EnumTipoPersonaGP.NATURAL,
                        TipoDocumento = Convert.ToInt32(new Tb_Maestras_AD().GetRegistry(Temp.Id_Tipo_Documento).Valor1),
                        PrimerNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(0, Temp.Nombres.IndexOf(" ")) : Temp.Nombres.Trim(),
                        SegundoNombre = Temp.Nombres.Trim().IndexOf(" ") > 0 ? Temp.Nombres.Substring(Temp.Nombres.IndexOf(" ") + 1, Temp.Nombres.Length - (Temp.Nombres.IndexOf(" ") + 1)) : "",
                        ApellidoPaterno = Temp.Apellido_Paterno,
                        ApellidoMaterno = Temp.Apellido_Materno,
                        FormaPago = Cabecera.Id_CondicionPago,
                        Colegiado = Temp.Colegiado,
                        Email = (Cabecera.Correo == null) ? "cruedas@cmp.gob.pe" : Cabecera.Correo,
                        Celular = ""
                    });

                    vRst = new Factura_AD().Grabar(vFactura,vId_Comprobante);

                    #endregion
                    if (vRst == 1) Full.Complete();
                    Full.Dispose();
                    return vRst;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    Full.Dispose();
                    throw;
                }
            }
        }


        public Tb_Persona_Natural UpdateColegiado_Cobranza(Tb_Persona_Natural vTb_Persona_Natural)
        {
            try
            {
                vTb_Persona_Natural.Fec_Modifica = Variables.Hoy;
                return new Tb_Persona_Natural_AD().Update(vTb_Persona_Natural);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public bool Activar_Colegiados(string vIds, string vUsuario)
        {
            try
            {
                string[] vParams = vIds.Split(',');
                foreach (string vId in vParams)
                {
                    if (vId == "") break;
                    var Temp = new Tb_Persona_Natural_AD().GetRegistry(Convert.ToInt32(vId));
                    Temp.Id_Estado_Actual = (int)EnumEstadoMatricula.ACTIVO;
                    Temp.Fec_Modifica = Variables.Hoy;
                    Temp.Usu_Modifica = vUsuario;
                    new Tb_Persona_Natural_AD().Update(Temp);

                    new Tb_Colegiado_Estado_AD().Insert(new Tb_Colegiado_Estado()
                    {
                        Fec_Ingreso = Variables.Hoy,
                        Fec_Modifica = Variables.Hoy,
                        Flg_Activo = Variables.Activo,
                        Id_Estado = 0,
                        Id_Estado_Colegiado = Temp.Id_Estado_Actual,
                        Id_Persona = Temp.Id_Persona,
                        ObservacionEstado = "REACTIVADO EN EL SISTEMA POR " + vUsuario.ToUpper() + " EL " + Variables.Hoy,
                        Usu_Ingreso = vUsuario,
                        Usu_Modifica = vUsuario
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public Tb_Persona_Natural GetRegistry(string vNumero)
        {
            try
            {
                return new Tb_Persona_Natural_AD().GetRegistry(vNumero);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public int UpdateHabilidad(int vId_Persona, string vUsuario)
        {
            try
            {
                return new Tb_Persona_Natural_AD().UpdateHabilidad(vId_Persona, vUsuario, Variables.Hoy);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }


        public ColegiadoMicro ActualizarColegiado(ColegiadoMicro vPersona)
        {
            try
            {
                vPersona.Fec_Ingreso = vPersona.Fec_Modifica = Variables.Hoy;
                vPersona.Flg_Activo = Variables.Activo;
                vPersona = new Tb_Persona_Natural_AD().InsertColegiado(vPersona);

                vPersona.Edad = Variables.Hoy.AddTicks(-vPersona.Fecha_Nacio.Ticks).Year - 1;
                vPersona.Opcional = "OK";
                return vPersona;
            }
            catch (Exception ex)
            {
                vPersona.Opcional = "ERR";
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        #endregion
    }
}
