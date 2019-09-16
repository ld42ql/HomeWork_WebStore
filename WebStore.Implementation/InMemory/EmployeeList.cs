using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Interfaces;
using WebStore.Domain;
using WebStore.TestProject;


namespace WebStore.Implementation.InMemory
{
    /// <summary>
    /// Операции с коллекцией работникова
    /// </summary>
    public class EmployeeList : IWorkingData<EmployeeView>
    {
        /// <summary>
        /// Коллекция с работниками
        /// </summary>
        private readonly List<EmployeeView> employees;
        
        /// <summary>
        /// Коллекция с работниками
        /// </summary>
        public EmployeeList() => this.employees = new GenericTestList(25).ListEmployeeView;

        public void AddNew(EmployeeView model)
        {
            model.Id = this.employees.Max(e => e.Id) + 1;
            employees.Add(model);
        }

        public void Commit() => throw new NotImplementedException(); // Не используется

        public void Delete(int Id) => this.employees?.Remove(GetEmployee(Id));
        
        public IEnumerable<EmployeeView> GetAll() => this.employees;

        public EmployeeView GetEmployee(int Id) => employees.FirstOrDefault(e => e.Id.Equals(Id));
    }
}
