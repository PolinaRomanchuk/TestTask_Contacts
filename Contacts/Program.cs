using Contacts;
using Contacts.Services;
using Data.Sql;
using Data.Sql.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IContactService>(
    diContainer => new ContactService(diContainer.GetService<IContactRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);

builder.Services.AddScoped<IContactRepository>(x => new ContactRepository(x.GetService<WebContext>()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Seed();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=ContactList}/{id?}");

app.Run();
