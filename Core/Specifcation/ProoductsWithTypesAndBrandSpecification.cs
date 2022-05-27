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
        public ProoductsWithTypesAndBrandSpecification(string sort)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(X => X.ProductType);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort)){
                switch(sort){
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