using Microsoft.EntityFrameworkCore;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;

namespace SchoolManagmentSys.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext db;

        public DepartmentRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            return await db.Departments.ToListAsync();
        }
    }
}
