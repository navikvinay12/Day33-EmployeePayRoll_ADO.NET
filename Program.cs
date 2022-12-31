
namespace EmployeePayRoll_ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeModel employeeModel = new EmployeeModel();
            Console.WriteLine("1 - DB Connectivity Status");
            Console.WriteLine("2 - Retrieve All Employees Details from Table in DB");
            Console.WriteLine("3 - Add new Employee Details into the Table");
            Console.WriteLine("4 - Update Salary");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    employeeRepository.CheckConnection();   //UC1 Checking Connectivity Status with the DataBase.
                    break;
                case 2:
                    employeeRepository.GetAllEmployee();    //UC2 Retrieve all data from Table.
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
                    employeeRepository.AddEmployee(employeeModel);    //UC3 Adding new Employee into the Table.
                    employeeRepository.GetAllEmployee();
                    break;
                case 4:
                    employeeModel.Name = "Harish";
                    employeeModel.Id = 10;
                    employeeModel.Salary = 60000;
                    employeeRepository.UpdateEmployee(employeeModel);   //UC4 Update existing Employee Details
                    break;
                default:
                    Console.WriteLine("Invaild Option Selected! Try Again Later");
                    break;
            }
        }
    }
}