using Microsoft.Data.Sqlite;

namespace AdoNetSqliteLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlExpression = "SELECT CustomerID, CompanyName, ContactName FROM Customers";
            using (var connection = new SqliteConnection("DataSource=NorthwindSQLite.sqlite"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) 
                    {
                        while (reader.Read())   
                        {
                            var CustomerID = reader.GetValue(0);
                            var CompanyName = reader.GetValue(1);
                            var ContactName = reader.GetValue(2);

                            Console.WriteLine($"{CustomerID} \t {CompanyName} \t {ContactName}");
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
