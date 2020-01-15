﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace TheMovie.Api.Infrastructure
{
    public static class SwaggerServiceCollectionExtension
    {
        /// <summary>
        /// Gets enviromental path to swagger documentation file
        /// </summary>
        private static string XmlDocumentationPath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                var fileName = System.IO.Path.GetFileName(assemblyName + ".xml");
                return System.IO.Path.Combine(basePath, fileName);
            }
        }

        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movie Service API",
                    Description = "Dou calendar api to use from site dou.ua",
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT licenses",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
                c.IncludeXmlComments(XmlDocumentationPath);
            });

            return services;
        }
    }
}
