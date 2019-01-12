using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Rhino.Ibis.Relate
{
    public class CurvesRelation : RelationBase
    {
        //Logic containing class
        private CurvesRelationReview ReviewMethods { get; set; }

        public override ReviewBase Review { get; set; }

        //Related geometry
        public List<Curve> TestCurves { get; private set; }

        //Results
        public bool TestResult { get; private set; }

        public CurvesRelation(List<Curve> testCurves)
        {
            TestCurves = testCurves;

            ReviewMethods = new CurvesRelationReview(this);
        }

        public CurvesRelationReview Review()
        {
            return ReviewMethods;
        }

        public CurvesRelationReview Review(CurvesRelationReviewOptions opts)
        {
            ReviewMethods.Options = opts;

            return ReviewMethods;
        }

        public class CurvesRelationReview : ReviewBase
        {
            private CurvesRelation _source;
            public override RelationBase Source
            {
                set
                {
                    _source = value as CurvesRelation;
                }
            }

            private CurvesRelationReviewOptions _options;
            public CurvesRelationReviewOptions Options
            {
                get
                {
                    return _options;
                }
                set
                {
                    _options = value;

                    PropertyInfo[] properties = value.GetType().GetProperties();

                    foreach (var property in properties)
                    {
                        if ((bool)property.GetConstantValue())
                        {
                            var res = ReviewMethods[property.Name];
                        }
                    }
                }
            }

            public override Dictionary<string,Action> ReviewMethods
            {
                get
                {
                    return new Dictionary<string, Action>()
                    {

                    };
                }
                set
                {

                }
            }

            private Dictionary<string, Action> CurvesRelationReviewMethods { get; } =
                new Dictionary<string, Action>()
                {
                        { "DoGroupBySlope", new Action(() => GroupBySlope(_source)) },
                        { "DoGroupByColinearity", new Action(() => GroupByColinearity()) }
                };

            //public override Dictionary<string, Action> ReviewMethods { get; private set; }

            public CurvesRelationReview(CurvesRelation parent)
            {
                Source = parent;

            }

            public CurvesRelation Results()
            {
                return Source;
            }

            public static CurvesRelationReview GroupBySlope(CurvesRelation source)
            {
                
                return source;
            }

            public static CurvesRelationReview GroupByColinearity()
            {
                return this;
            }
        }
    }

    public class CurvesRelationReviewOptions
    {
        public bool DoGroupBySlope { get; set; }
        public bool DoGroupByColinearity { get; set; }

        public CurvesRelationReviewOptions()
        {

        }
    }
}
