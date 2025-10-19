using Company.DAL.Models.shared;

namespace Company.DAL.Models.Department
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }   
    }
}
