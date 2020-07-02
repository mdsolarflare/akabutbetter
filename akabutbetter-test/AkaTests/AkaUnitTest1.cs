using System;
using System.Collections.Generic;
using System.Linq;
using akabutbetter.Controllers;
using akabutbetter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using Xunit.Abstractions;

namespace AkaTests
{
    public class AkaUnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AkaUnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestShortlinkModel()
        {
            List<Owner> testOwners = new List<Owner>();
            testOwners.Add(new Owner("one"));
            testOwners.Add(new Owner("two"));

            Uri testUri1 = new Uri("https://tacobell.com/");
            Shortlink testLink1 = new Shortlink(1, "tb", testUri1, testOwners);
            Assert.Equal(1, testLink1.LinkId);
            Assert.Equal("tb", testLink1.PrettyName);
            Assert.Equal("https://tacobell.com/", testLink1.Destination.ToString());
            Assert.Equal(testOwners, testLink1.Owners);
        }

        [Fact]
        public void TestAkaControllerSinglePost()
        {
            List<Owner> testOwners = new List<Owner>();
            testOwners.Add(new Owner("one"));
            testOwners.Add(new Owner("two"));
            _testOutputHelper.WriteLine(new Shortlink(1, "tb", new Uri("https://tacobell.com"), testOwners).ToString());
        }
    }
}
