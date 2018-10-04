using API.Logic.Core;
using API.Logic.Interface.Core;
using API.Repository;
using API.Repository.Core;
using API.Repository.Interface.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
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
            //Habilita request´s de do´mínios diferentes. No nosso caso, é a porta, mas ele valida.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //Autenticação via Jwt (JSON Web Token)
            //Configurando autenticação via TOKEN JWT (JSON Web Token)
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            //Adiciona o Context
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringContext")));

            //Injeção de dependência nos objetos
            //No .NetCore, você tem que adicionar ao escopo a relação interface/implementação para ele te retornar um objeto instanciado via construtor
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaLogic, PessoaLogic>();

            //Adiciona sessão na aplicação
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Usa o Cors definido "AllowLocalhost"
            app.UseCors("AllowLocalhost");

            //Configura o uso de autenticação
            app.UseAuthentication();

            //Configura o uso de sessão
            app.UseSession();

            app.UseMvc();
        }
    }
}
