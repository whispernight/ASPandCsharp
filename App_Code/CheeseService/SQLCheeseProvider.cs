using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITCourse.Cheese
{
    /// <summary>
    /// Summary description for SQLBlogProvider
    /// </summary>
    public class SQLCheeseProvider : CheeseProvider
    {
        CheeseDataClassesDataContext db;

        public SQLCheeseProvider()
        {
            //
            // TODO: Add constructor logic here
            //
            db = new CheeseDataClassesDataContext();
        }

        public override Cheese GetCheese(int CheeseID)
        {
            var dataCheese = from c in db.Cheeses
                             select c;
            var cheese = dataCheese.First();
            return new Cheese { Name = cheese.CheeseName, Region = cheese.Region.RegionName, Description = cheese.CheeseDescription };
        }

        public override List<Cheese> GetCheeses()
        {
            var cheeses = from c in db.Cheeses
                          select new Cheese { Name = c.CheeseName, Description = c.CheeseDescription, Region = c.Region.RegionName };
            return cheeses.ToList();
        }
    }
}
