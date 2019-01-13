using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Reviews;
using Rhino.Ibis.Reviews.Curves;

namespace Rhino.Ibis.Relations
{
    public class CurvesRelation
    {
        //Related geometry
        public List<Curve> Geometry { get; set; }

        //Relation properties
        public CurvesRelationProperties Properties { get; set; }

        //Review methods
        private CurvesReview _reviewMethods;
        public CurvesReview ReviewMethods
        {
            get => _reviewMethods;
            set => _reviewMethods = value;
        }

        public CurvesRelation(List<Curve> curves)
        {
            Geometry = curves;

            Properties = new CurvesRelationProperties();

            ReviewMethods = new CurvesReview(this);
        }

        public CurvesReview Resolve()
        {
            return ReviewMethods;
        }

        public CurvesRelation Review()
        {
            return this;
        }

        public void Review(out CurvesRelationProperties results)
        {
            results = this.Properties;
        }

        public CurvesRelation Review(CurvesReviewOptions options)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            return this;
        }

        public void Review(CurvesReviewOptions options, out CurvesRelationProperties results)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            results = this.Properties;
        }
    }

    public class CurvesRelationProperties
    {
        private bool _groupsByColinearityResolved;
        private List<List<Curve>> _groupsByColinearity;
        public List<List<Curve>> GroupsByColinearity
        {
            get
            {
                if (!_groupsByColinearityResolved) throw new UnresolvedPropertyException();
                return _groupsByColinearity;
            }
            set
            {
                _groupsByColinearityResolved = true;
                _groupsByColinearity = value;
            }
        }

        private bool _groupsByColinearityIndexMapResolved;
        private List<int> _groupsByColinearityIndexMap;
        public List<int> GroupsByColinearityIndexMap
        {
            get
            {
                if (!_groupsByColinearityIndexMapResolved) throw new UnresolvedPropertyException();
                return _groupsByColinearityIndexMap;
            }
            set
            {
                _groupsByColinearityIndexMapResolved = true;
                _groupsByColinearityIndexMap = value;
            }
        }

        public CurvesRelationProperties()
        {

        }
    }
}
