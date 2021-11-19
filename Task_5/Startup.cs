using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.DAL.Interfaces;
using Task_5.DAL;
using Task_5.DAL.Enteties;
using Task_5.DAL.Repositories;
using Task_5.BLL.Interfaces;
using Task_5.BLL.DTO;
using Task_5.BLL.Services;
using Task_5.DAL.EF;

//using Task_5.BLL.Interfaces;
//using Task_5.BLL.DTO;
//using Task_5.BLL.Services;

namespace Task_5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string conString = "Server=DESKTOP-FTEU4FU\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

            services.AddDbContext<HotelContext>(options => options.UseSqlServer(conString));
            services.AddTransient<IBaseService, BaseService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRecordService, RecordService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IService<UserDTO>, UserService>();
            services.AddTransient<IPriceforCategoryService, PriceforCategoryService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task_5", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task_5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
