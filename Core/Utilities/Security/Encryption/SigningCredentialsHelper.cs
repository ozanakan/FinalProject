using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {//amaç burada bir JSON wb token kullanıcaksın ve security keyin güvenlik anahtarın budur.Şifreleme algoritmanda budur 
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
        }//hangi anahtarı kullancaksın ve hangi algoritme kullanıcaksın onu veriyoruz
    }
}
