using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents.BaseClass
{
    /// <summary>
    /// Базовый класс для компонента представления
    /// </summary>
    /// <typeparam name="T">Класс представления</typeparam>
    /// <typeparam name="I">Интерфейс представления</typeparam>
    public class BaseViewComponent<T, I> : ViewComponent
    {
        public readonly I data;
        public BaseViewComponent(I data)
        {
            this.data = data;
        }


        /// <summary>
        /// Асинхронный вызов коллекции
        /// </summary>
        /// <returns>Возвращает секцию</returns>
        public IViewComponentResult Invoke() => View(GetList());

        /// <summary>
        /// Передать коллекция с данными
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList() => throw new NotImplementedException();

    }
}

