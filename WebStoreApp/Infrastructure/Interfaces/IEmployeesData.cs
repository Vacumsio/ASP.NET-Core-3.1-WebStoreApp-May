using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities.Employees;

namespace WebStoreApp.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> Get();

        Employee GetById(int id);

        int Add(Employee Employee);

        void Edit(Employee Employee);

        bool Delete(int id);

        void SaveChanges();
    }
}
