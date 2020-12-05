using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MatriculaWEB
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
            services.AddScoped<AlunoDAO>();
            services.AddScoped<AdministracaoHorarioDAO>();
            services.AddScoped<ConjuntoAlunoDAO>();
            services.AddScoped<DiaDAO>();
            services.AddScoped<DisciplinaDAO>();
            services.AddScoped<GradeDAO>();
            services.AddScoped<HistoricoAlunoDAO>();
            services.AddScoped<MentorDAO>();
            services.AddScoped<MentorDisciplinaDAO>();
            services.AddScoped<NivelDAO>();
            services.AddScoped<PresencaDAO>();
            services.AddScoped<TurmaDAO>();

            services.AddDbContext<Context>
                (options => options.UseSqlServer(
                    Configuration.GetConnectionString("Connection")));

            services.AddIdentity<Usuario, IdentityRole>().
                AddEntityFrameworkStores<Context>().
                    AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.AccessDeniedPath = "/Usuario/AcessoNegado";
            });

            services.AddControllersWithViews().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Aluno}/{action=Index}/{id?}");
            });
        }
    }
}
