using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Reviews.Curve
{
    public static partial class CurveReviewMethods
    {
        public static void BoundingBoxProperties(CurveRelation source)
        {
            var box = source.Geometry.GetBoundingBox(Plane.WorldXY);

            source.Properties.BoundingBox = box;
        }
    }
}
