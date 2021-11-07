using System;
using OnlineBookStore.Services;

namespace OnlineBookStore
{
    class Program
    {
        static void Main()
        {
            BookStoreService _bookStoreService = new BookStoreService();
            double totalOrderCost = _bookStoreService.TotalOrderCost();
            double totalOrderCostWithGST = _bookStoreService.GetAmountAfterGST(totalOrderCost);
           
            Console.WriteLine("Total Order Cost WithOut Tax:  " + Math.Round(totalOrderCost, 2) );
            Console.WriteLine("Total Order Cost With Tax:   " + Math.Round(totalOrderCostWithGST, 2));
        }
    }
}
