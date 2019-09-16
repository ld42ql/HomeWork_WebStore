using System.Collections.Generic;

namespace WebStore.Domain.Catalogs
{
    public class CatalogViewModel
    {
        /// <summary>
        /// Фильтр по брэнду
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Фильтр по секции
        /// </summary>
        public int? SectionId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
