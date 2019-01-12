using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Ibis.Options;

namespace Rhino.Ibis.Test.Relations.CurveToCurveRelation.ReviewMethods
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
            var opts = new CurveToCurveOptions()
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
            var opts = new CurveToCurveOptions()
            {
                DoIfIntersectionExists = true
            };

            rel.Review(opts, out var resA, out var resB);

            resB.IntersectionExists.Should().BeTrue("because the curves do intersect");
        }
    }
}
