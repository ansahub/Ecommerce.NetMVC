using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repositories
{
    public interface IOrderRepository
    {
        int AddOrderFromCart(string userId);
    }
}
