using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetSqliteLINQ
{
    internal class LinqQuery6
    {
        /// <summary>
        /// Метод для вывода продуктов принадлежащих указанной категории
        /// </summary>
        /// <param name="products"></param>
        /// <param name="categoria"></param>
        public static void GetByCategory(List<Product> products, string categoryId)
        {
            var ProductsInCategory = products.Where(p => p.CategoryName == categoryId);

            Console.WriteLine($"{"ProductID",-15} {"ProductName",-40} {"CategoryName",-20} {"UnitPrice",-20} {"UnitsInStock",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var product in ProductsInCategory)
            {
                Console.WriteLine($"{product.ProductID,-15} {product.ProductName,-40} {product.CategoryName,-20} {product.UnitPrice,-20} {product.UnitsInStock,-20}");
            }
        }
    }
}
