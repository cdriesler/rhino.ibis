using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Reviews
{
    public static class ReviewUtils
    {
        public static void ReviewWithOptions<T, U>(ref T methods, ref U options)
        {
            PropertyInfo[] optionValues = options.GetType().GetProperties();

            Type allMethods = methods.GetType();

            foreach (var property in optionValues)
            {
                Console.WriteLine(property.Name);

                if ((bool)property.GetValue(options))
                {
                    allMethods.GetMethod(property.Name.Substring(2)).Invoke(methods, null);
                }
            }
        }

        public static void ReviewAll<T>(ref T methods)
        {

        }
    }
}
