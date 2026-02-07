namespace SimpleDotNetSqlApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Department { get; set; }
        public decimal? Salary { get; set; }
    }
}
