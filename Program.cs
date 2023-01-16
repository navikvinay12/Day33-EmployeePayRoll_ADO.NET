
namespace EmployeePayRoll_ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeModel employeeModel = new EmployeeModel();

            while(true)
            {
                Console.WriteLine("1 - DB Connectivity Status");
                Console.WriteLine("2 - Retrieve All Employees Details from Table in DB");
                Console.WriteLine("3 - Add new Employee Details into the Table");
                Console.WriteLine("4 - Update Salary");
                Console.WriteLine("5 - Delete Employee Records by providing Id and Name as reference");
                Console.WriteLine("6 - Get Employee Records between Date Range.");
                Console.WriteLine("7 - InsertIntoTwoTables WITHOUT UsingTSQL");
                Console.WriteLine("8 - InsertIntoTwoTablesUsingTSQL");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        employeeRepository.CheckConnection();   
                        break;
                    case 2:
                        employeeRepository.GetAllEmployee(); 
                        break;
                    case 3:
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
                        employeeRepository.AddEmployee(employeeModel); 
                        employeeRepository.GetAllEmployee();
                        break;
                    case 4:
                        employeeModel.Name = "Harish";
                        employeeModel.Id = 10;
                        employeeModel.Salary = 60000;
                        employeeRepository.UpdateEmployee(employeeModel);  
                        break;
                    case 5:
                        employeeModel.Name = "Harish";
                        employeeModel.Id = 139;
                        employeeRepository.DeleteEmployee(employeeModel);
                        break;
                    case 6:
                        employeeRepository.FetchEmployeesRecordBetweenGivenDates();
                        break;
                    case 7:
                        employeeModel.Name = "Kavitha";
                        employeeModel.Address = "Bnglr";
                        employeeModel.Salary = 87322;
                        employeeRepository.InsertIntoTwoTablesWithoutTSQL(employeeModel);
                        break;
                    case 8:
                        employeeModel.Name = "Narayan";
                        employeeModel.Address = "Mumbai";
                        employeeModel.Salary = 99999;
                        employeeRepository.InsertIntoTwoTablesUsingTSQL(employeeModel);
                        break;
                    default:
                        Console.WriteLine("Invaild Option Selected! Try Again Later");
                        break;
                }
            }
        }
    }
}