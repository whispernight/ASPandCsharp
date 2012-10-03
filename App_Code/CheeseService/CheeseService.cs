using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration.Provider;


namespace IITCourse.Cheese
{
    /// <summary>
    /// Summary description for BlogService
    /// </summary>
    public class CheeseService
    {
        private static CheeseProvider _provider = null;
        private static CheeseProviderCollection _providers = null;
        private static object _lock = new object();

        public CheeseProvider Provider
        {
            get { return _provider; }
        }

        public CheeseProviderCollection Providers
        {
            get { return _providers; }
        }

        public static Cheese GetCheeese(int CheeseID)
        {
            LoadProviders();
            return _provider.GetCheese(CheeseID);
        }

        public static List<Cheese> GetCheeses()
        {
            LoadProviders();
            return _provider.GetCheeses();
        }
        
        private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (_lock)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Get a reference to the <imageService> section
                        CheeseServiceSection section = (CheeseServiceSection)
                            WebConfigurationManager.GetSection
                            ("system.web/CheeseService");

                        // Load registered providers and point _provider
                        // to the default provider
                        _providers = new CheeseProviderCollection();
                        ProvidersHelper.InstantiateProviders
                            (section.Providers, _providers,
                            typeof(CheeseProvider));
                        _provider = _providers[section.DefaultProvider];

                        if (_provider == null)
                            throw new ProviderException
                                ("Unable to load default ImageProvider");
                    }
                }
            }
        }

    }
}
