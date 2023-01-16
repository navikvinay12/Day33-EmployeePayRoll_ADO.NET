using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace EmployeePayRoll_ADO.NET
{
    public class EmployeeRepository
    {
        //string tpVariable = @"Data Source=(localdb)\ProjectModels;Integrated Security=True";
        public static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog = PayrollService; Integrated Security = True";
        public SqlConnection connection = new SqlConnection(connectionString);
        public void CheckConnection()    //UC1 Verifying the Connectivity status with the db.
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection with database has been established.");
                this.connection.Close();
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
                using (this.connection)
                {
                    this.connection.Open();
                    string query = "select * from EmployeePayRoll";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            EmployeeModel employeeModel = new EmployeeModel();
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
                    //sqlDataReader.Close();
                    //this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddEmployee(EmployeeModel employee)     //UC3 Insertion into Table .
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("spAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@empPhone", employee.empPhone);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Deductions", employee.Deductions);
                    command.Parameters.AddWithValue("@Taxable_Pay", employee.Taxable_Pay);
                    command.Parameters.AddWithValue("@Income_Tax", employee.Income_Tax);
                    command.Parameters.AddWithValue("@Net_Pay", employee.Net_Pay);
                    int count = command.ExecuteNonQuery();
                    if (count != 0)
                    {
                        Console.WriteLine("Employee has been Added successfully into the table .");
                    }
                    else
                    {
                        Console.WriteLine("Insert Query failed");
                    }
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateEmployee(EmployeeModel employee)  //UC4 Updation of existing employee record.
        {
            try
            {
                using(connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeDetails",connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Employee Details updated succcessfully into table");
                    }
                    else
                    {
                        Console.WriteLine("Failure! Unable to Update");
                    }
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteEmployee(EmployeeModel employee)
        {
            try
            {
                connection.Open();
                //connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spDeleteEmployee", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Id", employee.Id);
                int result = command.ExecuteNonQuery();
                if (result != 0)
                    Console.WriteLine("Employee deleted succcessfully from table");
                else
                    Console.WriteLine("Failure");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void FetchEmployeesRecordBetweenGivenDates()  //UC4 Updation of existing employee record.
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = "select * from EmployeePayroll where StartDate between '2021-02-01' and GetDate()";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader(); 
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            EmployeeModel employeeModel = new EmployeeModel();
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
        //-------------------Day 34 TSQL (Foreign Key)---------------------------
        public void InsertIntoTwoTablesWithoutTSQL(EmployeeModel employee)
        {
            try
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand("dbo.spAddEmployeeReturnId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;////@Id is output parameter
                int result = command.ExecuteNonQuery();
                if (result != 0) { Console.WriteLine("Inserted into Employee table successfully"); }
                var newId = Convert.ToInt32(command.Parameters["@Id"].Value);
                string query = $"insert into Salary(EmpId,Salary) values({newId},{employee.Salary})";
                SqlCommand comd = new SqlCommand(query, connection);
                int res = comd.ExecuteNonQuery();
                if (res != 0) { Console.WriteLine("Inserted into Salary table successfully"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //-----------------------------------------------
        public void InsertIntoTwoTablesUsingTSQL(EmployeeModel employee)
        {
            SqlTransaction sqlTran = null;
            try
            {
                this.connection.Open();
                sqlTran = connection.BeginTransaction();//Start a local transaction.
                SqlCommand command = new SqlCommand("dbo.spAddEmployeeReturnId", connection, sqlTran);
                command.Transaction = sqlTran;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                int result = command.ExecuteNonQuery();
                var newId = Convert.ToInt32(command.Parameters["@Id"].Value);
                if (result != 0) { Console.WriteLine("Inserted into Employee table successfully"); }
                string query = $"insert into Salary(EmpllllId,Salary) values({newId},{employee.Salary})";
                SqlCommand comd = new SqlCommand(query, connection, sqlTran);
                int res = comd.ExecuteNonQuery();
                if (res != 0) { Console.WriteLine("Inserted into Salary table successfully."); }
                sqlTran.Commit();
            }
            catch (Exception ex)
            {
                sqlTran.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
