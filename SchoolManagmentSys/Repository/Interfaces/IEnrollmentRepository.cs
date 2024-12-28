using SchoolManagmentSys.Models;
using SchoolManagmentSys.ViewModels;

namespace SchoolManagmentSys.Repository.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task CreateEnrollment(EnrollmentModelView view);
        Task DeleteEnrollment(int Id);
        Task<Enrollment> GetEnrollmentById(int Id);
        Task EditEnrollment(EnrollmentModelView view , int Id);
        Task<List<Enrollment>> GetAllEnrollments();
    }
}
