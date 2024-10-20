namespace AdoNetSqliteLINQ
{
    internal class LinqQuery3
    {
        /// <summary>
        /// Метод для вывода продуктов по возрастанию цены
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="contactTitle"></param>
        public static void SortByPriceAsc(List<Product> products)
        {
            var SortedByPrice = products.OrderBy(p => p.UnitPrice);

            Console.WriteLine($"{"ProductID",-15} {"ProductName",-40} {"CategoryName",-20} {"UnitPrice",-20} {"UnitsInStock",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var product in SortedByPrice)
            {
                Console.WriteLine($"{product.ProductID,-15} {product.ProductName,-40} {product.CategoryName,-20} {product.UnitPrice,-20} {product.UnitsInStock,-20}");
            }
        }
    }
}
