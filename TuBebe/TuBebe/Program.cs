using Microsoft.EntityFrameworkCore;
using TuBebe.BD.Datos;
using TuBebe.Client.Pages;
using TuBebe.Components;

var builder = WebApplication.CreateBuilder(args);

#region Configurar el constructor de la app

var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException("Fallo la conexion a la base de datos");

builder.Services.AddDbContext<AppDbContex>(options =>options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


#endregion

var app = builder.Build();


#region Crea la aplicacion y arranca los servicios

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TuBebe.Client._Imports).Assembly);

#endregion


//Arranca la aplicacion 
app.Run();
