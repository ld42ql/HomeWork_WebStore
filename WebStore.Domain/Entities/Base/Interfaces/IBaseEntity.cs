namespace WebStore.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Базовая сущность для Id
    /// </summary>
   public interface IBaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }
    }
}
