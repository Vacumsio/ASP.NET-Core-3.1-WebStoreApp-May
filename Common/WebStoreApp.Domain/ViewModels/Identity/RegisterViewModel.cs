using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Domain.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = ("Минимальная длина 3 символа"))]
        [MaxLength(256)]
        [Display(Name = "Введите Имя")]
        [Remote("IsNameFree","Account")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
