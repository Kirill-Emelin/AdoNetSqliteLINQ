namespace AdoNetSqliteLINQ
{
    internal class LinqQuery4
    {
        /// <summary>
        /// Метод для вывода минимальной и максимальной цены продуктов
        /// </summary>
        /// <param name="products"></param>
        public static void GetMaxPrice(List<Product> products)
        {
            var MinUnitPrice = products.Min(p => p.UnitPrice);
            var MaxUnitPrice = products.Max(p => p.UnitPrice);

            Console.WriteLine($"Минимальная цена продукта:{MinUnitPrice}\n" +
                $"Максимальная цена продукта: {MaxUnitPrice}");
        }
    }
}
