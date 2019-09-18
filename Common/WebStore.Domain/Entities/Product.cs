using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Продукты
    /// </summary>
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        
        /// <summary>
        /// Секция к которой принадлежит товар
        /// </summary>
        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        /// <summary>
        /// Секция 
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Бренд к которой принадлежит товара
        /// </summary>
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }
}