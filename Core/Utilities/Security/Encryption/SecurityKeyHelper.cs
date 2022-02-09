using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{//
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {// appsettings içerisindeki verdiğimiz securityKey içindeki uydurma key ile encryptiona parametre geçemiyoruz onu bir bite array haline getirmemiz
         // lazım securtykeyhelper bunu bite array haline getiriyor ve symmetricSecurityKey simetrik anahtar haline getiriyor kısacası JSON web tokenin ihtiyac duyduğu yapılar
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
