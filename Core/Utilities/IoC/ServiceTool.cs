using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {//.net servisColeection al ve bunları build et kısacası autofac'te oluşturulan ınjection oluşturmaya yarıyor
    //istenilen herhangi bir interface in servisteki karşılını aldığımız tool
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
