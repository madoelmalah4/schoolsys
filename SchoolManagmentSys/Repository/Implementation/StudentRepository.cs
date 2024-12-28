using Microsoft.EntityFrameworkCore;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;

namespace SchoolManagmentSys.Repository.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext Db;
        public StudentRepository(AppDbContext appdb)
        {
            Db = appdb;
        }

        public async Task CreateStudent(Student s)
        {
           await Db.Students.AddAsync(s);
           await Db.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student s)
        {
            Db.Students.Remove(s);
            await Db.SaveChangesAsync();
        }

        public async Task EditStudentDetials(Student s, int Id)
        {
            var student = await Db.Students.FirstOrDefaultAsync(x => x.Sid == Id);

            student.Name = s.Name;
            student.PhoneNumber = s.PhoneNumber;
            student.Address = s.Address;
            student.DOB = s.DOB;
            student.Email = s.Email;

            await Db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await Db.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int Id)
        {
            return await Db.Students.FirstOrDefaultAsync(x => x.Sid == Id);
        }
    }
}
