using SchoolManagmentSys.Models;
using SchoolManagmentSys.ViewModels;

namespace SchoolManagmentSys.Repository.Interfaces
{
    public interface IProffesore
    {
        Task CreateProffesoreStudent(ProffesoreModelView view);
        Task EditProffesoreDetials(ProffesoreModelView view, int Id);
        Task<Professor> GetProffesoreById(int Id);
        Task DeleteProffesore(int Id);
        Task<List<Professor>> GetAllProfessors();
    }
}
