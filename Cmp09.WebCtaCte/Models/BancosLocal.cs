using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cmp09.WebCtaCte.Models
{
    [DelimitedRecord("\t")]
    //[FixedLengthRecord(FixedMode.AllowLessChars)]
    public class BancosLocal
    {
        //[FieldFixedLength(10)]
        public string Colegiatura;
        //[FieldFixedLength(200)]
        public string Nombre_Colegiado ;
        //[FieldFixedLength(20)]
        public string Dni ;
        //[FieldConverter(ConverterKind.Decimal, ".")]
        public string Monto ;
        //[FieldFixedLength(10)]
        //[FieldConverter(ConverterKind.DateMultiFormat, "dd/MM/yyyy", "dd/MM/yyyy")]
        public string Fecha_Pago;
    }
}