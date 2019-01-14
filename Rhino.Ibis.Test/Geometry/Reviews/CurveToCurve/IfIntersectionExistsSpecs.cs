using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Ibis.Reviews.CurveToCurve;
using Rhino.Geometry;

namespace Rhino.Ibis.Test.Reviews.CurveToCurve
{
    [TestFixture]
    public class IfIntersectionExistsSpecs
    {
        [Test]
        public void Given_CenteredVertical_to_CenteredHorizontal_should_return_true_for_GeometryA()
        {
            TestEnvironments.CenteredVertical_CenteredHorizontal()
                .Resolve()
                .IfIntersectionExists()
                .Results(out var resA, out var resB);

            resA.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }

        [Test]
        public void Given_CenteredVertical_to_CenteredHorizontal_should_return_true_for_GeometryB()
        {
            TestEnvironments.CenteredVertical_CenteredHorizontal()
                .Resolve()
                .IfIntersectionExists()
                .Results(out var resA, out var resB);

            resB.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }

        [Test]
        public void Given_disjoint_curves_should_return_false()
        {
            Relate.This(new LineCurve(new Point3d(1, 0, 0), new Point3d(1, 1, 0))).To(new LineCurve(new Point3d(0, 0, 0), new Point3d(0, 1, 0)))
                .Resolve()
                .IfIntersectionExists()
                .Results(out var resA, out var resB);

            resA.IntersectionExists.Should().BeFalse("because the curves do not intersect");
        }

        [Test]
        public void Given_CenteredVertical_to_CenteredHorizontal_with_options_should_return_true_for_GeometryA()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();
            var opts = new CurveToCurveReviewOptions()
            {
                DoIfIntersectionExists = true
            };

            rel.Review(opts, out var resA, out var resB);

            resA.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }

        [Test]
        public void Given_CenteredVertical_to_CenteredHorizontal_with_options_should_return_true_for_GeometryB()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();
            var opts = new CurveToCurveReviewOptions()
            {
                DoIfIntersectionExists = true
            };

            rel.Review(opts, out var resA, out var resB);

            resB.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }
    }
}
