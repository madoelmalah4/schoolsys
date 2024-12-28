using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;

namespace SchoolManagmentSys.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository? Srepo;
        private readonly IEnrollmentRepository? Erepo;
        private readonly IProffesore? Prepo;

        public StudentController(IStudentRepository? srepo, IEnrollmentRepository? erepo, IProffesore? prepo)
        {
            Srepo = srepo;
            Erepo = erepo;
            Prepo = prepo;
        }

        public async Task<IActionResult> GetAllStudents()
        {
            return View(await Srepo.GetAllStudents());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student s)
        {
            await Srepo.CreateStudent(s);
            return RedirectToAction("GetAllStudents");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var student = await Srepo.GetStudentById(Id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student s , int Id)
        {
            await Srepo.EditStudentDetials(s , Id);
            return RedirectToAction("GetAllStudents");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var student = await Srepo.GetStudentById(Id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var student = await Srepo.GetStudentById(Id);
            await Srepo.DeleteStudent(student);
            return RedirectToAction("GetAllStudents");
        }
    }
}
