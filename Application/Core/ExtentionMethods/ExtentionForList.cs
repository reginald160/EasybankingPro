using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.ExtentionMethods
{
    public static class ExtentionForList 
    {
        public static bool NullList(this List<object> objects) 
         {
            return objects.Count() > 0 ? true : false;

        }
    }

}
