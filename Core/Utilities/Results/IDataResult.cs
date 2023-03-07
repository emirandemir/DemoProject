using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult  //IResultta Sadece Mesaj ve İşlem Sonucu Var(True yada False)
    {
        T Data { get; }
    }
}
