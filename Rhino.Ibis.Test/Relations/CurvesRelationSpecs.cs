using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Geometry;

namespace Rhino.Ibis.Test.Relations
{
    [TestFixture]
    public class CurvesRelationSpecs
    {
        [Test]
        public void Should_be_instantiated_when_curve_collection_is_related()
        {
            var rel = Relate.This(new List<Curve>());

            rel.Should().BeOfType<Ibis.Relations.CurvesRelation>("because it is relating a collection of curves");
        }

    }
}
