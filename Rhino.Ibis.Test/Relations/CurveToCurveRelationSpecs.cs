using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Geometry;
using FluentAssertions;
using Rhino.Ibis.Reviews;

namespace Rhino.Ibis.Test.Relations
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

        #region unresolved property tests

        [Test]
        public void AllPointsFromIntersection_should_throw_exception_when_read_if_unresolved()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();

            Action act = () => { var x = rel.PropertiesA.AllPointsFromIntersection; };
            act.Should().Throw<UnresolvedPropertyException>("because the property was read before it was actually resolved");
        }

        [Test]
        public void IntersectionExists_should_throw_exception_when_read_if_unresolved()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();

            Action act = () => { var x = rel.PropertiesA.IntersectionExists; };
            act.Should().Throw<UnresolvedPropertyException>("because the property was read before it was actually resolved");
        }

        [Test]
        public void UniquePointsFromIntersection_should_throw_exception_when_read_if_unresolved()
        {
            var rel = TestEnvironments.CenteredVertical_CenteredHorizontal();

            Action act = () => { var x = rel.PropertiesA.UniquePointsFromIntersection; };
            act.Should().Throw<UnresolvedPropertyException>("because the property was read before it was actually resolved");
        }

        #endregion
    }
}
