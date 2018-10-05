using System.Runtime.Serialization;

namespace Cmp01.Utilities
{
    class Enumerados
    {
    }

    [DataContract]
    public enum EnumMaestras
    {
        TIPO_DOCUMENTO = 1,
        TIPOS_VIA = 2,
        TIPOS_ZONA = 3,
        ESTADO_CIVIL = 4,
        MEDIO_CONTACTO = 5,
        GENERO = 6,
        GRUPO_SANGUINEO = 7,
        ORIGEN = 8,
        UNIVERSIDAD = 9,
        CONSEJO_REGIONAL = 10,
        TIPO_ESPECIALIDAD = 11,
        GRUPO_OCUPACIONAL = 12,
        SECTOR = 13,
        ESTADO_MATRICULA = 14,
        SITUACION_ESTUDIO = 15,
        ESPECIALIDAD = 16,
        TIPO_DOCUMENTOSUNAT = 17,
        TIPO_MONEDA = 18,
        TIPO_PAGO = 19,
        GRUPO_OCUPACIONALPUBLICO = 20,
        HABILIDAD = 21,
        ESTADO_COMPROBANTE = 22,
        TIPO_CARNET = 23,
        CARGOS_DIRECTIVOS_CMP = 24
    }

    public enum EnumOrigen
    {
        NACIONAL = 54,
        EXTRANJERO = 55
    }

    public enum EnumGenero
    {
        MASCULINO = 42,
        FEMENINO = 43
    }

    public enum EnumSector
    {
        PUBLICO = 604,
        PRIVADO = 605
    }

    public enum EnumEstado
    {
        ACTIVO = 607,
        CANCELADO = 608,
        PRE_EVALUACION = 609,
        EXONERADO_ADMINISTRATIVO = 610,
        EXONERADO_VIAJE = 611,
        EXONERADO_TOTAL = 612,
        EXPULSADO = 613,
        FALLECIDO = 614,
        INACTIVO = 615,
        INHABILITADO_TEMPORAL = 616,
        NO_ACTIVO = 617,
        SUSPENDIDO = 618
    }

    public enum EnumTipoDocSunat
    {
        BOLETA = 912,
        FACTURA = 913,
        RECIBO = 951,
        NOTACREDITO = 984,
        NOTADEBITO = 985
    }

    public enum EnumTipoMoneda
    {
        SOLES = 915,
        DOLARES = 916,
        EUROS = 917
    }

    public enum EnumTipoPago
    {
        EFECTIVO = 919,
        VISA = 920,
        MASTERCARD = 921,
        CHEQUE = 922,
        OTROS = 923
    }

    public enum EnumTipoEspecialidad
    {
        DIPLOMATURA = 590,
        DOCTORADO = 591,
        ESPECIALIDAD = 592,
        MAESTRIA = 593,
        OTRAS_MAESTRÍAS = 594,
    }

    public enum EnumHabilidad
    {
        HABIL = 939,
        INHABIL = 940
    }

    public enum EnumEstadoComprobante
    {
        AUTOMATICO = 942,
        EMITIDO = 943,
        ANULADO = 944,
        GUARDADO = 950,
        BORRADOR = 986
    }

    public enum EnumTipoCarnet
    {
        CARNETIZACION = 947,
        DUPLICADO = 948,
        RECARNETIZACIÓN = 949
    }

    public enum EnumTipoArticuloCuota
    {
        CUOTA_SEMEFA = 206,
        CUOTA_PENSION = 192
    }

    public enum EnumSituacionEstudio
    {
        EXPEDIDO = 620,
        INSCRITO = 621,
        RECONOCIDO = 622,
        REVALIDADO = 623
    }

    public enum EnumEstadoMatricula
    {
        ACTIVO = 607,
        CANCELADO = 608,
        PRE_EVALUACION = 609,
        EXONERADO_ADMINISTRATIVO = 610,
        EXONERADO_VIAJE = 611,
        EXONERADO_TOTAL = 612,
        EXPULSADO = 613,
        FALLECIDO = 614,
        INACTIVO = 615,
        INHABILITADO_TEMPORAL = 616,
        NO_ACTIVO = 617,
        SUSPENDIDO = 618
    }

    public enum EnumTipoPersonaGP
    {
        NATURAL = 1,
        JURIDICA = 2
    }


    public enum EnumTipoDocumento
    {
        DNI = 2,
        RUC = 5
    }

    public enum EnumTipoDocumentoGP
    {
        OTROS = 1,
        DNI = 2,
        EXTRANJERIA = 3,
        RUC = 4,
        PASAPORTE = 5
    }

    public enum EnumMedioContacto
    {
        CORREO = 36,
        CELULAR = 38
    }
}
