using System;
using System.Collections.Generic;
using WebStore.Domain.Models;

namespace WebStore.Helpers
{
    public class GenericTestList
    {
        /// <summary>
        /// Коллекция с работниками
        /// </summary>
        public List<EmployeeView> ListEmployeeView = new List<EmployeeView>();

        static private Random random = new Random();

        /// <summary>
        /// Создаем тестовую коллекцию с работниками в лист ListEmployee
        /// </summary>
        /// <param name="count">Количество работников</param>
        public GenericTestList(int count)
        {
            TableGeneric(count);
        }

        /// <summary>
        /// Заполняем базу данных
        /// </summary>
        /// <param name="count">Количество работников</param>
        private void TableGeneric(int count)
        {
            for (int i = 1; i < count; i++)
            {
                ListEmployeeView.Add(new EmployeeView
                {
                    Id = i,
                    FirstName = RandomString(8),
                    SurName = RandomString(10),
                    Patronymic = RandomString(9),
                    Age = random.Next(18, 60),
                    DateOfEmployment = $"{random.Next(1, 30):00}/{random.Next(1, 12):00}/{2018 - random.Next(0, 18)}"
                });
            }
        }

        /// <summary>
        /// Создаем случайную строку
        /// </summary>
        /// <param name="count">Максимальное возможное количество букв</param>
        /// <returns></returns>
        static private string RandomString(int count)
        {
            int n = random.Next(5, count);
            string str = String.Empty;
            char[] arrayChar = new char[n];
            for (int i = 0; i < n; i++)
            {
                arrayChar[i] = i == 0 ? (char)random.Next(0x0410, 0x42F) : (char)random.Next(0x0430, 0x44F);
                str += arrayChar[i];
            }
            return str;
        }
        
    }
}
