using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;

        public productmanager(IProductDal productDal, ICategoryService categoryService)
        {
            _ProductDal = productDal;
            _categoryService = categoryService;

        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _ProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductInValied);
            }
            _ProductDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll().ToList());

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllProduct()
        {
            //iş kodları
            //Yetkisi Var mı ?
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(), Messages.ProductListed);     //Data Access Layer Katmanıyla iletişime geçti.
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_ProductDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailDto>>(_ProductDal.GetProductDetailDtos());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _ProductDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)  //Bir Kategoride En fazla 15 ürün bulunabilir.
        {
            var result = _ProductDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string proName)
        {
            var result = _ProductDal.GetAll(p=>p.ProductName==proName).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

       private IResult CheckIfCategoryLimitExceded()                      //En fazla 15 kategori bulunabilir.
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceted);
            }
            return new SuccessResult();
        }
    }
}
