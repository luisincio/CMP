using System;
using System.Configuration;

namespace Cmp01.Utilities
{
    public static class Variables
    {
        public const string MensajeObligatorio = "Dato obligatorio";
        public const string Colegiado = "0000000000";
        public const string Activo = "1";
        public const string NoActivo = "0";
        public const string Natural = "N";
        public const string Juridico = "J";
        public const string Pais = "PERÚ";
        public const string EntidadAcreditada = "SUNEDU";
        public const int Peru = 178;
        public const int TiempoAñosRecertificacion = 5;
        public const string Matricula = "VS CUOTA COLEG";
        public const string Contado = "CONTADO";
        public const string UnidadMedida = "UND";
        //public const int IdPension = 192;
        public const int EmpresaNoExiste = 83351;
        public const decimal Pension = 25.00m;
        public const decimal Igv = 0.18m;
        public const string ClienteComun = "NINGUNO";
        public const string ClienteDniComun = "00000000";
        public const int MaxUnidades = 99000;
        public const int DniLong = 8;
        public const int RucLong = 11;
        public const int IdClienteVarios = 83350;

        public static DateTime Hoy
        {
            get { return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")); }
        }
        public static string CnnString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["CnnSql"]].ConnectionString;

        public static string CnnGP = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["CnnGP"]].ConnectionString;

        public static int Paginacion = Convert.ToInt32(ConfigurationManager.AppSettings["Pagination"]);

        public static string Modulo = ConfigurationManager.AppSettings["App"];
    }
}
