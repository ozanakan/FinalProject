using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün Ismi Geçersiz.";        
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductListed = "Ürünler Listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Böyle bir isim zaten var.";
        public static string CategoryLimitExceded = "Category Limiti Aşıldı.";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi.";
    }
}
