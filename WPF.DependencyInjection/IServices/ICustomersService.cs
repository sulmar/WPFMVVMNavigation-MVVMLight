using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.IServices
{
    public interface ICustomersService
    {
        IList<Customer> Get();
    }
}
