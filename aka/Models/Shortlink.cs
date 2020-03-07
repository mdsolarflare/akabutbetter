using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace akabutbetter.Models
{
    public class Shortlink
    {
        public int LinkId { get; set; }
        
        public string Shortname { get; set; }
        
        public string Destination { get; set; }
        
        public List<string> Owners { get; set; }

        public override string ToString()
        {
            return "{ LinkId: " + this.LinkId
                                + ", Shortname: " + this.Shortname
                                + ", Destination: " + this.Destination
                                + ", Owners: " + this.Owners.ToList().ToString() + " }";
        }
    }
}