using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Logic.Curves
{
    public static partial class CurvesLogic
    {
        public static Curve LocateLongestCurve(List<Curve> crvs)
        {
            return crvs
                .OrderBy(x => x.GetLength())
                .Reverse()
                .FirstOrDefault();
        }
    }
}
