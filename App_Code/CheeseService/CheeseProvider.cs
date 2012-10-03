using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;


namespace IITCourse.Cheese
{
    /// <summary>
    /// Summary description for BlogProvider
    /// </summary>
    public abstract class CheeseProvider : ProviderBase
    {
        //Properties
        

        //Methods
        public abstract Cheese GetCheese(int CheeseID);
        public abstract List<Cheese> GetCheeses();
        
        public CheeseProvider()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    public class CheeseProviderCollection : ProviderCollection
    {
        public new CheeseProvider this[string name]
        {
            get { return (CheeseProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is CheeseProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }

    public class Cheese
    {
        //TODO
        public string Name { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

    }

    


}
