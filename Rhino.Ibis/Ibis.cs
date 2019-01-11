using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Relate;

namespace Rhino.Ibis
{
    public static class Ibis
    {
        public static CurveRelation Relate(Curve curve)
        {
            return new CurveRelation(curve);
        }

        public static CurvesRelation Relate(List<Curve> curves)
        {
            return new CurvesRelation(curves);
        }

        public static PointRelation Relate(Point3d point)
        {
            return new PointRelation();
        }
    }
}
