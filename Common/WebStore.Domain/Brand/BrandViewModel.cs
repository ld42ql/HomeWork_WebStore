using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Brand
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Количество товаров бренда
        /// </summary>
        public int ProductsCount { get; set; }
    }
}
