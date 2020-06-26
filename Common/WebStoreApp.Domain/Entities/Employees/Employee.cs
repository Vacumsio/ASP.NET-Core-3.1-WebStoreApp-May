using System.ComponentModel.DataAnnotations;
using WebStoreApp.Domain.Entities.Base;

namespace WebStoreApp.Domain.Entities.Employees
{
    public class Employee : BaseEntity
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
    }
}
