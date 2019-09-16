using System.Collections.Generic;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Сущность брэнд
    /// </summary>
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Коллекция с продуктами
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}