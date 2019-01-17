using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Ibis.Logic.Curves;
using Rhino.Ibis.Logic.Region;

namespace Rhino.Ibis.Logic
{
    public static class Library
    {
        public static List<Type> GetAvailableRelations()
        {
            var x = "String";

            x.Split(new[] {"tr"}, StringSplitOptions.None);

            var dat = typeof(CurvesLogic).GetMethods()[0].ReturnType.Name;
            
            return new List<Type>
            {
                typeof(CurvesLogic),
                typeof(RegionLogic)
            };
        }
    }
}
