using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Ibis.Relations;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;
using Methods = Rhino.Ibis.Reviews.CurveToCurve.CurveToCurveReviewMethods;

namespace Rhino.Ibis.Reviews.CurveToCurve
{
    public partial class CurveToCurveReview
    {
        public CurveToCurveRelation Source { get; set; }

        public CurveToCurveReview(CurveToCurveRelation source)
        {
            Source = source;
        }

        public CurveToCurveRelation Results()
        {
            return Source;
        }

        public void Results(out CurveToCurveReviewResults resultsA, out CurveToCurveReviewResults resultsB)
        {
            resultsA = Source.ResultsA;
            resultsB = Source.ResultsB;
        }

        public CurveToCurveReview IfIntersectionExists()
        {
            Methods.IfIntersectionExists(Source);
            return this;
        }
    }
}
