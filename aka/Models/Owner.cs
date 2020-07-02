using System.Collections.Generic;

namespace akabutbetter.Models
{
    public class Owner
    {
        public Owner(string o)
        {
            Username = o;
        }

        public string Username { get; set; }
    }
}