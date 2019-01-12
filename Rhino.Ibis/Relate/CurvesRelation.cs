using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Rhino.Ibis.Relate
{
    public class CurvesRelation
    {
        public List<Curve> TestCurves { get; set; }

        public CurvesRelation(List<Curve> testCurves)
        {
            TestCurves = testCurves;
        }
    }
}
