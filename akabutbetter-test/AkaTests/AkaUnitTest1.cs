using System;
using System.Collections.Generic;
using akabutbetter.Models;
using Xunit;

namespace AkaTests
{
    public class AkaUnitTest1
    {
        [Fact]
        public void TestShortlinkModel()
        {
            List<Owner> testOwners = new List<Owner>();
            testOwners.Add(new Owner());
            testOwners.Add(new Owner());

            Uri testUri1 = new Uri("https://tacobell.com/");
            Shortlink testLink1 = new Shortlink(1, "tb", testUri1, testOwners);
            Assert.Equal(1, testLink1.LinkId);
            Assert.Equal("tb", testLink1.PrettyName);
            Assert.Equal("https://tacobell.com/", testLink1.Destination.ToString());
            Assert.Equal(testOwners, testLink1.Owners);
        }
    }
}
