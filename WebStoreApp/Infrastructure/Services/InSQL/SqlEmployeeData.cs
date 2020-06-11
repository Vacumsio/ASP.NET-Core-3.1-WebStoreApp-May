using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.DAL.Context;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Models;

namespace WebStoreApp.Infrastructure.Services.InSQL
{
    public class SqlEmployeeData : IEmployeesData
    {
        public readonly WebStoreDB _db;

        public SqlEmployeeData(WebStoreDB db) => _db = db;
        public int Add(Employee Employee)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Employee Employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
