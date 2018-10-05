/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Tb_Persona_Natural_AD.cs
Objetivo          : Clase referida a los métodos de Acceso a datos de la clase Tb_Persona_Natural
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
    public partial class Tb_Persona_Natural_AD : Base
    {
        #region Métodos Públicos Generales

        /// <summary>
        /// Método que lista los registros de Tb_Persona_Natural
        /// </summary>
        /// <returns>Listado de Tb_Persona_Natural</returns>
        public List<Tb_Persona_Natural> List()
        {
            List<Tb_Persona_Natural> vLista = new List<Tb_Persona_Natural>();
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_LISTAR_PERSONA_NATURAL"))
            {
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        while (vRdr.Read())
                        {
                            vLista.Add(new Tb_Persona_Natural(vRdr));
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
        /// Método que recupera un registro de tipo Tb_Persona_Natural basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public Tb_Persona_Natural GetRegistry(int vId_Persona)
        {
            Tb_Persona_Natural vTb_Persona_Natural = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_NATURAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Natural = new Tb_Persona_Natural(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Natural;
        }

        /// <summary>
        /// Inserta un Objeto de tipo Tb_Persona_Natural
        /// </summary>
        /// <param name="Tb_Persona_Natural">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public Tb_Persona_Natural Insert(Tb_Persona_Natural vTb_Persona_Natural)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_PERSONA_NATURAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Natural.Id_Persona);
                vCmd.Parameters.AddWithValue("@COLEGIADO", vTb_Persona_Natural.Colegiado);
                vCmd.Parameters.AddWithValue("@APELLIDO_PATERNO", vTb_Persona_Natural.Apellido_Paterno);
                vCmd.Parameters.AddWithValue("@APELLIDO_MATERNO", vTb_Persona_Natural.Apellido_Materno);
                vCmd.Parameters.AddWithValue("@NOMBRES", vTb_Persona_Natural.Nombres);
                vCmd.Parameters.AddWithValue("@ID_GRUPO_SANGUINEO", vTb_Persona_Natural.Id_Grupo_Sanguineo);
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", vTb_Persona_Natural.Id_Tipo_Documento);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Persona_Natural.Nro_Documento);
                vCmd.Parameters.AddWithValue("@ID_TIPO_ESTADO_CIVIL", vTb_Persona_Natural.Id_Tipo_Estado_Civil);
                vCmd.Parameters.AddWithValue("@SEXO", vTb_Persona_Natural.Sexo);
                vCmd.Parameters.AddWithValue("@FECHA_NACIO", vTb_Persona_Natural.Fecha_Nacio);
                vCmd.Parameters.AddWithValue("@LUGAR_NACIMIENTO", vTb_Persona_Natural.Lugar_Nacimiento);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Persona_Natural.Observacion);
                vCmd.Parameters.AddWithValue("@FEC_COLEGIADO", vTb_Persona_Natural.Fec_Colegiado);
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vTb_Persona_Natural.Id_Estado_Actual);
                vCmd.Parameters.AddWithValue("@ID_CARNET", vTb_Persona_Natural.Id_Carnet);
                vCmd.Parameters.AddWithValue("@ID_HABILIDAD", vTb_Persona_Natural.Id_Habilidad);
                vCmd.Parameters.AddWithValue("@ID_ENTIDAD_PAGA", vTb_Persona_Natural.Id_Entidad_Paga);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona_Natural.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Persona_Natural.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Persona_Natural.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona_Natural.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona_Natural.Fec_Modifica);
                vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Natural;
        }

        /// <summary>
        /// Actualiza un Objeto del tipo Tb_Persona_Natural
        /// </summary>
        /// <param name="Tb_Persona_Natural">Objeto a ser actualizado</param>
        /// <returns>Retorna el mismo objeto actualizado</returns>
        public Tb_Persona_Natural Update(Tb_Persona_Natural vTb_Persona_Natural)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERSONA_NATURAL"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona_Natural.Id_Persona);
                vCmd.Parameters.AddWithValue("@COLEGIADO", vTb_Persona_Natural.Colegiado);
                vCmd.Parameters.AddWithValue("@APELLIDO_PATERNO", vTb_Persona_Natural.Apellido_Paterno);
                vCmd.Parameters.AddWithValue("@APELLIDO_MATERNO", vTb_Persona_Natural.Apellido_Materno);
                vCmd.Parameters.AddWithValue("@NOMBRES", vTb_Persona_Natural.Nombres);
                vCmd.Parameters.AddWithValue("@ID_GRUPO_SANGUINEO", vTb_Persona_Natural.Id_Grupo_Sanguineo);
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", vTb_Persona_Natural.Id_Tipo_Documento);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Persona_Natural.Nro_Documento);
                vCmd.Parameters.AddWithValue("@ID_TIPO_ESTADO_CIVIL", vTb_Persona_Natural.Id_Tipo_Estado_Civil);
                vCmd.Parameters.AddWithValue("@SEXO", vTb_Persona_Natural.Sexo);
                vCmd.Parameters.AddWithValue("@FECHA_NACIO", vTb_Persona_Natural.Fecha_Nacio);
                vCmd.Parameters.AddWithValue("@LUGAR_NACIMIENTO", vTb_Persona_Natural.Lugar_Nacimiento);
                vCmd.Parameters.AddWithValue("@OBSERVACION", vTb_Persona_Natural.Observacion);
                vCmd.Parameters.AddWithValue("@FEC_COLEGIADO", vTb_Persona_Natural.Fec_Colegiado);
                vCmd.Parameters.AddWithValue("@ID_ESTADO", vTb_Persona_Natural.Id_Estado_Actual);
                vCmd.Parameters.AddWithValue("@ID_CARNET", vTb_Persona_Natural.Id_Carnet);
                vCmd.Parameters.AddWithValue("@ID_HABILIDAD", vTb_Persona_Natural.Id_Habilidad);
                vCmd.Parameters.AddWithValue("@ID_ENTIDAD_PAGA", vTb_Persona_Natural.Id_Entidad_Paga);
                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona_Natural.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona_Natural.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona_Natural.Fec_Modifica);
                if (vTb_Persona_Natural.Fec_Fallecio!= null) vCmd.Parameters.AddWithValue("@FEC_FALLECIO ", (vTb_Persona_Natural.Fec_Fallecio.Value.ToString("dd/MM/yyyy") == "01/01/0001") ? null : vTb_Persona_Natural.Fec_Fallecio);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            if (vResp > 0) return vTb_Persona_Natural; else return null;
        }

        /// <summary>
        /// Elimina un registo de tipo Tb_Persona_Natural en base a su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Número que indica la cantidad de registros afectados por la eliminación</returns>
        public int Delete(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ELIMINAR_PERSONA_NATURAL"))
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

        public Tb_Persona_Natural GetRegistry(int vId_TipoDocumento, string vNumero)
        {
            Tb_Persona_Natural vTb_Persona_Natural = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_DOCUMENTO"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", vId_TipoDocumento);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vNumero);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Natural = new Tb_Persona_Natural(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Natural;
        }

        public int UpdateMatricula(int vId_Persona, int vId_Carnet, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_PERSONA_MATRICULA"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                vCmd.Parameters.AddWithValue("@ID_CARNET", vId_Carnet);                
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vUsuario);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        public Tb_Persona_Natural GetRegistry(string vNumero)
        {
            Tb_Persona_Natural vTb_Persona_Natural = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_PERSONA_COLEGIADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", 0);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vNumero);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    {
                        vRdr.Read();
                        vTb_Persona_Natural = new Tb_Persona_Natural(vRdr);
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Natural;
        }

        public int UpdateHabilidad(int vId_Persona, string vUsuario, DateTime vFecha)
        {
            int vResp = 0;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_ACTUALIZAR_COLEGIADO_HABILIDAD"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                vCmd.Parameters.AddWithValue("@USUARIO", vUsuario);
                vCmd.Parameters.AddWithValue("@FECHA", vFecha);
                vResp = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vResp;
        }

        /// <summary>
        /// Método que recupera un registro de tipo Tb_Persona_Natural basado en su clave primaria
        /// </summary>
        /// <param name="ID_PERSONA">Clave primaria del registro a eliminar</param>
        /// <returns>Objeto recuperado</returns>
        public ColegiadoMicro GetRegistryColegiado(int vId_Persona)
        {
            ColegiadoMicro vTb_Persona_Natural = null;
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_OBTENER_COLEGIADO"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vId_Persona);
                using (SqlDataReader vRdr = vCmd.ExecuteReader())
                {
                    if (vRdr.HasRows)
                    //if (vRdr.Read())
                    {
                        vRdr.Read();
                        vTb_Persona_Natural = new ColegiadoMicro(vRdr);
                    }
                    else
                    {
                        vTb_Persona_Natural = new ColegiadoMicro();
                    }
                    vRdr.Close();
                    vRdr.Dispose();
                }
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona_Natural;
        }


        /// <summary>
        /// Inserta un Objeto de tipo Tb_Persona_Natural
        /// </summary>
        /// <param name="Tb_Persona_Natural">Objeto a ser ingresado</param>
        /// <returns>Retorna el mismo objeto con los datos actualizados</returns>
        public ColegiadoMicro InsertColegiado(ColegiadoMicro vTb_Persona)
        {
            using (SqlCommand vCmd = AdoNet.GetCommand("DBO.DIN_SP_INSERTAR_COLEGIADOTEMP"))
            {
                vCmd.Parameters.AddWithValue("@ID_PERSONA", vTb_Persona.Id_Persona);
                vCmd.Parameters.AddWithValue("@COLEGIADO", vTb_Persona.Colegiado);
                vCmd.Parameters.AddWithValue("@APELLIDO_PATERNO", vTb_Persona.Apellido_Paterno);
                vCmd.Parameters.AddWithValue("@APELLIDO_MATERNO", vTb_Persona.Apellido_Materno);
                vCmd.Parameters.AddWithValue("@NOMBRES", vTb_Persona.Nombres);
                vCmd.Parameters.AddWithValue("@ID_TIPO_DOCUMENTO", vTb_Persona.Id_Tipo_Documento);
                vCmd.Parameters.AddWithValue("@NRO_DOCUMENTO", vTb_Persona.Nro_Documento);
                
                vCmd.Parameters.AddWithValue("@ID_TIPO_VIA", vTb_Persona.Id_Tipo_Via);
                vCmd.Parameters.AddWithValue("@NOMBRE_VIA", vTb_Persona.Nombre_Via);
                vCmd.Parameters.AddWithValue("@NRO_VIA", vTb_Persona.Nro_Via);
                vCmd.Parameters.AddWithValue("@NRO_KM", vTb_Persona.Nro_Km);
                vCmd.Parameters.AddWithValue("@MANZANA", vTb_Persona.Manzana);
                vCmd.Parameters.AddWithValue("@LOTE", vTb_Persona.Lote);
                vCmd.Parameters.AddWithValue("@NRO_INTERIOR", vTb_Persona.Nro_Interior);
                vCmd.Parameters.AddWithValue("@NRO_DEPARTAMENTO", vTb_Persona.Nro_Departamento);
                vCmd.Parameters.AddWithValue("@ID_TIPO_ZONA", Convert.ToInt32(vTb_Persona.Id_Tipo_Zona));
                vCmd.Parameters.AddWithValue("@NOMBRE_ZONA", vTb_Persona.Nombre_Zona);
                vCmd.Parameters.AddWithValue("@REFERENCIA", vTb_Persona.Referencia);
                vCmd.Parameters.AddWithValue("@DOMICILIO_COMPLETO", vTb_Persona.Domicilio_Completo);
                vCmd.Parameters.AddWithValue("@ID_UBIGEO", vTb_Persona.Id_Ubigeo);

                vCmd.Parameters.AddWithValue("@CELULAR", vTb_Persona.Celular);
                vCmd.Parameters.AddWithValue("@CORREO", vTb_Persona.Correo);

                vCmd.Parameters.AddWithValue("@FLG_ACTIVO", vTb_Persona.Flg_Activo);
                vCmd.Parameters.AddWithValue("@USU_INGRESO", vTb_Persona.Usu_Ingreso);
                vCmd.Parameters.AddWithValue("@FEC_INGRESO", vTb_Persona.Fec_Ingreso);
                vCmd.Parameters.AddWithValue("@USU_MODIFICA", vTb_Persona.Usu_Modifica);
                vCmd.Parameters.AddWithValue("@FEC_MODIFICA", vTb_Persona.Fec_Modifica);
                var x = vCmd.ExecuteNonQuery();
                vCmd.Dispose(); AdoNet.Dispose();
            }
            return vTb_Persona;
        }

        #endregion
    }
}