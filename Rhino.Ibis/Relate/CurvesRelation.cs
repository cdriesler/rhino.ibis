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
        private CurvesRelationProperties PropertyMethods { get; set; }

        public CurvesRelation(List<Curve> testCurves)
        {
            PropertyMethods = new CurvesRelationProperties(this);
        }

        public CurvesRelationProperties Review()
        {
            return PropertyMethods;
        }

        private CurvesRelation DoSomething()
        {
            return this;
        }

        public class CurvesRelationProperties
        {
            private CurvesRelation Source { get; set; }

            public CurvesRelationProperties(CurvesRelation parent)
            {
                Source = parent;
            }

            public CurvesRelationProperties DoSomething()
            {
                return this;
            }

            public CurvesRelationProperties DoSomethingElse()
            {
                return this;
            }

            public CurvesRelation Results()
            {
                return Source;
            }
        }
    }
}
