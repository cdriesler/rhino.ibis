using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Ibis.Relations;
using Methods = Rhino.Ibis.Reviews.Curves.CurvesReviewMethods;

namespace Rhino.Ibis.Reviews.Curves
{
    public class CurvesReview
    {
        public CurvesRelation Source { get; set; }

        public CurvesReview(CurvesRelation source)
        {
            Source = source;
        }

        public CurvesRelation Results()
        {
            return Source;
        }

        public void Results(out CurvesRelationProperties res)
        {
            res = Source.Properties;
        }

        #region handshake methods

        public CurvesReview GroupsByColinearity()
        {
            Methods.GroupsByColinearity(Source);
            return this;
        }

        #endregion
    }
}
