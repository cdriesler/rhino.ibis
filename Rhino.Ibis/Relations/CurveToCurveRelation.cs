using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;
using Rhino.Ibis.Reviews;

namespace Rhino.Ibis.Relations
{
    public class CurveToCurveRelation : RelationBase
    {
        //Test and target geometry.
        public Curve GeometryA { get; set; }
        public Curve GeometryB { get; set; }

        //Result properties (get; private set;)
        public CurveToCurveRelationResults ResultsA { get; set; }
        public CurveToCurveRelationResults ResultsB { get; set; }

        //Review methods.
        private CurveToCurveRelationReview _reviewMethods;
        public override ReviewBase ReviewMethods
        {
            get
            {
                return null;
            }
            set
            {
                var review = value as CurveToCurveRelationReview;

                if (review != null) _reviewMethods = review;
            }
        }

        //Review options.
        private CurveToCurveRelationReviewOptions _reviewOptions;
        public override ReviewOptions ReviewOptions
        {
            get
            {
                return null;
            }
            set
            {
                var opts = value as CurveToCurveRelationReviewOptions;

                if (opts != null) _reviewOptions = opts;
            }
        }

        public CurveToCurveRelation(Curve testCurve, Curve targetCurve)
        {
            ReviewMethods = new CurveToCurveRelationReview(this);
            ResultsA = new CurveToCurveRelationResults();
            ResultsB = new CurveToCurveRelationResults();
        }

        public CurveToCurveRelationReview Resolve()
        {
            return _reviewMethods;
        }

        public CurveToCurveRelation Review()
        {
            //Review with all methods.

            return this;
        }

        public void Review(out CurveToCurveRelationResults resultsA, out CurveToCurveRelationResults resultsB)
        {
            //Review with all methods.

            resultsA = ResultsA;
            resultsB = ResultsB;
        }

        public CurveToCurveRelation Review(CurveToCurveRelationReviewOptions options)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            return this;
        }

        public void Review(CurveToCurveRelationReviewOptions options, out CurveToCurveRelationResults resultsA, out CurveToCurveRelationResults resultsB)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            resultsA = ResultsA;
            resultsB = ResultsB;
        }
    }

    public class CurveToCurveRelationResults
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

        public CurveToCurveRelationResults()
        {

        }
    }

    public class CurveToCurveRelationReview : ReviewBase
    {
        private CurveToCurveRelation _source;
        public override RelationBase Source
        {
            get
            {
                return null;
            }
            set
            {
                var src = value as CurveToCurveRelation;

                if (src != null) _source = src;
            }
        }

        public CurveToCurveRelationReview(CurveToCurveRelation source)
        {
            Source = source;
        }

        public CurveToCurveRelation Results()
        {
            return _source;
        }

        public void Results(out CurveToCurveRelationResults resultsA, out CurveToCurveRelationResults resultsB)
        {
            resultsA = _source.ResultsA;
            resultsB = _source.ResultsB;
        }

        public CurveToCurveRelationReview IfIntersectionExists()
        {
            var ccx = Intersection.CurveCurve(_source.GeometryA, _source.GeometryB, 0.1, 0.1);
            var res = ccx.Any(x => x.IsPoint);

            _source.ResultsA.IntersectionExists = true;
            _source.ResultsB.IntersectionExists = true;

            return this;
        }
    }

    public class CurveToCurveRelationReviewOptions : ReviewOptions
    {
        public bool DoIfIntersectionExists { get; set; }

        public CurveToCurveRelationReviewOptions()
        {

        }
    }
}
