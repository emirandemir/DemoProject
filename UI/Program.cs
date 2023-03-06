using Business.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
           
            foreach(var item in productManager.GetAllProduct())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
