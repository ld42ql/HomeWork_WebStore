using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
   public class NamedEntity : BaseEntity, INamedEntity
    {
        /// <summary>
        /// Наименнование
        /// </summary>
        public string Name { get; set; }
    }
}
