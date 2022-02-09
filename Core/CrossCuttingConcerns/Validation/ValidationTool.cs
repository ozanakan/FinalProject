using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {   //ValidationTool ne yapar biz ona bir IValidator veriyoruz doğrulama kurallarının olduğu class örnek ProductValidator bir tanede doğrulama için varlık ver örneğin Product daha sonra 
        // IValidator Validate metodunu kullanarak doğru olup olmadığını kontrol ettik  
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
