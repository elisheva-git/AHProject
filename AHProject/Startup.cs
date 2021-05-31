using AHProject.BL;
using AHProject.DAL;
using AHProject.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHProject
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
            services.AddControllers();

            services.AddDbContext<AHDBContext>(options => options.UseSqlServer(
           Configuration.GetSection("ConnectionString")["AHConnection"]));
            

            services.AddScoped<IAreaDAL, AreaDAL>();
            services.AddScoped<IPrayerTextDAL, PrayerTextDAL>();
            services.AddScoped<ISettlementDAL, SettlementDAL>();
            services.AddScoped<IVolunteersDAL, VolunteersDAL>();
            services.AddScoped<IExperienceOptionalDAL, ExperienceOptionalDAL>();
            services.AddScoped<IHolidaysDAL, HolidaysDAL>();
            services.AddScoped<ISchedulingHolidayDAL, SchedulingHolidayDAL>();
            services.AddScoped<IHolidayVolunteerDAL, HolidayVolunteerDAL>();
            services.AddScoped<ISettlementHolidayDAL, SettlementHolidayDAL>();
            services.AddScoped<IVolunteersSettlementHolidayDAL, VolunteersSettlementHolidayDAL>();
            services.AddScoped<IContactPersonDAL, ContactPersonDAL>();
            services.AddScoped<IOptionalVolunteerToHolidayDAL, OptionalVolunteerToHolidayDAL>();
            services.AddScoped<IProfessionalDAL, ProfessionalDAL>();
            services.AddScoped<IProfessionalHolidaysDAL, ProfessionalHolidaysDAL>();
            services.AddScoped<ISettlementHolidaysDAL, SettlementHolidaysDAL>();
            services.AddScoped<IPasswordsDAL, PasswordsDAL>();
            services.AddScoped<IProfessionalToSchedulingHolidayDAL, ProfessionalToSchedulingHolidayDAL>();
            services.AddScoped<IProfessionalToVolunteerDAL, ProfessionalToVolunteerDAL>();
            services.AddScoped<IOptionalSettlementToHolidayDAL, OptionalSettlementToHolidayDAL>();

            services.AddScoped<IAreaBL, AreaBL>();
            services.AddScoped<IPrayerTextBL, PrayerTextBL>();
            services.AddScoped<ISettlementBL, SettlementBL>();
            services.AddScoped<IVolunteersBL, VolunteersBL>();
            services.AddScoped<IExperienceOptionalBL, ExperienceOptionalBL>();
            services.AddScoped<IHolidaysBL, HolidaysBL>();
            services.AddScoped<ISchedulingHolidayBL, SchedulingHolidayBL>();
            services.AddScoped<IHolidayVolunteerBL, HolidayVolunteerBL>();
            services.AddScoped<ISettlementHolidayBL, SettlementHolidayBL>();
            services.AddScoped<IVolunteersSettlementHolidayBL, VolunteersSettlementHolidayBL>();
            services.AddScoped<IContactPersonBL, ContactPersonBL>();
            services.AddScoped<IOptionalVolunteerToHolidayBL, OptionalVolunteerToHolidayBL>();
            services.AddScoped<IProfessionalBL, ProfessionalBL>();
            services.AddScoped<IProfessionalHolidaysBL, ProfessionalHolidaysBL>();
            services.AddScoped<ISettlementHolidaysBL, SettlementHolidaysBL>();
            services.AddScoped<IPasswordsBL, PasswordsBL>();
            services.AddScoped<IProfessionalToSchedulingHolidayBL, ProfessionalToSchedulingHolidayBL>();
            services.AddScoped<IProfessionalToVolunteerBL, ProfessionalToVolunteerBL>();
            services.AddScoped<IOptionalSettlementToHolidayBL, OptionalSettlementToHolidayBL>();


            services.AddAutoMapper(typeof(AutoMapperProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
