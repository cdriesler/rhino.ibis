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
    public class PointsFromIntersectionSpecs
    {
        [Test]
        public void Given_CenteredVertical_to_CenteredHorizontal_when_reviewing_GeometryA_should_find_one_unique_point()
        {
            TestEnvironments.CenteredVertical_CenteredHorizontal()
                .Resolve()
                .PointsFromIntersection()
                .Results(out var resA, out var resB);

            var val = resA.UniquePointsFromIntersection.Count;

            val.Should().Be(1, "because the curves only intersect once");
        }

        [Test]
        public void Given_CenteredVertical_to_CenteredHorizontal_when_reviewing_GeometryB_should_find_one_unique_point()
        {
            TestEnvironments.CenteredVertical_CenteredHorizontal()
                .Resolve()
                .PointsFromIntersection()
                .Results(out var resA, out var resB);

            var val = resB.UniquePointsFromIntersection.Count;

            val.Should().Be(1, "because the curves only intersect once");
        }
    }
}
