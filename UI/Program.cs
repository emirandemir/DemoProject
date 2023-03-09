using Business.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            productmanager productmanager = new productmanager(new EfProductDal());

            productmanager.GetAllProduct();
            
                Console.WriteLine("");
            

            

        }
    }
}
