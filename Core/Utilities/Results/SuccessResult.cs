using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {//  :base ile Resulta gönderme
        // successResultta amaç managerda kullanırken (true,"başarılı") yazdırma yerine ("başarılı") yazıp geçmek true ile uğraşmamak 
        public SuccessResult(string message) : base(true,message)
        {

        }
        public SuccessResult() : base(true)   //mesaj vermeden direkt true yolluyoruz
        {

        }

    }
}
