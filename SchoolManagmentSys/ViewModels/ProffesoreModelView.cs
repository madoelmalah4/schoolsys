using SchoolManagmentSys.Models;

namespace SchoolManagmentSys.ViewModels
{
    public class ProffesoreModelView
    {
        public int Pid { get; set; }
        public string? Pname { get; set; }
        public string? Pemail { get; set; }
        public string? Pphone { get; set; }
        public DateTime HireDate { get; set; }
        public int Did {  get; set; }
        public List<Department> ? departments {  get; set; }
    }
}
