using Microsoft.Data.Sqlite;

namespace AdoNetSqliteLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // SQL-запрос для получения данных о клиентах
            string sqlExpression = "SELECT CustomerID, CompanyName, Country, ContactTitle FROM Customers";

            // Список для хранения объектов Customer
            List<Customer> customers = new List<Customer>();

            string relativePathToDB = Path.Combine("Data", "NorthwindSQLite.sqlite");

            string absolutePathToDB = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathToDB);

            // Строка подключения к базе данных
            var connectionString = $"Data Source={absolutePathToDB}";

            // Проверяем наличие файла базы данных
            if (!File.Exists(absolutePathToDB))
            {
                // Если файл базы данных не найден выводим сообщение
                Console.WriteLine($"Database file not found at: {absolutePathToDB}");
                return;
            }

            // Открываем подключение к базе данных
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) 
                    {
                        while (reader.Read())   
                        {
                            var customer = new Customer
                            {
                                CustomerID = reader.GetString(0),
                                CompanyName = reader.GetString(1),
                                Country = reader.GetString(2),
                                ContactTitle = reader.GetString(3)
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }

            // Просим пользователя выбрать, что он хочет вывести
            Console.WriteLine("Введите 1 чтобы вывести всех клиентов. 2 чтобы вывести по стране.");

            // Получаем выбор пользователя
            int choice = Convert.ToInt32(Console.ReadLine());

            // В зависимости от выбора пользователя выполняем соответствующее действие
            switch (choice)
            {
                case 1:
                    // Вывод всех клиентов
                    LinqQuery1.GetAllCustomers(customers);
                    break;

                case 2:
                    // Запрашиваем у пользователя название страны
                    Console.WriteLine("Введите страну");
                    string country = Console.ReadLine();
                    // Выводим клиентов, которые находятся в указанной стране
                    LinqQuery2.GetCustomersByCountry(customers, country);
                    break;

                default:
                    // Сообщаем о неверном выборе
                    Console.WriteLine("Неверный выбор");
                    break;
            }
            Console.Read();
        }
    }
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string ContactTitle { get; set; }
    }
}
