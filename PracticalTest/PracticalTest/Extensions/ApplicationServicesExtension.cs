using Microsoft.AspNetCore.Mvc;
using PracticalTest.Errors;
using PracticalTest.Helpers;
using PracticalTest.Manager;
using PracticalTest.Manager.Contract;
using PracticalTest.Repository;
using PracticalTest.Repository.Context;
using PracticalTest.Repository.Contract;

namespace PracticalTest.Extension
{
    public static class ApplicationServicesExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
          IConfiguration config, IWebHostEnvironment env)
        {
            services.AddSingleton<DapperContext>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddScoped<IReportService, ReportService>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });

            return services;
        }
    }
}
