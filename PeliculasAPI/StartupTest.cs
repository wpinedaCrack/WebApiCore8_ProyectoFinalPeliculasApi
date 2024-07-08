using Microsoft.AspNetCore.Identity;

namespace PeliculasAPI
{
    public class StartupTest
    {
        public StartupTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(StartupTest));

            //services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosAzure>();
            //services.AddHttpContextAccessor();

            //services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

            //services.AddScoped<PeliculaExisteAttribute>();

            //services.AddSingleton(provider =>

            //    new MapperConfiguration(config =>
            //    {
            //        var geometryFactory = provider.GetRequiredService<GeometryFactory>();
            //        config.AddProfile(new AutoMapperProfiles(geometryFactory));
            //    }).CreateMapper()
            //);

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //sqlServerOptions => sqlServerOptions.UseNetTopologySuite()
            //));

            //services.AddControllers()
            //    .AddNewtonsoftJson();

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //  .AddEntityFrameworkStores<ApplicationDbContext>()
            //  .AddDefaultTokenProviders();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //   .AddJwtBearer(options =>
            //       options.TokenValidationParameters = new TokenValidationParameters
            //       {
            //           ValidateIssuer = false,
            //           ValidateAudience = false,
            //           ValidateLifetime = true,
            //           ValidateIssuerSigningKey = true,
            //           IssuerSigningKey = new SymmetricSecurityKey(
            //       Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
            //           ClockSkew = TimeSpan.Zero
            //       }
            //   );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
