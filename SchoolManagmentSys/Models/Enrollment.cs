using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSys.Models
{
    public class Enrollment
    {
        [Key]
        public int Eid {  get; set; }
        public string ?Grad {  get; set; }
        public int Sid { get; set; }
        [ForeignKey("Sid")]
        public Student ? student { get; set; }
        public int Cid {  get; set; }
        [ForeignKey("Cid")]
        public Course? course { get; set; }

    }
}
