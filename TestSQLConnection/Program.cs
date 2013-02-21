using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace TestSQLConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Success!!!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Failed to connect due to : {0}", e.Message));
                    if (e.InnerException != null) Console.WriteLine(string.Format("Inner exception {0}", e.InnerException));
                    if (!string.IsNullOrEmpty(e.Source)) Console.WriteLine(string.Format("Source {0}", e.Source));
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
