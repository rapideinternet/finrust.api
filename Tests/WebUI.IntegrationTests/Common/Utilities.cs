﻿using FinRust.Domain.Entities;
using FinRust.Persistence;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinRust.WebUI.IntegrationTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void InitializeDbForTests(FinRustDbContext context)
        {
            context.Customers.Add(new Customer
            {
                CustomerId = 1,
                Name = "Test Customer"
            });

            context.Customers.Add(new Customer
            {
                CustomerId = 2,
                Name = "Test Customer 2"
            });

            context.SaveChanges();
        }
    }
}
