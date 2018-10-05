/*----------------------------------------------------------------------------------------
ARCHIVO CLASE   : Base.cs
Objetivo        : Clase base donde se extenderá las clases de acceso a datos
Autor           : Omar Rodriguez Muñoz (FRR)
Fecha Creación  : 17/02/2017
----------------------------------------------------------------------------------------*/
#region Espacios de Nombres
using Utildatatool;
#endregion


namespace Cmp03.DataAccess
{
    public class Base
    {
        public SQLAdo AdoNet = new SQLAdo(Cmp01.Utilities.Variables.CnnString);

        public SQLAdo AdoGP = new SQLAdo(Cmp01.Utilities.Variables.CnnGP);
    }
}
