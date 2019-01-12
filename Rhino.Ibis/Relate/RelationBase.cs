using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Relate
{
    public abstract class RelationBase
    {
        public abstract ReviewBase Review {get; set;}

        public ReviewBase Review(ReviewOptions options)
        {

        }
    }

    public abstract class ReviewBase
    {
        public abstract RelationBase Source { set; }
        public abstract Dictionary<string, Action> ReviewMethods { get; set; }
    }

    public abstract class ReviewOptions
    {

    }
}
