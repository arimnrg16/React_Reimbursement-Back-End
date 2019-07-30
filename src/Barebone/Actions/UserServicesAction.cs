using Barebone.Services;
using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barebone.Actions
{
    public class UserServicesAction : IConfigureServicesAction
    {
        public int Priority => 100;

        public void Execute(IServiceCollection services, IServiceProvider sp)
        {
            services.AddTransient<IImageService, ImageService>();
        }
    }
}
