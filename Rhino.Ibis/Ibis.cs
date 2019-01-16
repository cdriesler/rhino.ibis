using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis
{
    public static class Relate
    {
        public static CurveRelation This(Curve curve)
        {
            return new CurveRelation(curve);
        }

        public static CurvesRelation This(List<Curve> curves)
        {
            return new CurvesRelation(curves);
        }

        public static PointRelation This(Point3d point)
        {
            return new PointRelation();
        }
    }

    public static class Given
    {
        public static RegionRelation This(Region region)
        {
            return new RegionRelation(region);
        }
    }
}
