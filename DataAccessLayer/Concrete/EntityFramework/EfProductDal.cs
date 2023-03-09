﻿using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, Context>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (Context context = new Context())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName,
                                                        CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };

                return result.ToList();
            }

            
           
        }
    }
}
