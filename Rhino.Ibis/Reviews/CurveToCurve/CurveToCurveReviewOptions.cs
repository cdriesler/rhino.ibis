using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Reviews.CurveToCurve
{
    public class CurveToCurveReviewOptions
    {
        public bool DoIfIntersectionExists { get; set; }
        public bool DoPointsFromIntersection { get; set; }

        public CurveToCurveReviewOptions()
        {

        }
    }
}
