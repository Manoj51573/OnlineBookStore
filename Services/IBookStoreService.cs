using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.Model;

namespace OnlineBookStore.Services
{
    public interface IBookStoreService
    {
        double TotalOrderCost();
        double GetAmountAfterGST(double BookPrize);

    }
}
