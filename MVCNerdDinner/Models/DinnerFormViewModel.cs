using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Models
{
    public class DinnerFormViewModel
    {
        private static string[] _countries = new[] { 
        "USA",
        "Afghanistan",
        "Albania",
        "Zimbabwe"
        };

        //Properties

        public Dinner Dinner { get; private set; }
        public SelectList Countries { get; private set; }

        //Constructor
        public DinnerFormViewModel(Dinner dinner)
        {
            Dinner = dinner;
            Countries = new SelectList(_countries, dinner.Country);

        }
    }
}