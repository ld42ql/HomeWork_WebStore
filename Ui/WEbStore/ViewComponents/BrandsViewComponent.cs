using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Models.Brand;
using WebStore.Interfaces;
using WebStore.ViewComponents.BaseClass;

namespace WebStore.ViewComponents
{
    public class BrandsViewComponent : BaseViewComponent<BrandViewModel, IProductData>
    {
        public BrandsViewComponent(IProductData productData) : base(productData)
        {
        }

        /// <summary>
        /// Создание коллекции брэндов
        /// </summary>
        /// <returns></returns>
        public override List<BrandViewModel> GetList()
        {
            var dbBrands = data.GetBrand();
            return dbBrands.Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order,
                ProductsCount = 0
            }).OrderBy(b => b.Order).ToList();
        }
    }
}
