using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Rhino.Ibis.Relations
{
    public class CurvesRelation
    {
        public List<Curve> GeometryA { get; set; }

        public CurvesRelation(List<Curve> testCurves)
        {
            GeometryA = testCurves;
        }
    }
}
