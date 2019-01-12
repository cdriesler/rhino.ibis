using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Reviews;

namespace Rhino.Ibis.Relations
{
    public class CurveToCurveRelation : RelationBase
    {
        //Test and target geometry.

        //Result properties (get; private set;)
        public bool FindSomethingValue { get; set; }

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
        }

        public CurveToCurveRelationReview Run()
        {
            return _reviewMethods;
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

        public CurveToCurveRelation Review(CurveToCurveRelationReviewOptions options)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            return this;
        }

        public void Review(CurveToCurveRelationReviewOptions options, out CurveToCurveRelation results)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            results = this;
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

        public void Results(out CurveToCurveRelation results)
        {
            results = _source;
        }

        public CurveToCurveRelationReview FindSomething()
        {
            _source.FindSomethingValue = true;

            return this;
        }
    }

    public class CurveToCurveRelationReviewOptions : ReviewOptions
    {
        public bool DoFindSomething { get; set; }

        public CurveToCurveRelationReviewOptions()
        {

        }
    }
}
