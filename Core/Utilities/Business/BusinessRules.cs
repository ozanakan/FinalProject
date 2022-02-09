using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {//params ile istediğimiz kadar parametre , ile yollayabiliriz yollanılanları array haline getirip IResult[] içerisine atıyor
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if(!logic.Success) //logic başarısız ise eror dön
                {
                    return logic;
                }
            }
            return null; //başarılı ise birşey dönmesine gerek yok
            
        }


    }
}
