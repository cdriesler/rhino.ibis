using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Test.Syntax
{
    [TestFixture]
    public class CurveTo
    {
        [Test]
        public void Given_curve_collection_should_return_CurvesRelation()
        {
            var rel = Given.These(new List<Curve>());

            var res = rel.GetType().FullName;

            res.Should().Be(typeof(CurvesRelation).FullName, "because we are relating a collection of curves");
        }
    }
}
