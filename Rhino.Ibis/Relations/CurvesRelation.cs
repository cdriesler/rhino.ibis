using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Logic.Curves;

namespace Rhino.Ibis.Relations
{
    public class CurvesRelation
    {
        //Related geometry
        private List<Curve> TheseGeometry { get; }

        //Constructor
        public CurvesRelation(List<Curve> theseCurves)
        {
            TheseGeometry = theseCurves;
        }

        //H(and)shake class and method
        public CurvesRelationHandshake And()
        {
            return new CurvesRelationHandshake(TheseGeometry);
        }

        public class CurvesRelationHandshake
        {
            private List<Curve> StagedCurves { get; }

            public CurvesRelationHandshake(List<Curve> staged)
            {
                StagedCurves = staged;
            }
        }

        //Generic get class and method
        public CurvesRelationProperties Get()
        {
            return new CurvesRelationProperties(TheseGeometry);
        }

        public class CurvesRelationProperties
        {
            //Geometry getters
            public List<Curve> TheseCurves { get; }

            //Single property getters
            public Curve LongestCurve => CurvesLogic.LocateLongestCurve(TheseCurves);

            //Constructor
            public CurvesRelationProperties(List<Curve> crvs)
            {
                TheseCurves = crvs;
            }
        }

        //Public methods
        public CurvesRelation LocateLongestCurve(out Curve longestCurve)
        {
            longestCurve = CurvesLogic.LocateLongestCurve(TheseGeometry);
            return this;
        }

    }
}
