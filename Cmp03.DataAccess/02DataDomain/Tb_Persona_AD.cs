/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Persona
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
    public partial class Tb_Persona_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona
        /// </summary>
        /// <returns>Listado de Tb_Persona</returns>
        public List<Tb_Persona> List()
        {
            List<Tb_Persona> vLista = new List<Tb_Persona>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Persona(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Persona basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona GetRegistry(int vId_Persona)
        {
            Tb_Persona vTb_Persona = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona = new Tb_Persona(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Persona
        /// </summary>
        /// <param name="Tb_Persona">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Persona Insert(Tb_Persona vTb_Persona)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERSONA"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPO_PERSONA", vTb_Persona.Id_Tipo_Persona);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMERCIAL", vTb_Persona.Nombre_Comercial);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMPLETO", vTb_Persona.Nombre_Completo);
                vCmd.Parameters.AddWithValue("@RUC", vTb_Persona.Ruc);
                vCmd.Parameters.AddWithValue("@FLG_NACIONALIDAD", vTb_Persona.Flg_Nacionalidad);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Persona.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Persona.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona.Fec_Modifica);
                vTb_Persona.Id_Persona = Convert.ToInt32(vCmd.ExecuteScalar());
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vTb_Persona.Id_Persona > 0) return vTb_Persona; else return null;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona
        /// </summary>
        /// <param name="Tb_Persona">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona Update(Tb_Persona vTb_Persona)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERSONA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona.Id_Persona);
                vCmd.Parameters.AddWithValue("@ID_TIPO_PERSONA", vTb_Persona.Id_Tipo_Persona);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMERCIAL", vTb_Persona.Nombre_Comercial);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMPLETO", vTb_Persona.Nombre_Completo);
                vCmd.Parameters.AddWithValue("@RUC", vTb_Persona.Ruc);
                vCmd.Parameters.AddWithValue("@FLG_NACIONALIDAD", vTb_Persona.Flg_Nacionalidad);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona.Fec_Modifica);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Persona; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Persona en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERSONA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        #endregion

        #region Métodos Extendidos

        public List<ColegiadoMin> List_Bandeja(string vValor, int vIdEstado, int vIdConsejo)
        {
            List<ColegiadoMin> vLista = new List<ColegiadoMin>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_BANDEJA"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vIdEstado);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO_REGIONAL", vIdConsejo);
                vCmd.CommandTimeout = 0;
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new ColegiadoMin(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<EmpresaMin> List_EmpresaBandeja(string vValor, int vId_Consejo)
        {
            List<EmpresaMin> vLista = new List<EmpresaMin>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_EMPRESA_BANDEJA"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO", vId_Consejo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new EmpresaMin(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<Tb_Colegiado_Carnet> List_Carnets(string vValor, int vIdConsejo)
        {
            List<Tb_Colegiado_Carnet> vLista = new List<Tb_Colegiado_Carnet>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_CARNET"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO_REGIONAL", vIdConsejo);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Colegiado_Carnet(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<ColegiadoMin> List_Modal(string vValor)
        {
            List<ColegiadoMin> vLista = new List<ColegiadoMin>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_BASICO"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new ColegiadoMin(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<ColegiadoMin> List_Inactivos(string vValor, int vIdEstado, int vIdConsejo, DateTime vFecha = new DateTime())
        {
            List<ColegiadoMin> vLista = new List<ColegiadoMin>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_INACTIVOS"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vIdEstado);
                vCmd.Parameters.AddWithValue("@ID_CONSEJO_REGIONAL", vIdConsejo);
                vCmd.Parameters.AddWithValue("@FECHA", vFecha.ToShortDateString());
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new ColegiadoMin(vRdr));
                        }
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<FullConsulta> List_FullColegiado(int vEstadoCivil, string vCodCmpInicial, string vCodCmpFinal, string vSexo, string vConsejos, string vFecCmpInicial, string vFecCmpFinal, string vEstados, string vTiposDocumentos, int vEdadInicial, int vEdadFinal, string vFecRegInicial, string vFecRegFinal, string vUbigeo, string vUniversidad, string vNombre)
        {
            List<FullConsulta> vLista = new List<FullConsulta>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_FULLCONSULTA_MATRICULA"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPO_ESTADO_CIVIL", vEstadoCivil);
                vCmd.Parameters.AddWithValue("@CMP_INICIAL", vCodCmpInicial);
                vCmd.Parameters.AddWithValue("@CMP_FINAL", vCodCmpFinal);
                vCmd.Parameters.AddWithValue("@SEXO", vSexo);
                vCmd.Parameters.AddWithValue("@ID_CONSEJOS", vConsejos);
                vCmd.Parameters.AddWithValue("@FEC_CMPINICIAL", vFecCmpInicial);
                vCmd.Parameters.AddWithValue("@FEC_CMPFINAL", vFecCmpFinal);
                vCmd.Parameters.AddWithValue("@ID_CMPESTADOS", vEstados);
                vCmd.Parameters.AddWithValue("@ID_TIPODOCUMENTOS", vTiposDocumentos);
                vCmd.Parameters.AddWithValue("@EDAD_INICIAL", vEdadInicial);
                vCmd.Parameters.AddWithValue("@EDAD_FINAL", vEdadFinal);
                vCmd.Parameters.AddWithValue("@REGISTRO_INICIAL", vFecRegInicial);
                vCmd.Parameters.AddWithValue("@REGISTRO_FINAL", vFecRegFinal);
                vCmd.Parameters.AddWithValue("@UBICACION_GEOGRAFICA", vUbigeo);
                vCmd.Parameters.AddWithValue("@UNIVERSIDAD", vUniversidad);
                vCmd.Parameters.AddWithValue("@NOMBRE_COMPLETO", vNombre);
                
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows) while (vRdr.Read()) vLista.Add(new FullConsulta(vRdr));
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        public List<ColegiadoMin> List_Persona(string vValor, string vTipo)
        {
            List<ColegiadoMin> vLista = new List<ColegiadoMin>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_BUSQUEDA"))
            {
                vCmd.Parameters.AddWithValue("@VALOR", vValor);
                vCmd.Parameters.AddWithValue("@TIPO", vTipo);
                vCmd.CommandTimeout = 0;
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    //if (vRdr.HasRows)
                    //{
                        while (vRdr.Read())
                        {
                            vLista.Add(new ColegiadoMin(vRdr));
                        }
                    //}
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vLista;
        }

        #endregion
    }
}