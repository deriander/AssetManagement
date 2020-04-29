using AssetManagement.Context;
using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository.Data
{
    public class ItemRepository : GeneralRepository<Item, MyContext>
    {
        public ItemRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}

