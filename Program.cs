
namespace EmployeePayRoll_ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.CheckConnection();   //UC1 Checking Connectivity Status with the DataBase.
            employeeRepository.GetAllEmployee();    //UC2 Retrieve all data from Table.
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Harish";
            employeeModel.Salary = 5432.1;
            employeeModel.StartDate = DateTime.Now;
            employeeModel.Gender = "M";
            employeeModel.empPhone = 734757;
            employeeModel.Address = "krnt";
            employeeModel.Department = "HR";
            employeeModel.Deductions = 666.66;
            employeeModel.Taxable_Pay = 1200.91;
            employeeModel.Income_Tax = 14410.92;
            employeeModel.Net_Pay = 44333.34;
            employeeRepository.AddEmployee(employeeModel);    //UC3 Adding new Employee into the Table.
        }
    }
}