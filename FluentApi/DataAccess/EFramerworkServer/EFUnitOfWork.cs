using FluentApi.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.DataAccess.EFramerworkServer
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository => new EFCustomerRepository();

        public IOrderRepository OrderRepository => new EFOrderRepository();
    }
}
