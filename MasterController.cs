using MasterPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterPage.Controllers
{
    public class MasterController : Controller
    {
        private readonly DevClmsContext context;

        public MasterController(DevClmsContext context)
        {
            this.context = context;
        }





        public IActionResult Index()
        {
            ViewBag.List = context.AppEmpMasters.ToList();
            return View();
        }

        --**
        [HttpPost]
 
        public IActionResult Index(AppEmpMaster Emp, string action)
        {

            ModelState.Remove("Id");

            if (action == "delete")
            {
                var existingEmp = context.AppEmpMasters.FirstOrDefault(e => e.Id == Emp.Id);
                if (existingEmp != null)
                {
                    context.AppEmpMasters.Remove(existingEmp);
                    context.SaveChanges();
                    TempData["Success"] = "Employee deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Employee not found.";
                }

                return RedirectToAction("Index");
            }

            // ---- ADD or UPDATE ----
 
            
            if (ModelState.IsValid)
            {
                var existingEmp = context.AppEmpMasters.FirstOrDefault(e => e.Pno == Emp.Pno);

                if (existingEmp != null)
                {
                    // update selected fields
                    existingEmp.Name = Emp.Name;
                    existingEmp.Email = Emp.Email;
                    existingEmp.Mobile = Emp.Mobile;
                  //  existingEmp.ModifiedOn = DateTime.Now;

                    context.Update(existingEmp);
                    TempData["Success"] = "Employee updated successfully!";
                }
                else
                {
                    // insert new
                    Emp.Id = Guid.NewGuid();
                    Emp.Createdon = DateTime.Now;
                    context.AppEmpMasters.Add(Emp);

                    TempData["Success"] = "Employee added successfully!";
                }

                context.SaveChanges();
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Please correct the errors in the form.";
            return View(Emp);
        }








    }
}
