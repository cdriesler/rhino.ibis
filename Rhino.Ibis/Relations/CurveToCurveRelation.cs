using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;
using Rhino.Ibis.Reviews;
using Rhino.Ibis.Options;

namespace Rhino.Ibis.Relations
{
    public class CurveToCurveRelation
    {
        //Test and target geometry.
        public Curve GeometryA { get; set; }
        public Curve GeometryB { get; set; }

        //Result properties (get; private set;)
        public CurveToCurveReviewResults ResultsA { get; set; }
        public CurveToCurveReviewResults ResultsB { get; set; }

        //Review methods.
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

        //Review options.
        public CurveToCurveOptions ReviewOptions { get; set; }

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

        public CurveToCurveRelation Review(CurveToCurveOptions options)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            return this;
        }

        public void Review(CurveToCurveOptions options, out CurveToCurveReviewResults resultsA, out CurveToCurveReviewResults resultsB)
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

    public class CurveToCurveReview
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
            var ccx = Intersection.CurveCurve(Source.GeometryA, Source.GeometryB, 0.1, 0.1);
            var res = ccx.Any(x => x.IsPoint);

            Source.ResultsA.IntersectionExists = true;
            Source.ResultsB.IntersectionExists = true;

            return this;
        }
    }
}
