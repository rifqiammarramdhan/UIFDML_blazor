namespace SimpleCrud.DataAccess.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = default!;
        public string Department { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = default!;
    }
}
