using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldsCountryInfoApp.Model
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public double Population { get; set; }
        public string Location { get; set; }
        public string Weather{ get; set; }
        public Country Country { get; set; }
        
    }
}