using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Cmp01.Utilities.Web
{
    public class EmptyStringDataAnnotations : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> vAttr, Type vType, Func<object> vModel, Type vTModel, string vProp)
        {
            var vFulldata = base.CreateMetadata(vAttr, vType, vModel, vTModel, vProp);
            if (vTModel == typeof(string)) vFulldata.ConvertEmptyStringToNull = false;
            return vFulldata;
        }
    }
}
