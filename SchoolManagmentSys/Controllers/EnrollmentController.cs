using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;
using SchoolManagmentSys.ViewModels;

namespace SchoolManagmentSys.Controllers
{
    public class EnrollmentController : Controller
    {

        private readonly IStudentRepository? Srepo;
        private readonly IEnrollmentRepository? Erepo;
        private readonly IProffesore? Prepo;
        private readonly AppDbContext db;

        public EnrollmentController(IStudentRepository? srepo, IEnrollmentRepository? erepo, IProffesore? prepo , AppDbContext db)
        {
            Srepo = srepo;
            Erepo = erepo;
            Prepo = prepo;
            this.db = db;
        }


        public async Task<IActionResult> GetAllEnroll()
        {
            var Enrollments = await Erepo.GetAllEnrollments();
            return View(Enrollments);
        }

        public async Task<IActionResult> Create()
        {
            EnrollmentModelView view = new EnrollmentModelView() 
            { 
            courses = await db.Courses.ToListAsync(),
            students = await Srepo.GetAllStudents()
            };
            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EnrollmentModelView view)
        {
            await Erepo.CreateEnrollment(view);
            return RedirectToAction("GetAllEnroll");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Enrollment = await Erepo.GetEnrollmentById(Id);
            EnrollmentModelView view = new EnrollmentModelView()
            {
                courses = await db.Courses.ToListAsync(),
                students = await Srepo.GetAllStudents(),
                EnrollmentDate = DateTime.Now,
                EnrollmentId = Enrollment.Eid,
                Grad = Enrollment.Grad,
                Cid = Enrollment.Cid,
                Sid = Enrollment.Sid,
            };

            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EnrollmentModelView view ,int Id)
        {
            await Erepo.EditEnrollment(view, Id);
            return RedirectToAction("GetAllEnroll");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var Enrollment = await Erepo.GetEnrollmentById(Id);
            return View(Enrollment);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int Id)
        {
            await Erepo.DeleteEnrollment(Id);
            return RedirectToAction("GetAllEnroll");
        }

    }
}
