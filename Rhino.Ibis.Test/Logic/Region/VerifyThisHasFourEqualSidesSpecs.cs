using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Geometry;
using Rhino.Ibis;

namespace Rhino.Ibis.Test.Logic.Region
{
    [TestFixture]
    public class VerifyThisHasFourEqualSidesSpecs
    {
        [Test]
        public void Given_a_square_should_return_true()
        {
            Given.This(new Rhino.Geometry.Region(new Rectangle3d(Plane.WorldXY, 1, 1).ToNurbsCurve()))
                .VerifyThisHasFourEqualSides(out var res);

            res.Should().BeTrue("because a square has four equal sides");
        }
    }
}