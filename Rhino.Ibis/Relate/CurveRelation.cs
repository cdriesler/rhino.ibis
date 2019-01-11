using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Rhino.Ibis.Relate
{
    public class CurveRelation
    {
        public Curve TestCurve { get; set; }

        public CurveRelation(Curve testCurve)
        {
            TestCurve = testCurve;
        }

        public CurveToCurveRelation To(Curve curve)
        {
            return new CurveToCurveRelation(TestCurve, curve);
        }
    }
}
