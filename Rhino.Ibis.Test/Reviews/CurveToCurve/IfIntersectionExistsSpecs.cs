using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Ibis.Reviews.CurveToCurve;

namespace Rhino.Ibis.Test.Reviews.CurveToCurve
{
    [TestFixture]
    public class IfIntersectionExistsSpecs
    {
        [Test]
        public void When_relating_CenteredVertical_to_CenteredHorizontal_should_return_true_for_GeometryA()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();

            rel.Resolve().IfIntersectionExists().Results(out var resA, out var resB);

            resA.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }

        [Test]
        public void When_relating_CenteredVertical_to_CenteredHorizontal_should_return_true_for_GeometryB()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();

            rel.Resolve().IfIntersectionExists().Results(out var resA, out var resB);

            resB.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }

        [Test]
        public void When_relating_CenteredVertical_to_CenteredHorizontal_with_options_should_return_true_for_GeometryA()
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
        public void When_relating_CenteredVertical_to_CenteredHorizontal_with_options_should_return_true_for_GeometryB()
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
