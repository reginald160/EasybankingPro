using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class EntityProvider<TModel> where TModel : class, new()
    {
        public  bool IsLockable()
        {
            return typeof(TModel).GetInterfaces().Contains(typeof(IModelEvent));
        }
    }
}
