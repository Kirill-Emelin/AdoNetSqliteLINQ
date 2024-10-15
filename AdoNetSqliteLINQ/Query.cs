using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetSqliteLINQ
{
    class Query
    {
        /// <summary>
        /// Метод для вывода всех продуктов
        /// </summary>
        /// <param name="products"></param>
        public static void GetAllProducts(List<Product> products)
        {
            Console.WriteLine($"{"ProductID",-15} {"ProductName",-40} {"CategoryID",-15} {"UnitPrice",-20} {"UnitsInStock",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID,-15} {product.ProductName,-40} {product.CategoryID,-15} {product.UnitPrice,-20} {product.UnitsInStock,-20}");
            }
        }
    }
}
