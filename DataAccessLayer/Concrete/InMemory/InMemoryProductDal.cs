﻿using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId=1,
                    CategoryId=1,
                    ProductName="Bardak",
                    UnitPrice=15,
                    UnitsInStock=15
                },
                new Product
                {
                    ProductId=2,
                    CategoryId=1,
                    ProductName="Kamera",
                    UnitPrice=500,
                    UnitsInStock=3
                },
                new Product
                {
                    ProductId=3,
                    CategoryId=2,
                    ProductName="Telefon",
                    UnitPrice=1500,
                    UnitsInStock=2
                },
                new Product
                {
                    ProductId=4,
                    CategoryId=2,
                    ProductName="Klavye",
                    UnitPrice=150,
                    UnitsInStock=65
                },
                new Product
                {
                    ProductId=5,
                    CategoryId=2,
                    ProductName="Fare",
                    UnitPrice=85,
                    UnitsInStock=1
                }
            };
        }

        
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product ProductDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(ProductDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product ProducttoUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            ProducttoUpdate.ProductId = product.ProductId;
            ProducttoUpdate.CategoryId = product.CategoryId;
            ProducttoUpdate.ProductName = product.ProductName;
            ProducttoUpdate.UnitPrice = product.UnitPrice;
            ProducttoUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
