    using Caso2.Interfaces;
    using Caso2.Models;
    using Caso2.Repositories;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
    
    builder.Services.AddDbContext<ServiciosDbContext>(options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 36)) // Usa la versión de tu MySQL
        ));

    // Agregar servicios a la aplicación
    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


    // 🔹 Agregar servicios de autorización
    builder.Services.AddAuthorization(); 

    // Configurar Swagger
    builder.Services.AddEndpointsApiExplorer(); 
    builder.Services.AddSwaggerGen();

    


    var app = builder.Build();

    // Configurar el pipeline HTTP
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
    else
    {
        // Habilitar Swagger solo en desarrollo
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        });
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    // 🔹 Agregar autorización después de la configuración de rutas
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();