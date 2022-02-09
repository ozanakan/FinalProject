using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty();//boş olamaz
            RuleFor(p=>p.ProductName).MinimumLength(2);//minimim 2 karakter olmalı
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);//0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(20).When(p=>p.CategoryId==1);//unitprice 10eşit ve büyük olsun ne zaman categoriyid=1 olduğu zaman
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");//kendimize özel doğrulamamız (startwithA kendi tanımımız )productname A ile başlamalı örneği ve WithMessage ile kendi mesajımızı girebiliriz
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
