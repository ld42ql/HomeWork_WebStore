using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Product;
using WebStore.ViewComponents.BaseClass;
using WebStore.Interfaces;

namespace WebStore.ViewComponents
{
    public class SectionsViewComponent : BaseViewComponent<SectionViewModel, IProductData>
    {
        public SectionsViewComponent(IProductData productData) : base(productData)
        {
           
        }

        /// <summary>
        /// Показать коллекцию с секциями
        /// </summary>
        /// <returns></returns>
        public override List<SectionViewModel> GetList()
        {
            var categories = data.GetSection();
            var parentCategories = categories.Where(p => !p.ParentId.HasValue).ToList();
            var parentSections = new List<SectionViewModel>();

            foreach (var parentCategory in parentCategories)
            {
                parentSections.Add(new SectionViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentSection = null
                });
            }

            foreach (var sectionViewModel in parentSections)
            {
                var childCategories = categories.Where(c => c.ParentId.Equals(sectionViewModel.Id));
                foreach (var childCategory in childCategories)
                {
                    sectionViewModel.ChildSections.Add(new SectionViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentSection = sectionViewModel
                    });
                }
                sectionViewModel.ChildSections = sectionViewModel.ChildSections.OrderBy(c =>
                c.Order).ToList();
            }
            parentSections = parentSections.OrderBy(c => c.Order).ToList();
            return parentSections;
        }
        
    }
}
