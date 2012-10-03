using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITCourse.Cheese
{
    /// <summary>
    /// Summary description for TestBlogProvider
    /// </summary>
    public class TestCheeseProvider  : CheeseProvider
    {
        public TestCheeseProvider()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
            Console.WriteLine("Hello!!!");
	    }



        public override Cheese GetCheese(int CheeseID)
        {
            return GetSingleFakeCheese(CheeseID);
        }

        private Cheese GetSingleFakeCheese(int CheeseID)
        {
            return new Cheese {  Name="Fake Cheese" + CheeseID, Description = "Fake Description", Region = "Fake Region" };

        }

        public override List<Cheese> GetCheeses()
        {
            return GetTenTestCheeses();
        }

        private List<Cheese> GetTenTestCheeses()
        {

            List<Cheese> cheeses = new List<Cheese>();
            for (int i = 0; i < 10; i++)
            {
                cheeses.Add(GetSingleFakeCheese(i));
            }
            return cheeses;
        }
    }
}
