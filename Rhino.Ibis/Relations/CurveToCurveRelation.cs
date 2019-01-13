﻿using System;
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
        public CurveToCurveRelationProperties ResultsA { get; set; }
        public CurveToCurveRelationProperties ResultsB { get; set; }

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

            ResultsA = new CurveToCurveRelationProperties();
            ResultsB = new CurveToCurveRelationProperties();
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

        public void Review(out CurveToCurveRelationProperties resultsA, out CurveToCurveRelationProperties resultsB)
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

        public void Review(CurveToCurveReviewOptions options, out CurveToCurveRelationProperties resultsA, out CurveToCurveRelationProperties resultsB)
        {
            ReviewUtils.ReviewWithOptions(ref _reviewMethods, ref options);

            resultsA = ResultsA;
            resultsB = ResultsB;
        }
    }

    public class CurveToCurveRelationProperties
    {
        /* IfIntersectionExists() */
        private bool _intersectionExistsResolved;
        private bool _intersectionExists;
        public bool IntersectionExists
        {
            get
            {
                if (!_intersectionExistsResolved) throw new UnresolvedPropertyException();
                return _intersectionExists;
            }
            set
            {
                _intersectionExistsResolved = true;
                _intersectionExists = value;
            }
        }

        /* PointsFromIntersection() */
        private bool _uniquePointsFromIntersectionResolved;
        private List<Point3d> _uniquePointsFromIntersection;
        public List<Point3d> UniquePointsFromIntersection
        {
            get
            {
                if (!_uniquePointsFromIntersectionResolved) throw new UnresolvedPropertyException();
                return _uniquePointsFromIntersection;
            }
            set
            {
                _uniquePointsFromIntersectionResolved = true;
                _uniquePointsFromIntersection = value;
            }
        }

        private bool _allPointsFromIntersectionResolved;
        private List<Point3d> _allPointsFromIntersection;
        public List<Point3d> AllPointsFromIntersection
        {
            get
            {
                if (!_allPointsFromIntersectionResolved) throw new UnresolvedPropertyException();
                return _allPointsFromIntersection;
            }
            set
            {
                _allPointsFromIntersectionResolved = true;
                _allPointsFromIntersection = value;
            }
        }

        public CurveToCurveRelationProperties()
        {

        }
    }
}
