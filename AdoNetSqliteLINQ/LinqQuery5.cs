using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetSqliteLINQ
{
    internal class LinqQuery5
    {
        /// <summary>
        /// Метод для вывода продуктов по убыванию цены.
        /// </summary>
        /// <param name="products"></param>
        public static void SortByPriceDesc(List<Product> products)
        {
            var SortedByPriceDesc = products.OrderByDescending(p => p.UnitPrice);

            Console.WriteLine($"{"ProductID",-15} {"ProductName",-40} {"CategoryID",-15} {"UnitPrice",-20} {"UnitsInStock",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var product in SortedByPriceDesc)
            {
                Console.WriteLine($"{product.ProductID,-15} {product.ProductName,-40} {product.CategoryID,-15} {product.UnitPrice,-20} {product.UnitsInStock,-20}");
            }
        }
    }
}
