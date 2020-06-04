using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Models
{
    public class EmployeeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 30 символов")]
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
    }
}
