using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.Model;

namespace OnlineBookStore.Services
{
    public class BookStoreService : IBookStoreService
    {
        #region List

        /// <summary>
        /// List of all books in store
        /// </summary>
        readonly IEnumerable<BooksCollectionPropeties> BooksCollectionPropeties = new List<BooksCollectionPropeties>
        {
            new BooksCollectionPropeties { Title= "Unsolved murders",Author="Emily G. Thompson, Amber Hunt",Genre="Crime", Price=10.99},
            new BooksCollectionPropeties { Title= "Alice in Wonderland",Author="Lewis Carroll",Genre="Fantasy", Price=5.99},
            new BooksCollectionPropeties { Title= "A Little Love Story",Author="Roland Merullo",Genre="Romance", Price=2.40},
            new BooksCollectionPropeties { Title= "Heresy",Author="S J Parris",Genre="Fantasy", Price=6.80},
            new BooksCollectionPropeties { Title= "The Neverending Story",Author="Michael Ende",Genre="Fantasy", Price=7.99},
            new BooksCollectionPropeties { Title= "Jack the Ripper",Author="Philip Sugden",Genre="Crime", Price=16.00},
            new BooksCollectionPropeties { Title= "The Tolkien Years",Author="Greg Hildebrandt",Genre="Fantasy", Price=22.90},
        };

        /// <summary>
        /// List of books to be sold
        /// </summary>
        readonly List<BooksQuantity> BooksQuantity = new()
        {
            new BooksQuantity { Title= "Unsolved murders",Quantity=1 },
            new BooksQuantity { Title= "A Little Love Story",Quantity=1 },
            new BooksQuantity { Title= "Heresy",Quantity=1 },
            new BooksQuantity { Title= "Jack the Ripper",Quantity=1 },
            new BooksQuantity { Title= "The Tolkien Years",Quantity=1 }
        };

        #endregion

        #region Methods

        /// <summary>
        /// This function will return total order cost
        /// </summary>
        /// <returns>totalCost</returns>
        public double TotalOrderCost()
        {
            double totalCost = 0.00;
            try
            {
                foreach (var item in BooksQuantity)
                {
                    var bookDetail = GetBookDetail(item.Title);
                    switch (bookDetail.Genre.ToUpper())
                    {
                        case Helper.GenreCrime:
                            totalCost += item.Quantity * CrimeBooksDiscountRate(bookDetail.Price);
                            break;

                        default:
                            totalCost += (item.Quantity * bookDetail.Price);
                            break;
                    }
                }
                //$5.95 delivery fee for orders less than $20	
                if (totalCost < Helper.DollarValue)
                {
                    totalCost += Helper.DeliveryFee;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return totalCost;
        }
        /// <summary>
        /// This function returns book details on the basic of bookTitle
        /// </summary>
        /// <param name="bookTitle"></param>
        /// <returns></returns>
        public BooksCollectionPropeties GetBookDetail(string bookTitle)
        {
            return BooksCollectionPropeties.Single(A => A.Title == bookTitle);
        }

        /// <summary>
        /// This function returns crime book's rate after discount
        /// </summary>
        /// <param name="bookPrize"></param>
        /// <returns></returns>
        public static double CrimeBooksDiscountRate(double bookPrize)
        {
            return bookPrize - ((bookPrize * Helper.CrimeCategoriesBooksDiscount) / 100);
        }

        /// <summary>
        /// This function returns total amount after GST
        /// </summary>
        /// <param name="amount"></param>
       /// <returns></returns>
        public double GetAmountAfterGST(double amount)
        {
            return amount + ((amount * Helper.GoodsServicesTax) / 100);
        }
    }
    #endregion
}
