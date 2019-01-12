using System;
using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Ibis;
using Rhino.Geometry;

namespace Rhino.Ibis.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var val = Ibis.Relate(new LineCurve()).To(new LineCurve()).Review(
                new Rhino.Ibis.Relate.CurveToCurveRelationReviewOptions()
                {
                    DoFindSomething = true
                }
                )
                .FindSomethingValue;

            val.Should().BeTrue();
        }
    }
}
