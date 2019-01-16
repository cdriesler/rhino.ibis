using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Rhino.Ibis;
using NUnit.Framework;
using Rhino.Geometry;

namespace Rhino.Ibis.Test.Logic.Curves
{
    [TestFixture]
    public class LocateLongestCurveSpecs
    {
        [Test]
        public void Given_two_curves_should_return_one()
        {
            var curves = new List<Curve>()
            {
                new LineCurve(Point2d.Origin, new Point2d(1, 0)),
                new LineCurve(Point2d.Origin, new Point2d(3, 0))
            };

            Given.These(curves).LocateLongestCurve(out var crv);

            var res = crv;

            res.Should().NotBeNull("because we expect one curve to be returned");
        }

        [Test]
        public void Given_two_curves_should_return_one_using_generic_get_method()
        {
            var curves = new List<Curve>()
            {
                new LineCurve(Point2d.Origin, new Point2d(1, 0)),
                new LineCurve(Point2d.Origin, new Point2d(3, 0))
            };

            var res = Given.These(curves).Get().LongestCurve;

            res.Should().NotBeNull("because we expect one curve to be returned");
        }

        [Test]
        public void Given_two_curves_should_longer_one()
        {
            var curves = new List<Curve>()
            {
                new LineCurve(Point2d.Origin, new Point2d(1, 0)),
                new LineCurve(Point2d.Origin, new Point2d(3, 0))
            };

            Given.These(curves).LocateLongestCurve(out var crv);

            var res = crv.GetLength();

            res.Should().Be(3, "because the longer curve is 3 units long");
        }
    }
}
