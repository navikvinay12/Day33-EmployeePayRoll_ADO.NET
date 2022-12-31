using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
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
        public SqlConnection connection = new SqlConnection(connectionString);

        public void CheckConnection()    //UC1 Verifying the Connectivity status with the db.
        {
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
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    this.connection.Open();
                    string query = "select * from EmployeePayRoll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.Id = sqlDataReader.GetInt32(0);
                            employeeModel.Name = sqlDataReader.GetString(1);
                            employeeModel.Salary = sqlDataReader.GetDouble(2);
                            employeeModel.StartDate = sqlDataReader.GetDateTime(3);
                            employeeModel.Gender = sqlDataReader.GetString(4);
                            employeeModel.empPhone = sqlDataReader.GetInt32(5);
                            employeeModel.Department = sqlDataReader.GetString(6);
                            employeeModel.Address = sqlDataReader.GetString(7);
                            employeeModel.Deductions = sqlDataReader.GetDouble(8);
                            employeeModel.Taxable_Pay = sqlDataReader.GetDouble(9);
                            employeeModel.Income_Tax = sqlDataReader.GetDouble(10);
                            employeeModel.Net_Pay = sqlDataReader.GetDouble(11);
                            Console.WriteLine($"{employeeModel.Id} {employeeModel.Name} {employeeModel.Salary} {employeeModel.StartDate} {employeeModel.Gender} {employeeModel.empPhone}" +
                                $"{employeeModel.empPhone} {employeeModel.Department} {employeeModel.Address} {employeeModel.Deductions} {employeeModel.Taxable_Pay} {employeeModel.Income_Tax} {employeeModel.Net_Pay}  ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
