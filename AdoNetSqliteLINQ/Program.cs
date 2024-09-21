using Microsoft.Data.Sqlite;
using System.Data;

namespace AdoNetSqliteLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            // SQL запрос для получения данных о клиентах
            string sqlExpression = "SELECT CustomerID, CompanyName, Country, ContactTitle FROM Customers";

            string ProjectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;

            string relativePathToDB = Path.Combine("NorthwindSQLite.sqlite");

            string absolutePathToDB = Path.Combine(ProjectDirectory, relativePathToDB);

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

                // Создаем команду для выполнения SQL запроса
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                // Выполняем команду и читаем результаты
                using (SqliteDataReader reader = command.ExecuteReader())
                { 
                    // Создаем DataTable и загружаем в него данные из reader
                    DataTable customersTable = new DataTable("Customers");

                    customersTable.Load(reader);

                    // Добавляем таблицу в DataSet
                    ds.Tables.Add(customersTable);
                }
                // Закрываем подключение к базе данных
                connection.Close();
            }

            DataTable customersTableInMemory = ds.Tables["Customers"];

            // Создаем список для хранения объектов Customer
            List<Customer> customers = new List<Customer>();

            if (customersTableInMemory != null)
            {
                // Преобразуем строки из DataTable в объекты Customer
                foreach (DataRow row in customersTableInMemory.Rows)
                {
                    var customer = new Customer
                    {
                        CustomerID = row["CustomerID"].ToString(),
                        CompanyName = row["CompanyName"].ToString(),
                        Country = row["Country"].ToString(),
                        ContactTitle = row["ContactTitle"].ToString()
                    };
                    customers.Add(customer);
                }
                // Просим пользователя выбрать, что он хочет вывести
                Console.WriteLine("Введите 1 чтобы вывести всех клиентов. 2 чтобы вывести по стране.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Table 'Customers' not found in DataSet");
            }

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
