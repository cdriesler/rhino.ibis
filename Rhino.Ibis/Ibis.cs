using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis
{
    //This
    public static partial class Given
    {
        public static RegionRelation This(Region region)
        {
            return new RegionRelation(region);
        }
    }

    //These
    public static partial class Given
    {
        public static CurvesRelation These(List<Curve> curves)
        {
            return new CurvesRelation(curves);
        }
    }
}
