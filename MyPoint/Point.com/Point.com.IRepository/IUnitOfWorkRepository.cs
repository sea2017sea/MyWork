using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;

namespace Point.com.IRepository
{
    public interface IUnitOfWorkRepository
    {
        string PersistNewItem(params  ModelBase[] item);
        string PersistUpdatedItem(params ModelBase[] items);
    }
}
