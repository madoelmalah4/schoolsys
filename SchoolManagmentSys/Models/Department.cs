using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSys.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }
        public string? Dname {  get; set; }
        public DateTime StartDate { get; set; }
        public List<Professor> ?professors { get; set; }
    }
}
