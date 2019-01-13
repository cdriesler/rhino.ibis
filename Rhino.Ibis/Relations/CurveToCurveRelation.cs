using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;
using Rhino.Ibis.Reviews;
using Rhino.Ibis.Reviews.CurveToCurve;

namespace Rhino.Ibis.Relations
{
    public class CurveToCurveRelation
    {
        //Related geometry
        public Curve GeometryA { get; set; }
        public Curve GeometryB { get; set; }

        //Relation properties
        public CurveToCurveReviewResults ResultsA { get; set; }
        public CurveToCurveReviewResults ResultsB { get; set; }

        //Review methods class
        private CurveToCurveReview _reviewMethods;
        public CurveToCurveReview ReviewMethods
        {
            get
            {
                return _reviewMethods;
            }
            set
            {
                _reviewMethods = value;
            }
        }

        public CurveToCurveRelation(Curve testCurve, Curve targetCurve)
        {
            ReviewMethods = new CurveToCurveReview(this);

            GeometryA = testCurve;
            GeometryB = targetCurve;

            ResultsA = new CurveToCurveReviewResults();
            ResultsB = new CurveToCurveReviewResults();
        }

        public CurveToCurveReview Resolve()
        {
            return ReviewMethods;
        }

        public CurveToCurveRelation Review()
        {
            //Review with all methods.

            return this;
        }

        public void Review(out CurveToCurveRelation results)
        {
            //Review with all methods.

            results = this;
        }

        public void Review(out CurveToCurveReviewResults resultsA, out CurveToCurveReviewResults resultsB)
        {
            //Review with all methods.

            resultsA = ResultsA;
            resultsB = ResultsB;
        }

        public CurveToCurveRelation Review(CurveToCurveReviewOptions options)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            return this;
        }

        public void Review(CurveToCurveReviewOptions options, out CurveToCurveReviewResults resultsA, out CurveToCurveReviewResults resultsB)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            resultsA = ResultsA;
            resultsB = ResultsB;
        }
    }

    public class CurveToCurveReviewResults
    {
        private bool _intersectionExistsRun;
        private bool _intersectionExists;
        public bool IntersectionExists
        {
            get
            {
                if (!_intersectionExistsRun)
                {
                    throw new TestNotRunException();
                }

                return _intersectionExists;
            }
            set
            {
                _intersectionExistsRun = true;
                _intersectionExists = value;
            }
        }

        public CurveToCurveReviewResults()
        {

        }
    }
}
