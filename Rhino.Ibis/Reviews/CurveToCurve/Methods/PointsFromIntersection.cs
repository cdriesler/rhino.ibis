using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Ibis.Relations;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;

namespace Rhino.Ibis.Reviews.CurveToCurve
{
    public static partial class CurveToCurveReviewMethods
    {
        public static void PointsFromIntersection(CurveToCurveRelation source)
        {
            var pts = Intersection.CurveCurve(source.GeometryA, source.GeometryB, 0.1, 0.1)
                .Where(x => x.IsPoint)
                .Select(x => x.PointA)
                .ToList();

            source.PropertiesA.AllPointsFromIntersection = pts;
            source.PropertiesB.AllPointsFromIntersection = pts;

            var uniquePts = Point3d.CullDuplicates(pts, 0.1).ToList();

            source.PropertiesA.UniquePointsFromIntersection = uniquePts;
            source.PropertiesB.UniquePointsFromIntersection = uniquePts;
        }
    }
}
