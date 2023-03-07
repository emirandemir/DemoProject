using Business.Abstract;
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

        public List<Product> GetAllByCategoryId(int id)
        {
            return _ProductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllProduct()
        {
            //iş kodları
            //Yetkisi Var mı ?
            return _ProductDal.GetAll();     //Data Access Layer Katmanıyla iletişime geçti.
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
