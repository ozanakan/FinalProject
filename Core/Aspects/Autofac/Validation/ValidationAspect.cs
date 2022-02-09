﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception  //Aspect
    {//Aspect metodun başında sonunda hata verdiğinde çalışacak yapıdır.
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {//defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//yanlış tip atmasını engelliyoruz add üstündeki  (typeof(ProductValidator) geliyor örneğin bunun içine 
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//burada MethodInterception içindeki önceçalışma metodunu override ederek tekrar kodluyoruz
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//calışma anında newleme yapıyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}