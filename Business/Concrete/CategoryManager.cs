using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public List<Category> GetAllCategory()
        {
            return _categorydal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categorydal.Get(p => p.CategoryId == categoryId);
        }
    }
}
