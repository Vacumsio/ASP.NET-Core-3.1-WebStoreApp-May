using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(256)]
        [Display(Name = "Введите Имя")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Введите пароль")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
