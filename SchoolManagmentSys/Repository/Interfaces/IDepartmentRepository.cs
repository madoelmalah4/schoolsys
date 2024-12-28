using SchoolManagmentSys.Models;

namespace SchoolManagmentSys.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartment();
    }
}
