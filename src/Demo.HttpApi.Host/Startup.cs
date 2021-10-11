using Demo.CivitMeetings;
using Demo.InspectMasterCategory;
using Demo.InspectSchMeetings;
using Demo.MeetingInspector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

namespace Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMeetingInspectorAfl, MeetingInspectorBll>();
            services.AddScoped<ICivitMeetingAfl, CivitMeetingBll>();
            services.AddScoped<IInspectSchMeetingAfl,InspectSchMeetingBll>();
            services.AddScoped<IInspectMstCategoryAfl, InspectMstCategoryBll>();
            services.AddApplication<DemoHttpApiHostModule>();
            //            services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);

            //         services.AddControllers().AddJsonOptions(x =>
            //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            //services.AddControllers()
            //     .AddNewtonsoftJson();
            // services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

            //services.AddMvc().AddJsonOptions(options => {
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


            //});

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
