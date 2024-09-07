namespace AdoNetSqliteLINQ
{
    internal class LinqQuery2
    {
        /// <summary>
        /// Метод для вывода клиентов с указанной страной
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="country"></param>
        public static void GetCustomersByCountry(List<Customer> customers, string country)
        {
            // Отбираем клиентов, страна которых совпадает с вводом пользователя
            var filteredСountry = customers.Where(c => c.Country == country);

            Console.WriteLine($"{"CustomerID",-15} {"CompanyName",-40} {"Country",-15} {"ContactTitle",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var customer in filteredСountry)
            {
                Console.WriteLine($"{customer.CustomerID,-15} {customer.CompanyName,-40} {customer.Country,-15} {customer.ContactTitle,-20}");
            }
        }
    }
}
