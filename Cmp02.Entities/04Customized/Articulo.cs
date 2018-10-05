using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Utildatatool;

namespace Cmp02.Entities
{
    public class Articulo
    {
        [DataMember]
        public long IdArticulo { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Linea { get; set; }
        [DataMember]
        public string Familia { get; set; }
        [DataMember]
        public string Grupo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Marca { get; set; }
        [DataMember]
        public string Unidad { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public decimal PrecioUnitario { get; set; }
        [DataMember]
        public int StockActual { get; set; }
        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public Int32 CantidadMax { get; set; }

        public Articulo(System.Data.IDataReader Reader)
        {
            if (ReadCol.Exist(Reader, "IdArticulo")) IdArticulo = Convert.ToInt64(Reader["IdArticulo"]);
            if (ReadCol.Exist(Reader, "Codigo")) Codigo = Convert.ToString(Reader["Codigo"]);
            if (ReadCol.Exist(Reader, "Linea")) Linea = Convert.ToString(Reader["Linea"]);
            if (ReadCol.Exist(Reader, "Familia")) Familia = Convert.ToString(Reader["Familia"]);
            if (ReadCol.Exist(Reader, "Grupo")) Grupo = Convert.ToString(Reader["Grupo"]);
            if (ReadCol.Exist(Reader, "Descripcion")) Descripcion = Convert.ToString(Reader["Descripcion"]);
            if (ReadCol.Exist(Reader, "Marca")) Marca = Convert.ToString(Reader["Marca"]);
            if (ReadCol.Exist(Reader, "Unidad")) Unidad = Convert.ToString(Reader["Unidad"]);
            if (ReadCol.Exist(Reader, "Lote")) Lote = Convert.ToString(Reader["Lote"]);
            if (ReadCol.Exist(Reader, "PrecioUnitario")) PrecioUnitario = Convert.ToDecimal(Reader["PrecioUnitario"]);
            if (ReadCol.Exist(Reader, "StockActual")) StockActual = Convert.ToInt32(Reader["StockActual"]);
            if (ReadCol.Exist(Reader, "Tipo")) Tipo = Convert.ToString(Reader["Tipo"]);
            if (ReadCol.Exist(Reader, "CantidadMax")) CantidadMax = Convert.ToInt32(Reader["CantidadMax"]);
        }

        public Articulo() { }
    }
}
