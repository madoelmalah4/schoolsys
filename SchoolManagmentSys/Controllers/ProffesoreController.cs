using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSys.Models;
using SchoolManagmentSys.Repository.Interfaces;
using SchoolManagmentSys.ViewModels;

namespace SchoolManagmentSys.Controllers
{
    public class ProffesoreController : Controller
    {

        private readonly IStudentRepository? Srepo;
        private readonly IEnrollmentRepository? Erepo;
        private readonly IProffesore? Prepo;
        private readonly IDepartmentRepository? Drepo;

        public ProffesoreController(IStudentRepository? srepo, IEnrollmentRepository? erepo, IProffesore? prepo , IDepartmentRepository? drepo)
        {
            Srepo = srepo;
            Erepo = erepo;
            Prepo = prepo;
            Drepo = drepo;
        }

       
        public async Task<IActionResult> GetAllPro()
        {
            return View(await Prepo.GetAllProfessors());
        }

        public async Task<IActionResult> Create()
        {
            ProffesoreModelView view = new ProffesoreModelView()
            {
                departments = await Drepo.GetAllDepartment(),
            };
            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProffesoreModelView view)
        {
            await Prepo.CreateProffesoreStudent(view);
            return RedirectToAction("GetAllPro");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var pro = await Prepo.GetProffesoreById(Id);
            var deps = await Drepo.GetAllDepartment();
            ProffesoreModelView model = new ProffesoreModelView()
            {
                departments = deps,
                HireDate = pro.HireDate,
                Pemail = pro.Pemail,
                Pname = pro.Pname,
                Pphone = pro.Pphone,
                Pid = pro.Pid,
                Did = pro.Did,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProffesoreModelView view, int Id)
        {
            await Prepo.EditProffesoreDetials(view, Id);    
            return RedirectToAction("GetAllPro");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var pro = await Prepo.GetProffesoreById(Id);
            return View(pro);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmaation(int Id)
        {
            await Prepo.DeleteProffesore(Id);
            return RedirectToAction("GetAllPro");
        }

    }
}
