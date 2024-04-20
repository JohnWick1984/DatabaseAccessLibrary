using System;
using System.Data;
using System.Threading.Tasks;
using DatabaseAccessLibrary; 
class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "Data Source=EUGENE1984; Initial Catalog=Books; Integrated Security=True;"; // Замените на вашу строку подключения
        string query = "SELECT * FROM Books";

        DatabaseAccess dbAccess = new DatabaseAccess(connectionString);

        try
        {
            DataView result = await dbAccess.ExecuteQueryAsync(query);
            Console.WriteLine("Query executed successfully. Result:");
            PrintDataView(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.ReadLine();
    }

    static void PrintDataView(DataView dataView)
    {
        foreach (DataRowView row in dataView)
        {
            foreach (DataColumn column in dataView.Table.Columns)
            {
                Console.Write($"{column.ColumnName}: {row[column.ColumnName]}   ");
            }
            Console.WriteLine();
        }
    }

}
