using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Geometry;

namespace Rhino.Ibis.Test.Reviews.Curves
{
    [TestFixture]
    public class GroupsByColinearity
    {
        [Test]
        public void Given_ParallelOffsetCurves_should_return_two_groups()
        {
            TestEnvironments.ParallelOffsetCurves()
                .Resolve()
                .GroupsByColinearity()
                .Results(out var res);

            var val = res.GroupsByColinearity.Count;

            val.Should().Be(2, "because there are two independent curves");
        }

        [Test]
        public void Given_HorizontalDashedLine_should_return_one_group()
        {
            TestEnvironments.HorizontalDashedLine()
                .Resolve()
                .GroupsByColinearity()
                .Results(out var res);

            var val = res.GroupsByColinearity.Count;

            val.Should().Be(1, "because all dashes are colinear");
        }

        [Test]
        public void Given_ParallelOffsetCurvesOneDashed_returns_two_groups()
        {
            TestEnvironments.ParallelOffsetCurvesOneDashed()
                .Resolve()
                .GroupsByColinearity()
                .Results(out var res);

            var val = res.GroupsByColinearity.Count;

            val.Should().Be(2, "because there are two colinear groups of curves");
        }

        [Test]
        public void Given_ParallelOffsetCurvesOneDashed_returns_accurate_groups()
        {
            TestEnvironments.ParallelOffsetCurvesOneDashed()
                .Resolve()
                .GroupsByColinearity()
                .Results(out var res);

            var val = res.GroupsByColinearityIndexMap[0] == res.GroupsByColinearityIndexMap[1];

            val.Should().BeTrue("because the first two segments are colinear");
        }

        [Test]
        public void Given_ShuffledPinwheel_should_return_four_groups()
        {
            TestEnvironments.ShuffledPinwheel()
                .Resolve()
                .GroupsByColinearity()
                .Results(out var res);

            var val = res.GroupsByColinearity.Count;

            val.Should().Be(4, "because the pinwheel has eight spokes");
        }
    }
}
