using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSys.Models
{
    public class Course
    {
        [Key]
        public int Cid {  get; set; }
        public string? Cname {  get; set; }
        public string? Description {  get; set; }
        public List<Enrollment>? enrollments { get; set; }
        public int Pid {  get; set; }
        [ForeignKey("Pid")]
        public Professor? professor {  get; set; }
    }
}
