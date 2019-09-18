using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStore.Dal.Context;
using WebStore.Domain.Entities;
using WebStore.Domain.Models.Filters;
using WebStore.Interfaces;

namespace WebStore.Implementation.SQL
{
    /// <summary>
    /// Класс для работы с данными из sql-таблицы
    /// </summary>
    public class ProductDataSql : IProductData
    {
        private readonly WebStoreContext context;

        private ProductDataSql()
        {

        }

        public ProductDataSql(WebStoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Показать брэнды
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Brand> GetBrand() => context.Brands.ToList();

        /// <summary>
        /// Показать секции
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Section> GetSection() => context.Sections.ToList();

        /// <summary>
        /// Показать продукцию
        /// </summary>
        /// <param name="filter">Фильтр по брэндам и секциям</param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = context.Products
                .Include("Brand")
                .Include("Section").AsQueryable();

            if (filter.Ids != null && filter.Ids.Count > 0)
                query = query.Where(p => filter.Ids.Contains(p.Id));
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue &&
                c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c => c.SectionId.Equals(filter.SectionId.Value));
            return query.ToList();
        }

        /// <summary>
        /// Показать продукт
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            return context.Products
                .Include("Brand")
                .Include("Section")
                .FirstOrDefault(p => p.Id == id);

        }
    }
}
