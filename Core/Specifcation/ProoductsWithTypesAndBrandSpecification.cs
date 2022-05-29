using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifcation
{
    public class ProoductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProoductsWithTypesAndBrandSpecification(ProducSpectPrams productParams)
        :base (x => 
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
                )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(X => X.ProductType);
            AddOrderBy(x => x.Name);
            Applypaging (productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort)){
                switch(productParams.Sort){
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDsc":
                        AddOrderByDesc(p=> p.Price);
                        break;
                    default:
                        AddOrderBy(p=> p.Name);
                        break;
                
                }
            }
        }

        public ProoductsWithTypesAndBrandSpecification(int id) : base(x => x.Id == id)
        {
             AddInclude(x => x.ProductBrand);
            AddInclude(X => X.ProductType);
        }
    }
}