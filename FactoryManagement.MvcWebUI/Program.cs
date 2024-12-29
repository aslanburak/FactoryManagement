using FactoryManagement.Business.Abstract;
using FactoryManagement.Business.Concrete;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.DataAccess.Concrete.EntityFramework;
using FactoryManagement.MvcWebUI.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using FactoryManagement.Entities.Concrete.CustomIdentity;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FactoryContext>(options => { 
options.UseLazyLoadingProxies();
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FactoryContext>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<FactoryContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<FactoryContext>();
builder.Services.AddScoped<IFactoryService,FactoryManager>();
builder.Services.AddScoped<IFactoryDal, EfFactoryDal>();
builder.Services.AddScoped<IBuildingService, BuildingManager>();
builder.Services.AddScoped<IBuildingDal, EfBuildingDal>();
builder.Services.AddScoped<IWarehouseService, WarehouseManager>();
builder.Services.AddScoped<IWarehouseDal, EfWarehouseDal>();
//builder.Services.AddScoped<IPersonnelService, PersonnelManager>();
//builder.Services.AddScoped<IPersonnelDal, EfPersonnelDal>();
builder.Services.AddScoped<IMaterialService, MaterialManager>();
builder.Services.AddScoped<IMaterialDal,EfMaterialDal>();   
builder.Services.AddScoped<IMaterialWarehouseService, MaterialWarehouseManager>();
builder.Services.AddScoped<IMaterialWarehouseDal, EfMaterialWarehouseDal>();
builder.Services.AddScoped<IMaterialTransactionService,MaterialTransactionManager>();
builder.Services.AddScoped<IMaterialTransactionDal,EfMaterialTransactionDal>();
builder.Services.AddScoped<IMaterialRequestService, MaterialRequestManager>();
builder.Services.AddScoped<IMaterialRequestDal, EfMaterialRequestDal>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Kullanýcý doðrulanmamýþsa buraya yönlendirilir.
    options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisi olmayan kullanýcýlar için
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminOrPersonnel", policy =>
        policy.RequireRole("Admin", "Personnel"));
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

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Factory}/{action=ListFactory}/{id?}");

app.Run();
