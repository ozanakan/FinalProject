using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {// kullanıcı şifre ve adını girdi apiye geldi burada createToken çalışcak eğer doğruysa ilgili kullanıcı
     // için veri tabanına gidip kullanıcının claimlerini buluşturucak orada bir JSON web token üreticek içerisinde bilgileri bululnduran ve bunları dönecek
        AccessToken CreateToken(User user,List<OperationClaim>operationClaims);

    }
}
