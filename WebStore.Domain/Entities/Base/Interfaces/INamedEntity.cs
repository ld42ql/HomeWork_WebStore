
namespace WebStore.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Сущность для имени
    /// </summary>
   public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }
    }
}
