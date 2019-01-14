using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Ibis.Relations;
using Rhino.Ibis.Reviews.Curve;
using Rhino.Ibis.Reviews.Curves;
using Rhino.Ibis.Reviews.CurveToCurve;

namespace Rhino.Ibis.Test.Syntax
{
    public static class IbisClassDictionary
    {
        public static List<Type> AllReviews { get; set; } = new List<Type>()
        {
            typeof(CurveReview),
            typeof(CurvesReview),
            typeof(CurveToCurveReview)
        };

        public static List<Type> AllReviewOptions { get; set; } = new List<Type>()
        {
            typeof(CurveReviewOptions),
            typeof(CurvesReviewOptions),
            typeof(CurveToCurveReviewOptions)
        };
    }
}
