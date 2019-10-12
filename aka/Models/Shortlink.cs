using System;
using System.Collections.Generic;

namespace akabutbetter.Models
{
    public class Shortlink
    {
        public int LinkId { get; set; }
        
        public string Shortname { get; set; }
        
        public string Destination { get; set; }
        
        public List<string> Owners { get; set; }
    }
}