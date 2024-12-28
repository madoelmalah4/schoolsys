using SchoolManagmentSys.Models;

namespace SchoolManagmentSys.ViewModels
{
    public class EnrollmentModelView
    {
        public int EnrollmentId {  get; set; }
        public int Sid {  get; set; }
        public int Cid {  get; set; }
        public List<Student> ?students {  get; set; }
        public List<Course> ? courses {  get; set; }
        public DateTime EnrollmentDate { get; set; }  
        public string ?Grad {  get; set; }
    }
}
