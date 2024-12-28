using Microsoft.EntityFrameworkCore;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;
using SchoolManagmentSys.ViewModels;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace SchoolManagmentSys.Repository.Implementation
{
    public class ProfessoreRepository : IProffesore
    {
        private readonly AppDbContext Db;
        public ProfessoreRepository(AppDbContext appdb)
        {
            Db = appdb;
        }

        public async Task CreateProffesoreStudent(ProffesoreModelView view)
        {
           Professor professor = new Professor() 
           {
           Did = view.Did,
           HireDate = view.HireDate,
           Pname = view.Pname,
           Pphone = view.Pphone,
           Pemail = view.Pemail,
           };

           await Db.Professors.AddAsync(professor);
           await Db.SaveChangesAsync();
        }

        public async Task DeleteProffesore(int Id)
        {
            var prof = await GetProffesoreById(Id);

            Db.Professors.Remove(prof);
            await Db.SaveChangesAsync();
        }

        public async Task EditProffesoreDetials(ProffesoreModelView view, int Id)
        {
            var prof = await GetProffesoreById(Id);

            prof.HireDate = view.HireDate;
            prof.Pname = view.Pname;
            prof.Pphone = view.Pphone;
            prof.Pemail = view.Pemail;
            prof.Did = view.Did;
            await Db.SaveChangesAsync();

        }

        public async Task<List<Professor>> GetAllProfessors()
        {
            return await Db.Professors.Include(x => x.department).ToListAsync();
        }

        public async Task<Professor> GetProffesoreById(int Id)
        {
            return await Db.Professors.Include(x => x.department).FirstOrDefaultAsync(x => x.Pid == Id);
        }
    }
}
