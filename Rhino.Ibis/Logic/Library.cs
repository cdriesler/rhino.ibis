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
            return new List<Type>
            {
                typeof(CurvesLogic),
                typeof(RegionLogic)
            };
        }
    }
}
