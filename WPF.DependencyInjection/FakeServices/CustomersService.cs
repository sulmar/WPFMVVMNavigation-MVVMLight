using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DependencyInjection.Fakers;
using WPF.DependencyInjection.IServices;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.FakeServices
{
    public class CustomersService : ICustomersService
    {
        CustomerFaker customerFaker = new CustomerFaker();

        IList<Customer> customers;

        public CustomersService()
        {
            customers = customerFaker.Generate(100);
        }

        public IList<Customer> Get() => customers;
    }
}
