/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Cobranza_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Cobranza
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
    public partial class Tb_Cobranza_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Cobranza
        /// </summary>
        /// <returns>Listado de Tb_Cobranza</returns>
        public List<Tb_Cobranza> List(string vValor, int vTipo, bool vSi)
        {
            List<Tb_Cobranza> vLista = new List<Tb_Cobranza>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COBRANZA"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTipo);
                vCmd.CommandTimeout = 0;
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Cobranza(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Cobranza basado en su clave primaria
        /// </summary>
        /// <param name="ID_COBRO">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Cobranza GetRegistry(int vId_Cobro)
        {
            Tb_Cobranza vTb_Cobranza = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COBRANZA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COBRO", vId_Cobro);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Cobranza = new Tb_Cobranza(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Cobranza;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Cobranza
        /// </summary>
        /// <param name="Tb_Cobranza">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Cobranza Insert(Tb_Cobranza vTb_Cobranza)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COBRANZA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vTb_Cobranza.Id_Colegiado);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_COLEGIADO", vTb_Cobranza.Id_Estado_Colegiado);
                vCmd.Parameters.AddWithValue("@COLEGIATURA", vTb_Cobranza.Colegiatura);
                vCmd.Parameters.AddWithValue("@AÑO", vTb_Cobranza.Año);
                vCmd.Parameters.AddWithValue("@MES", vTb_Cobranza.Mes);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Cobranza.Id_Servicio);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Cobranza.Descuento);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Cobranza.Monto);
                vCmd.Parameters.AddWithValue("@FECHA", vTb_Cobranza.Fecha);
                vCmd.Parameters.AddWithValue("@FECHA_ENVIO", vTb_Cobranza.Fecha_Envio);
                vCmd.Parameters.AddWithValue("@FECHA_RECIBIDO", vTb_Cobranza.Fecha_Recibido);
                vCmd.Parameters.AddWithValue("@FECHA_PAGADO", vTb_Cobranza.Fecha_Pagado);
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Cobranza.Id_Comprobante);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Cobranza.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Cobranza.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Cobranza.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Cobranza.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Cobranza.Fec_Modifica);
                vTb_Cobranza.Id_Cobro = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Cobranza.Id_Cobro > 0) return vTb_Cobranza; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Cobranza
        /// </summary>
        /// <param name="Tb_Cobranza">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Cobranza Update(Tb_Cobranza vTb_Cobranza)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COBRANZA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COBRO", vTb_Cobranza.Id_Cobro);
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vTb_Cobranza.Id_Colegiado);
                vCmd.Parameters.AddWithValue("@ID_ESTADO_COLEGIADO", vTb_Cobranza.Id_Estado_Colegiado);
                vCmd.Parameters.AddWithValue("@COLEGIATURA", vTb_Cobranza.Colegiatura);
                vCmd.Parameters.AddWithValue("@AÑO", vTb_Cobranza.Año);
                vCmd.Parameters.AddWithValue("@MES", vTb_Cobranza.Mes);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vTb_Cobranza.Id_Servicio);
                vCmd.Parameters.AddWithValue("@DESCUENTO", vTb_Cobranza.Descuento);
                vCmd.Parameters.AddWithValue("@MONTO", vTb_Cobranza.Monto);
                vCmd.Parameters.AddWithValue("@FECHA", vTb_Cobranza.Fecha);
                vCmd.Parameters.AddWithValue("@FECHA_ENVIO", vTb_Cobranza.Fecha_Envio);
                vCmd.Parameters.AddWithValue("@FECHA_RECIBIDO", vTb_Cobranza.Fecha_Recibido);
                vCmd.Parameters.AddWithValue("@FECHA_PAGADO", vTb_Cobranza.Fecha_Pagado);
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vTb_Cobranza.Id_Comprobante);                
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Cobranza.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Cobranza.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Cobranza.Fec_Modifica);
                vCmd.Parameters.AddWithValue("@ID_ENTIDADPAGADORA", vTb_Cobranza.Id_Entidad_Paga);
                vCmd.Parameters.AddWithValue("@NRO_RECIBO", vTb_Cobranza.Nro_Recibo);
                vCmd.Parameters.AddWithValue("@FLG_VAPAGAR", vTb_Cobranza.Flg_VaPagar);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Cobranza; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Cobranza en base a su clave primaria
        /// </summary>
        /// <param name="ID_COBRO">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Cobro, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_COBRANZA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COBRO", vId_Cobro);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos


        //public int Generar_Comprobante(int vId_Cobro, string vUsuario, DateTime vFecha)
        //{
        //    int vResp = 0;
        //    using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COMPROBANTE_AUTOMATICA"))
        //    {
        //        vCmd.Parameters.AddWithValue("@ID_COBRO", vId_Cobro);
        //        vCmd.Parameters.AddWithValue("@USU_INGRESO", vUsuario);
        //        vCmd.Parameters.AddWithValue("@FEC_INGRESO", vFecha);
        //        vResp = Convert.ToInt32(vCmd.ExecuteScalar());
        //        vCmd.Dispose(); AdoNet.Dispose();
        //    }
        //    return vResp;
        //}

        public int Generar_Comprobante(string vIds_Cobro, string vUsuario, DateTime vFecha, int vId_Persona)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COMPROBANTE_AUTOMATICA"))
            {
                //vCmd.Parameters.AddWithValue("@ID_COBRO", vIds_Cobro);
                vCmd.Parameters.AddWithValue("@ID_COBROS", vIds_Cobro);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vFecha);
                vCmd.Parameters.AddWithValue("@ID_USUARIO", vId_Persona);
                vResp = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }


        public List<Tb_Cobranza> List(string vId_Cobros, int vId_Comprobante)
        {
            List<Tb_Cobranza> vLista = new List<Tb_Cobranza>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COBRANZA_ID"))
            {
                vCmd.Parameters.AddWithValue("@ID_COBRO", vId_Cobros);
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Cobranza(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public Tb_Cobranza GetRegistry_UltimaCuota(int vId_Colegiado)
        {
            Tb_Cobranza vTb_Cobranza = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COBRANZA_ULTIMA"))
            {
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vId_Colegiado);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Cobranza = new Tb_Cobranza(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Cobranza;
        }

        public List<Tb_Cobranza> ListPlanilla(string vValor, DateTime? vPeriodo, int vIdConsejo, int vId_Entidad)
        {
            List<Tb_Cobranza> vLista = new List<Tb_Cobranza>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COBRANZAPLANILLA"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@FECHA", vPeriodo);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO_REGIONAL", vIdConsejo);
                vCmd.Parameters.AddWithValue("@ID_ENTIDAD_PAGA", vId_Entidad);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Cobranza(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }


        public List<Tb_Cobranza> List()
        {
            throw new NotImplementedException();
        }

        public List<Tb_Cobranza> List(int vId_Comprobante, long vId_Servicio)
        {
            List<Tb_Cobranza> vLista = new List<Tb_Cobranza>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_COBRANZA_SERVICIOCOMPROBANTE"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vId_Servicio);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Cobranza(vRdr));
                        }
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public Tb_Cobranza GetRegistry(int vIdColegiado, int vAnio, int vMes, int vIdServicio)
        {
            Tb_Cobranza vTb_Cobranza = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COBRANZA_IDS"))
            {
                vCmd.Parameters.AddWithValue("@ID_COLEGIADO", vIdColegiado);
                vCmd.Parameters.AddWithValue("@ANIO", vAnio);
                vCmd.Parameters.AddWithValue("@MES", vMes);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vIdServicio);

                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Cobranza = new Tb_Cobranza(vRdr);
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Cobranza;
        }

        public Tuple<int, int, int> GetUltimaCobranza(int vId_Comprobante, long vId_Servicio)
        {
            Tuple<int, int, int> Temp = new Tuple<int,int,int>(0,0,0);
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COBRANZA_SERVICIOCOMPROBANTE"))
            {
                vCmd.Parameters.AddWithValue("@ID_COMPROBANTE", vId_Comprobante);
                vCmd.Parameters.AddWithValue("@ID_SERVICIO", vId_Servicio);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        Temp = new Tuple<int,int,int>(Convert.ToInt32(vRdr[0]), Convert.ToInt32(vRdr[1]), Convert.ToInt32(vRdr[2]));
                    }
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return Temp;
        }

        #endregion
    }
}