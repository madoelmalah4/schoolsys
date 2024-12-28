using Microsoft.EntityFrameworkCore;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;
using SchoolManagmentSys.ViewModels;

namespace SchoolManagmentSys.Repository.Implementation
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext Db;
        public EnrollmentRepository(AppDbContext appdb)
        {
            Db = appdb;
        }
        public async Task CreateEnrollment(EnrollmentModelView view)
        {
            Enrollment enrollment = new Enrollment() {
            Cid = view.Cid,
            Sid = view.Sid, 
            Grad = view.Grad,
            };

            await Db.Enrollments.AddAsync(enrollment);
            await Db.SaveChangesAsync();
        }

        public async Task DeleteEnrollment(int Id)
        {
            var enroll = await GetEnrollmentById(Id);
            Db.Enrollments.Remove(enroll);
            await Db.SaveChangesAsync();
        }

        public async Task EditEnrollment(EnrollmentModelView view, int Id)
        {
            var Enrollment = await Db.Enrollments.Include(x=>x.student).Include(x=>x.course).FirstOrDefaultAsync(x => x.Eid == Id);

            Enrollment.Sid = view.Sid;
            Enrollment.Cid = view.Cid;
            Enrollment.Grad = view.Grad;

            await Db.SaveChangesAsync();
        }

        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            return await Db.Enrollments.Include(x => x.course).Include(x => x.student).ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(int Id)
        {
            return await Db.Enrollments.Include(x => x.student).Include(x => x.course).FirstOrDefaultAsync(x => x.Eid == Id);
        }
    }
}
