/*----------------------------------------------------------------------------------------
ARCHIVO CLASE     : Cliente_LN.cs
Objetivo          : Clase referida a los métodos de Lógica de Negocio de la clase GP
Autor             : CMP-SISTEMAS (FRR)
Fecha Creación    : 09/06/2018 
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
    public partial class Articulo_LN : Base
    {
        #region Métodos Públicos Generales

        public List<Articulo> List_Articulo(string vTipoOperacion, string vFiltro, string vConsejo)
        {
            try
            {
                return new Articulos_AD().List_Articulo(vTipoOperacion, vFiltro, vConsejo,0,"",""/*id documento de referencia*/);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw;
            }
        }

        public List<Articulo> List_Articulo_SinCuota(string vTipoOperacion, string vFiltro, string vConsejo,int origen,string documento,string TipoArticulo)
        {
            try
            {
                var Temp1 = new Tb_Parametro_AD().List_Cuotas();
                var Temp2 = new Articulos_AD().List_Articulo(vTipoOperacion, vFiltro, vConsejo,origen, documento, TipoArticulo);
                //var Temp3 = from Full in Temp2 where Full.Codigo.Trim() != Temp1
                //var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));
                var Temp3 = Temp2.Where(p => !Temp1.Any(p2 => p2.Descripcion == p.Codigo)).ToList();
                return Temp3;
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