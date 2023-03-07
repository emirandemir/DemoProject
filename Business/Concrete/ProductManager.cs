using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class productmanager : IProductService
    {
        IProductDal _ProductDal;

        public productmanager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public IResult Add(Product product)
        {
           

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductInValied);
            }
            _ProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _ProductDal.GetAll(p => p.CategoryId == id);
        }

        public IDataResult<List<Product>> GetAllProduct()
        {
            //iş kodları
            //Yetkisi Var mı ?
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(),true,"Ürünler Listelendi");     //Data Access Layer Katmanıyla iletişime geçti.
        }

        public Product GetById(int productId)
        {
            return _ProductDal.Get(p=>p.ProductId==productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {

            return _ProductDal.GetProductDetailDtos();
        }
    }
}
