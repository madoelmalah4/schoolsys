using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSys.Models
{
    public class Student
    {
        [Key]
        public int Sid {  get; set; }
        public string? Name { get; set; }
        public DateTime DOB { get; set; }
        public string? Email {  get; set; }
        public int PhoneNumber {  get; set; }
        public string? Address {  get; set; }
        public List<Enrollment>? enrollments { get; set; }
    }
}
