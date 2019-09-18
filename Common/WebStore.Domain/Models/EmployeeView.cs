using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Domain.Models
{
    /// <summary>
    /// Рабочий
    /// </summary>
    public class EmployeeView
    {
       public string errorStr = "Поле обязательное для заполнения";

        /// <summary>
        /// Номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательное для заполнения")]
        [Display(Name = "Имя")]
        [RegularExpression(@"[A-ZА-Яa-zа-я][a-zа-я]*", ErrorMessage = "Имя может состоять только из букв")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "В имени должно быть не менее 3х и не более 100 символов")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательное для заполнения")]
        [Display(Name = "Фамилия")]
        [RegularExpression(@"[A-ZА-Яa-zа-я][a-zа-я]*", ErrorMessage = "Фамилия может состоять только из букв")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "В фамилии должно быть не менее 2х и не более 100 символов")]
        public string SurName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        /// <summary>
        /// Дата устройства на работу
        /// </summary>
        [Display(Name = "Дата начала работы")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d",
                             ErrorMessage = "Введите дату в формате DD/MM/YYYY")]
        public string DateOfEmployment { get; set; }
        
    }
}

