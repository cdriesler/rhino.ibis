using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Relate
{
    public abstract class RelationBase
    {
        public abstract ReviewOptions ReviewOptions { get; set; }
        public abstract ReviewBase ReviewMethods { get; set; }

        public RelationBase Review(ReviewOptions options)
        {
            ReviewOptions = options;
            PropertyInfo[] optionValues = options.GetType().GetProperties();

            Type reviewType = ReviewMethods.GetType();

            foreach (var property in optionValues)
            {
                if ((bool)property.GetConstantValue())
                {
                    reviewType.GetMethod(property.Name.Substring(2)).Invoke(this, null);
                }
            }

            return this;
        }
    }

    public abstract class ReviewBase
    { 
        public abstract RelationBase Source { get; set; }
        //public abstract Dictionary<string, Action> ReviewMethods { get; set; }
    }

    public abstract class ReviewOptions
    {

    }
}
