using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Reviews.Curve
{
    public static partial class CurveReviewMethods
    {
        public static void BoundingSquare(CurveRelation source)
        {
            var box = source.Geometry.GetBoundingBox(Plane.WorldXY);

            var rect = new Rectangle3d(Plane.WorldXY, box.Min, new Point3d(box.Max.X, box.Min.Y, 0));

            source.Properties.BoundingSquare = rect.ToNurbsCurve();
        }
    }
}
