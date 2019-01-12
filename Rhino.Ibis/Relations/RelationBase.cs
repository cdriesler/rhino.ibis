using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Relations
{
    public abstract class RelationBase
    {
        public abstract ReviewOptions ReviewOptions { get; set; }
        public abstract ReviewBase ReviewMethods { get; set; }
    }

    public abstract class ReviewBase
    { 
        public abstract RelationBase Source { get; set; }
    }

    public abstract class ReviewOptions
    {

    }
}
