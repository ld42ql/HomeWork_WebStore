﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Models.Filters
{
    /// <summary>
    /// Класс для фильтрации товаров
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Секция к которой принадлежит товар
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Коллекция идентификаторов товара
        /// </summary>
        public List<int> Ids { get; set; }
    }
}