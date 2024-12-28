using SchoolManagmentSys.Models;

namespace SchoolManagmentSys.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task CreateStudent(Student s);
        Task EditStudentDetials(Student s,int Id);
        Task<Student> GetStudentById(int Id);
        Task DeleteStudent(Student s);
    }
}
