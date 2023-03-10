using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)     
        {
            foreach(var logic in logics)                //Bütün Kurallar Gez Kurala Uymayan Varsa Onu Döndür
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;                            //Hepsi uyuyosa null döndür
        }
    }
}
