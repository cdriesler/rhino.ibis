using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Geometry;
using FluentAssertions;
using Rhino.Ibis.Reviews;

namespace Rhino.Ibis.Test.Relations.CurveToCurveRelation
{
    [TestFixture]
    public class CurveToCurveRelationSpecs
    {
        [Test]
        public void Should_be_instantiated_when_curve_is_related_to_curve()
        {
            var rel = Relate.This(new LineCurve()).To(new LineCurve());

            rel.Should().BeOfType<Ibis.Relations.CurveToCurveRelation>("because it is relating a curve to a curve");
        }

        [Test]
        public void Should_throw_exception_when_unresolved_property_is_read()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();

            Action act = () => { var x = rel.ResultsA.IntersectionExists; };

            act.Should().Throw<TestNotRunException>("because the property was read before it was actually resolved");
        }
    }
}
