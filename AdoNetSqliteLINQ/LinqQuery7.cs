using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetSqliteLINQ
{
    internal class LinqQuery7
    {
        /// <summary>
        /// Метод для вывода количества продуктов на складе и отсутствующих на складе
        /// </summary>
        /// <param name="products"></param>
        public static void SortByPriceDescasd(List<Product> products)
        {
            var InStockCount = products.Count(p => p.UnitsInStock > 0);
            var OutOfStockCount = products.Count(p => p.UnitsInStock == 0);

            Console.WriteLine($"Количество продуктов на складе: {InStockCount}");
            Console.WriteLine($"Количество продуктов, которых нет на складе: {OutOfStockCount}");
        }
    }
}
