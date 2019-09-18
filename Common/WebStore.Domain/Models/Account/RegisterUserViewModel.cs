using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.Models.Account
{
    public class RegisterUserViewModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Повтрорение пароля пользователя
        /// </summary>
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        [Required, DataType(DataType.EmailAddress)]
        public string EmailUser { get; set; }
    }
}
