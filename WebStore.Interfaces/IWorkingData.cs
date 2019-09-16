using System.Collections.Generic;

namespace WebStore.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с коллекцией моделей
    /// </summary>
    /// <typeparam name="T">Модель</typeparam>    public interface IWorkingData<T>
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получение сотрудника по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        T GetEmployee(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить нового
        /// </summary>
        /// <param name="model">Сотрудник</param>
        void AddNew(T model);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(int id);
    }
}
