using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSys.Models
{
    public class Professor
    {
        [Key]
        public int Pid {  get; set; }
        public string ?Pname {  get; set; }
        public string? Pemail {  get; set; }
        public string ?Pphone {  get; set; }
        public DateTime HireDate {  get; set; }
        public int Did {  get; set; }
        [ForeignKey("Did")]
        public Department ? department { get; set; }
        public List<Course>? courses { get; set; }
    }
}
