using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Ibis.Relations;
using Methods = Rhino.Ibis.Reviews.Curve.CurveReviewMethods;

namespace Rhino.Ibis.Reviews.Curve
{
    public class CurveReview
    {
        public CurveRelation Source { get; set; }

        public CurveReview(CurveRelation source)
        {
            Source = source;
        }

        public CurveRelation Results()
        {
            return Source;
        }

        public void Results(out CurveRelationProperties res)
        {
            res = Source.Properties;
        }

        #region handshake methods

        public CurveReview BoundingBoxProperties()
        {
            Methods.BoundingBoxProperties(Source);
            return this;
        }

        public CurveReview BoundingSquare()
        {
            Methods.BoundingSquare(Source);
            return this;
        }

        #endregion
    }
}
