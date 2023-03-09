using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //T bir class olmalı
    //T IEntity türünden bir class olmalı
    //T'ye IEntity olmaması için new lenebilme şartı getiriyoruz. 
    public interface IEntityRepository<T> where T : class , IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null); //Linq sorgulama işlemleri yapmamızı sağlıyor. Bu şartlara uygun olanların hepsini getir.
        T Get(Expression<Func<T, bool>> filter);  
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
