using System;
using System.Collections.Generic;
using akabutbetter.Models;

namespace akabutbetter.Helpers
{
    public static class OwnerHelper
    {
        public static List<Owner> CreateListFrom(string[] requestOwners)
        {
            if (requestOwners == null || requestOwners.Length < 2)
            {
                throw new ArgumentException("Owners list is too small! Provide at least two owners.");
            }
            
            List<Owner> owners = new List<Owner>();

            foreach (string o in requestOwners)
            {
                owners.Add(new Owner(o));
            }

            return owners;
        }
    }
}