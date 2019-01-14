using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Rhino.Ibis.Test.Syntax
{
    [TestFixture]
    public class ReviewSpecs
    {
        [Test]
        public void Review_methods_should_have_matching_review_option()
        {
            for (int i = 0; i < IbisClassDictionary.AllReviews.Count; i++)
            {
                var options = IbisClassDictionary.AllReviewOptions[i].GetProperties().Select(x => x.Name);
                var methods = IbisClassDictionary.AllReviews[i].GetMethods().Select(x => x.Name);

                var val = true;

                var ignore = new List<string>()
                {
                    "get_Source",
                    "set_Source",
                    "Results",
                    "ToString",
                    "Equals",
                    "GetHashCode",
                    "GetType"
                };

                foreach (var method in methods)
                {
                    if (ignore.Contains(method)) continue;

                    if (!options.Contains($"Do{method}"))
                    {
                        val = false;

                        val.Should().BeTrue($"because method {method} in {IbisClassDictionary.AllReviews[i].Name} requires a matching option");

                        break;
                    }
                }

                val.Should().BeTrue("because each method should have a matching review option");
            }
        }
    }
}
