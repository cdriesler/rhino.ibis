using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Relations;
using Rhino.Geometry.Intersect;

namespace Rhino.Ibis.Reviews.CurveToCurve
{
    public static partial class CurveToCurveReviewMethods
    {
        public static void IfIntersectionExists(CurveToCurveRelation source)
        {
            var ccx = Intersection.CurveCurve(source.GeometryA, source.GeometryB, 0.1, 0.1);
            var res = ccx.Any(x => x.IsPoint);

            source.PropertiesA.IntersectionExists = res;
            source.PropertiesB.IntersectionExists = res;
        }
    }
}
