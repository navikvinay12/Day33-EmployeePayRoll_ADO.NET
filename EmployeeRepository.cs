using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace EmployeePayRoll_ADO.NET
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog = PayrollService; Integrated Security = True";
        public static void CheckConnection()    //UC1 Verifying the Connectivity status with the db.
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection with database has been established.");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Source connection. " + ex.Message);
            }
        }
    }
}
