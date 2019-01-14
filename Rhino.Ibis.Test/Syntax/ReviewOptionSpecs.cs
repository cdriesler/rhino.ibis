using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace Rhino.Ibis.Test.Syntax
{
    [TestFixture]
    public class ReviewOptionSpecs
    {
        [Test]
        public void Review_options_should_have_matching_review_method()
        {
            for (int i = 0; i < IbisClassDictionary.AllReviews.Count; i++)
            {
                var options = IbisClassDictionary.AllReviewOptions[i].GetProperties().Select(x => x.Name);
                var methods = IbisClassDictionary.AllReviews[i].GetMethods().Select(x => x.Name);

                var val = true;

                foreach (var option in options)
                {
                    if (!methods.Contains(option.Substring(2)))
                    {
                        val = false;

                        val.Should().BeTrue($"because option {option} in {IbisClassDictionary.AllReviews[i].Name} requires a matching method");

                        break;
                    }
                }

                val.Should().BeTrue("because each option should have a matching review method");
            }
        }
    }
}
