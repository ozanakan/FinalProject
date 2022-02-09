using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
   public static class ServiceCollectionExtensions
    {//core katmanı dahil olmak üzere ekliyeceğimiz tüm enjectionları tek bir yerde toplayabileceğimiz bir yere dönüştü
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach  (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
