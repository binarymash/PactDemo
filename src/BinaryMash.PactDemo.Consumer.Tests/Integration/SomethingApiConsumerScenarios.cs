﻿using Xunit;
namespace BinaryMash.PactDemo.Consumer.Tests.Integration
{
    /// <summary>
    /// These tests only pass when the provider is running
    /// </summary>
    public class Temp
    {
        [Fact]
        public void GetVersion()
        {
            var client = new CustomerApiConsumer("http://localhost:8080");
            var version = client.GetVersion();
            Assert.Equal("1.2.3.4", version.Build);
        }

        [Fact]
        public void GetCustomer()
        {
            var client = new CustomerApiConsumer("http://localhost:8080");
            var customer = client.GetCustomer("tester");
            Assert.Equal("tester", customer.Id);
        }
    }
}
