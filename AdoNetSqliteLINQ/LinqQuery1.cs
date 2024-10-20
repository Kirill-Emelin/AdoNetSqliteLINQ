using System.Diagnostics.Metrics;

namespace AdoNetSqliteLINQ
{
    internal class LinqQuery1
    {
        /// <summary>
        /// Метод для сортировки и вывода продуктов по имени
        /// </summary>
        /// <param name="customers"></param>
        public static void SortByProductName(List<Product> products)
        {
            var SortedProducts = products.OrderBy(p => p.ProductName);

            Console.WriteLine($"{"ProductID",-15} {"ProductName",-40} {"CategoryName",-20} {"UnitPrice",-20} {"UnitsInStock",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var product in SortedProducts)
            {
                Console.WriteLine($"{product.ProductID,-15} {product.ProductName,-40} {product.CategoryName,-20} {product.UnitPrice,-20} {product.UnitsInStock,-20}");
            }
        }
    }
}
