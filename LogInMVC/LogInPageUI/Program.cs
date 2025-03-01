using BusinessLayer.Abstract;
using BusinessLayer.Managers;
using BusinessLayer.Validators.FluentValidation;
using DataAccessLayer.InterFace;
using DataAccessLayer.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ModelLayer.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();// Session, uygulama genelinde kullan�ma a��l�yor
builder.Services.AddHttpContextAccessor();


//IoC'e dependeny injection ile enjekte edileccek nesnelerin neler oldu�unu register ediyoruz (Entity framework ile �al��an Repository objelerini bu aray�zlere yarat�l�p verilmesi gerekti�ini s�ylemi� oluyoruz.)
//------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();




builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

//------------------------------------------------------------------------------------------------------------

//Automapper i�in;
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//2.y�ntem

//------------------------------------------------------------------------------------------------------------

//Login dto tipindeki bir nesnenin validasyonu yap�lmas� gerekti�inde o tipe ait kurallar s�n�f�ndan i�letilsin.
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
app.UseSession(); // Session, uygulama genelinde kullan�ma a��l�yor

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
