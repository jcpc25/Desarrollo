using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WSIC2010.Util
{
    public static class Utils
    {
        public static bool IsNumeric(this DataColumn col)
        {
            if (col == null)
                return false;
            // Make this const
            var numericTypes = new[] { typeof(Byte), typeof(Decimal), typeof(Double),
        typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte),
        typeof(Single), typeof(UInt16), typeof(UInt32), typeof(UInt64)};
            return numericTypes.Contains(col.DataType);
        }
    }
}