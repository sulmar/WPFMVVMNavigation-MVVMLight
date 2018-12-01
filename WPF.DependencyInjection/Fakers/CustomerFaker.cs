using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.Fakers
{
    class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            StrictMode(true);
            Ignore(p => p.Id);
            RuleFor(p => p.FirstName, f => f.Name.FirstName());
            RuleFor(p => p.LastName, f => f.Name.LastName());
            RuleFor(p => p.Email, f => f.Internet.Email());
            RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.8f));
            FinishWith((f, customer)
                => Debug.WriteLine($"Created {customer.FirstName} {customer.LastName} {customer.Email}"));

        }
    }
}
