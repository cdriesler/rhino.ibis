using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Rhino.Geometry;
using System.Reflection;
using Rhino.Ibis.Reviews.Curves;

namespace Rhino.Ibis.Test.Reviews.Curves
{
    [TestFixture]
    public class CurvesReviewSpecs
    {
        [Test]
        public void Should_have_options_boolean_for_each_review_method()
        {
            var options = typeof(CurvesReviewOptions).GetProperties().Select(x => x.Name);
            var methods = typeof(CurvesReview).GetMethods().Select(x => x.Name);

            var val = true;

            foreach (var option in options)
            {
                if (!methods.Contains(option.Substring(2)))
                {
                    val = false;

                    val.Should().BeTrue($"because option {option} requires a matching method");

                    break;
                }
            }

            /* TODO: Figure out how to sanitize list of methods.
            foreach (var method in methods)
            {
                if (!options.Contains($"Do{method}"))
                {
                    val = false;

                    val.Should().BeTrue($"because method {method} requires a matching option");

                    break;
                }
            }
            */

            val.Should().BeTrue("because each relation should have a review option for each of its methods");
        }
    }
}
