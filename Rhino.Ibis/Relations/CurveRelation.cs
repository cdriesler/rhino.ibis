using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Reviews;
using Rhino.Ibis.Reviews.Curve;
using Rhino.Ibis.Reviews.Curves;
using Rhino.Render;

namespace Rhino.Ibis.Relations
{
    public class CurveRelation
    {
        //Related geometry
        public Curve Geometry { get; set; }

        //Relation properties
        public CurveRelationProperties Properties { get; set; }

        //Review methods
        private CurveReview _reviewMethods;
        public CurveReview ReviewMethods
        {
            get => _reviewMethods;
            set => _reviewMethods = value;
        }

        public CurveRelation(Curve curve)
        {
            Geometry = curve;

            Properties = new CurveRelationProperties();

            ReviewMethods = new CurveReview(this);
        }

        public CurveToCurveRelation To(Curve curve)
        {
            return new CurveToCurveRelation(Geometry, curve);
        }

        public CurveReview Resolve()
        {
            return ReviewMethods;
        }

        public CurveRelation Review()
        {
            return this;
        }

        public void Review(out CurveRelationProperties results)
        {
            results = Properties;
        }

        public CurveRelation Review(CurveReviewOptions options)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            return this;
        }

        public void Review(CurveReviewOptions options, out CurveRelationProperties results)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            results = Properties;
        }
    }

    public class CurveRelationProperties
    {
        /* BoundingBoxProperties() */
        private bool _boundingBoxResolved;
        private BoundingBox _boundingBox;
        public BoundingBox BoundingBox
        {
            get
            {
                if (!_boundingBoxResolved) throw new UnresolvedPropertyException();
                return _boundingBox;
            }
            set
            {
                _boundingBoxResolved = true;
                _boundingBox = value;
            }
        }

        /* BoundingSquare() */
        private bool _boundingSquareResolved;
        private Curve _boundingSquare;
        public Curve BoundingSquare
        {
            get
            {
                if (!_boundingSquareResolved) throw new UnresolvedPropertyException();
                return _boundingSquare;
            }
            set
            {
                _boundingSquareResolved = true;
                _boundingSquare = value;
            }
        }
    }
}
