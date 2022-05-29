using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifcation
{
    public class ProductWithFiltersForCountSpecification: BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProducSpectPrams productParams) 
        :base (x => 
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
                )
        {
        }
    }
}