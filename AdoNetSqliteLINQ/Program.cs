using Microsoft.Data.Sqlite;
using System.Data;

namespace AdoNetSqliteLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            // SQL запрос для получения данных о продуктах
            string sqlExpression = @"SELECT Products.ProductID, Products.ProductName, Products.CategoryID, 
            Categories.CategoryName, Products.UnitPrice, Products.UnitsInStock 
            FROM Products
            JOIN Categories ON Products.CategoryID = Categories.CategoryID";

            // Строка подключения к базе данных
            var connectionString = $"Data Source=NorthwindSQLite.sqlite";

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
                    DataTable productsTable = new DataTable("Products");

                    productsTable.Load(reader);

                    // Добавляем таблицу в DataSet
                    ds.Tables.Add(productsTable);
                }
                // Закрываем подключение к базе данных
                connection.Close();
            }

            DataTable productsTableInMemory = ds.Tables["Products"];

            // Создаем список для хранения объектов Product
            List<Product> products = new List<Product>();

            if (productsTableInMemory != null)
            {
                // Преобразуем строки из DataTable в объекты Product
                foreach (DataRow row in productsTableInMemory.Rows)
                {
                    var product = new Product
                    {
                        ProductID = row["ProductID"].ToString(),
                        ProductName = row["ProductName"].ToString(),
                        CategoryName = row["CategoryName"].ToString(),
                        UnitPrice = row["UnitPrice"],
                        UnitsInStock = Convert.ToInt32(row["UnitsInStock"])
                    };
                    products.Add(product);
                }
                // Просим пользователя выбрать, что он хочет вывести
                Console.WriteLine("Введите:\n" +
                    "1 чтобы отсортировать продукты по имени (ProductName)\n" +
                    "2 чтобы вывести продукты, которых нет на складе\n" +
                    "3 чтобы вывести продукты, отсортированные по цене (от дешевых к дорогим)\n" +
                    "4 чтобы узнать минимальную и максимальную цену продукта\n" +
                    "5 чтобы вывести продукты, отсортированные по убыванию цены (от дорогих к дешевым)\n" +
                    "6 чтобы вывести все продукты в указанной категории\n" +
                    "7 чтобы вывести количество продуктов на складе и отсутствующих на складе\n" +
                    "8 чтобы вывести все продукты");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Table 'Products' not found in DataSet");
            }

            // Получаем выбор пользователя
            int choice = Convert.ToInt32(Console.ReadLine());

            // В зависимости от выбора пользователя выполняем соответствующее действие
            switch (choice)
            {
                case 1:
                    // Сортируем продукты по имени (ProductName) и выводим результат
                    LinqQuery1.SortByProductName(products);
                    break;

                case 2:
                    // Выводим продукты, которых нет на складе (UnitsInStock == 0)
                    LinqQuery2.GetOutOfStock(products);
                    break;

                case 3:
                    // Сортируем продукты по возрастанию цены и выводим результат
                    LinqQuery3.SortByPriceAsc(products);
                    break;

                case 4:
                    // Выводим минимальную и максимальную цену среди продуктов
                    LinqQuery4.GetMaxPrice(products);
                    break;

                case 5:
                    // Сортируем продукты по убыванию цены и выводим результат
                    LinqQuery5.SortByPriceDesc(products);
                    break;

                case 6:
                    // Запрашиваем ID категории и выводим продукты из этой категории.
                    Console.WriteLine("Введите ID категории:");
                    string categoryId = Console.ReadLine();
                    LinqQuery6.GetByCategory(products, categoryId);
                    break;

                case 7:
                    // Выводим количество продуктов на складе и отсутствующих на складе
                    LinqQuery7.SortByPriceDescasd(products);
                    break;

                case 8:
                    // Выводим все продукты
                    Query.GetAllProducts(products);
                    break;

                default:
                    // Сообщаем о неверном выборе
                    Console.WriteLine("Неверный выбор, попробуйте снова");
                    break;
            }
            Console.Read();
        }
    }
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName{ get; set; }
        public object UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
