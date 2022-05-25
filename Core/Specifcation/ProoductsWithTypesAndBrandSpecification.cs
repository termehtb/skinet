using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifcation
{
    public class ProoductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProoductsWithTypesAndBrandSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(X => X.ProductType);
        }

        public ProoductsWithTypesAndBrandSpecification(int id) : base(x => x.Id == id)
        {
             AddInclude(x => x.ProductBrand);
            AddInclude(X => X.ProductType);
        }
    }
}