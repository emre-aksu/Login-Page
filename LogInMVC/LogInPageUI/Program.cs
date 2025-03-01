using BusinessLayer.Abstract;
using BusinessLayer.Managers;
using BusinessLayer.Validators.FluentValidation;
using DataAccessLayer.InterFace;
using DataAccessLayer.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ModelLayer.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();// Session, uygulama genelinde kullanýma açýlýyor
builder.Services.AddHttpContextAccessor();


//IoC'e dependeny injection ile enjekte edileccek nesnelerin neler olduðunu register ediyoruz (Entity framework ile çalýþan Repository objelerini bu arayüzlere yaratýlýp verilmesi gerektiðini söylemiþ oluyoruz.)
//------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();




builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

//------------------------------------------------------------------------------------------------------------

//Automapper için;
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//2.yöntem

//------------------------------------------------------------------------------------------------------------

//Login dto tipindeki bir nesnenin validasyonu yapýlmasý gerektiðinde o tipe ait kurallar sýnýfýndan iþletilsin.
builder.Services.AddScoped<IValidator<LogInDto>, LogInDtoValidator>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();
app.UseSession(); // Session, uygulama genelinde kullanýma açýlýyor

app.UseAuthorization();
app.MapAreaControllerRoute(
    name: "userPanelDefault",
    areaName: "UserPanel",
    pattern: "/user/{controller=Authentication}/{action=LogIn}/{id?}");

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
