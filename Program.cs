
namespace EmployeePayRoll_ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.CheckConnection();   //UC1 Checking Connectivity Status with the DataBase.
            employeeRepository.GetAllEmployee();    //UC2 Retrieve all data from Table.
        }
    }
}