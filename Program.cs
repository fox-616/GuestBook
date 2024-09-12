using GuestBook.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//1.2.4 �bProgram.cs���H�̿�`�J���g�k���gŪ���s�u�r�ꪺ����
builder.Services.AddDbContext<GuestBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection")));

//���USession
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

//1.3.3 �bProgram.cs���g�ҥ�Initializer���{��(�n�g�bvar app = builder.Build();����)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/Error");
    //app.UseStatusCodePagesWithRedirects("/Home/Error");

}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//�ҥ�Session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
