namespace AdoNetSqliteLINQ
{
    internal class LinqQuery2
    {
        /// <summary>
        /// Метод для вывода списка продуктов отсутствующих на складе.
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="country"></param>
        public static void GetOutOfStock(List<Product> products)
        {
            var OutOfStockProducts = products.Where(p => p.UnitsInStock == 0);

            Console.WriteLine($"{"ProductID",-15} {"ProductName",-40} {"CategoryName",-20} {"UnitPrice",-20} {"UnitsInStock",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var product in OutOfStockProducts)
            {
                Console.WriteLine($"{product.ProductID,-15} {product.ProductName,-40} {product.CategoryName,-20} {product.UnitPrice,-20} {product.UnitsInStock,-20}");
            }
        }
    }
}
