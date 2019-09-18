using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain;
using WebStore.Interfaces;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IWorkingData<EmployeeView> employeesData;

        private EmployeeController() { }

        public EmployeeController(IWorkingData<EmployeeView> data) => this.employeesData = data;

        [AllowAnonymous]
        public IActionResult Index() => View(employeesData.GetAll());

        /// <summary>
        /// Детальные данные одного работника
        /// </summary>
        /// <param name="Id">Номер работника</param>
        /// <returns>
        /// Если работник существует, то показывает страницу с работником 
        /// Усли нет, то страницу "Not Found"
        /// </returns>
        public IActionResult EmployeeDetails(int Id) =>
            (employeesData.GetEmployee(Id) != null) ? View(employeesData.GetEmployee(Id)) : View("_NotFound");

        /// <summary>
        /// Добавление или редактирование сотрудника
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = employeesData.GetEmployee(id.Value);
                if (model is null)
                    return View("_NotFound");
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(EmployeeView model)
        {
            ValidMetod(model);

            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    var dbItem = employeesData.GetEmployee(model.Id);
                    if (dbItem is null)
                        return View("_NotFound");

                    dbItem.Id = model.Id;
                    dbItem.FirstName = model.FirstName;
                    dbItem.SurName = model.SurName;
                    dbItem.Age = model.Age;
                    dbItem.Patronymic = model.Patronymic;
                    dbItem.DateOfEmployment = model.DateOfEmployment;
                }
                else
                {
                    employeesData.AddNew(model);
                }
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View(model);
            }
        }
        
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id"></param>
        [Route("delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Проверка возраста, имени, фамилии и отчества
        /// </summary>
        /// <param name="model"></param>
        private void ValidMetod(EmployeeView model)
        {
            if (model.Age < 18 || model.Age > 75)
            {
                ModelState.AddModelError("Age", "Ошибка возраста!");
            }
        }
    }
}