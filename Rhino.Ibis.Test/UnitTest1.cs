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
            Relate.This(new LineCurve()).To(new LineCurve())
                .Resolve()
                .IfIntersectionExists()
                .Results(out var resA, out var resB);

            resA.IntersectionExists.Should().BeTrue();

            
        }
    }
}
