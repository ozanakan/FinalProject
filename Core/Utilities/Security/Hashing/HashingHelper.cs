using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {//hashing için yazılmış bir core class şifre gelir ve hash edilip ve salt eklenip geri gider
        public static void CreatePasswordHash(string password,out byte[]passwordHash,out byte[]passwordSalt)//out dışarıya verilecek değer gibi düşünebiliriz 
        {//.net kriptoloji HMACSHA512 yapısından yararlanıyoruz
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//string password bite çeviriyoruz parantez içinde
            }

        }
        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt )//password hash doğrulama
        {//veritabanındeki has ile kullanıcıdan gelen passwordun haslenmiş halini kontrolü eğer iki hash doğru ise true dön
         //password kullanıcının sisteme tekrardan girerken gelen string  
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
