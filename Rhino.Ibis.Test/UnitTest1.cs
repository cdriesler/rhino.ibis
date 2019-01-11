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
            var env = "y";

            env.Should().Be("x", "because I just wrote it");

            Ibis.Relate(new List<Curve>())
                .Review()
                .DoSomething()
                .DoSomethingElse()
                .Results();
        }
    }
}
