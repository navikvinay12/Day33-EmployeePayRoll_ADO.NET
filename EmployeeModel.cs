namespace EmployeePayRoll_ADO.NET
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int empPhone { get; set; }
        public string Department { get; set; }
        public double Deductions { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
    }
}