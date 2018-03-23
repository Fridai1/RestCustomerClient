using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerClient
{
    class Program
    {
        Customer nnn = new Customer();

        static void Main(string[] args)
        {
            Task<IList<Customer>> s = GetCustomersAsync();

            IList<Customer> p = s.Result;
            
            foreach (var c in p)
            {
                Console.WriteLine($"navn: {c.GetFirstName} LastNavn: {c.GetLastName}  Født: {c.GetYear}  med ID: {c.GetiD}");
            }

            Console.ReadLine();

        }
        private static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("http://localhost:7156/Service1.svc/customers/");
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        public override string ToString()
        {
            return $"navn: {nnn.GetFirstName} LastNavn: {nnn.GetLastName}  Født: {nnn.GetYear}  med ID: {nnn.GetiD}";
        }
    }
}
