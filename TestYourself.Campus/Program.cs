using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TestYourself.Core.Interfaces;
using TestYourself.Data;
using TestYourself.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddDbContext<TestYourselfDBContext>(options => {
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestYourselfDBContext"));
});
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = "/Account/Index";
                  options.LogoutPath = "/Account/SignOut";
                  options.AccessDeniedPath = "/Account/AccessDenied";
              });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
