using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Geometry;
using Rhino.Ibis.Reviews;

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

        #region unresolved property tests

        [Test]
        public void GroupsByColinearity_should_throw_exception_when_read_if_unresolved()
        {
            var rel = Relate.This(new List<Curve>());

            Action act = () => { var x = rel.Properties.GroupsByColinearity; };
            act.Should().Throw<UnresolvedPropertyException>("because the property was read before it was actually resolved");
        }

        [Test]
        public void GroupsByColinearityIndexMap_should_throw_exception_when_read_if_unresolved()
        {
            var rel = Relate.This(new List<Curve>());

            Action act = () => { var x = rel.Properties.GroupsByColinearityIndexMap; };
            act.Should().Throw<UnresolvedPropertyException>("because the property was read before it was actually resolved");
        }

        #endregion
    }
}
