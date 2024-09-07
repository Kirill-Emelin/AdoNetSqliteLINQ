namespace AdoNetSqliteLINQ
{
    internal class LinqQuery1
    {
        /// <summary>
        /// Метод для вывода всех клиентов, отсортированных по ContactTitle
        /// </summary>
        /// <param name="customers"></param>
        public static void GetAllCustomers(List<Customer> customers)
        {
            // Сортируем список клиентов по ContactTitle
            var filteredContactTitle = customers.OrderBy(c => c.ContactTitle);

            Console.WriteLine($"{"CustomerID",-15} {"CompanyName",-40} {"Country",-15} {"ContactTitle",-20}");
            Console.WriteLine(new string('-', 120));

            foreach (var customer in filteredContactTitle)
            {
                Console.WriteLine($"{customer.CustomerID,-15} {customer.CompanyName,-40} {customer.Country,-15} {customer.ContactTitle,-20}");
            }
        }
    }
}
