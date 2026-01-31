using RegistroEstudiantes.Components;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.DAL;
using RegistroEstudiantes.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(ConStr));

builder.Services.AddScoped<AlertaService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<AsignaturaService>();
builder.Services.AddScoped<TipoPuntoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();