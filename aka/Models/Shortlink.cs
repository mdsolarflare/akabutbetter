using System;
using System.Collections.Generic;

namespace akabutbetter
{
    public class Shortlink
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get; set; }
        
        public string Shortname { get; set; }
        
        public string Destination { get; set; }
        
        public List<string> Owners { get; set; }
    }
}