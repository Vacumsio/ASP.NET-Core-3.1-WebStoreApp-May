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
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Длина фамилии должна быть от 3 до 60 символов")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Возраст")]
        [Required]
        [Range(18,100, ErrorMessage ="Возраст должен быть неменьше 18 и не больше 100")]
        public int Age { get; set; }
    }
}
