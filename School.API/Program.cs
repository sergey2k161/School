using Microsoft.AspNetCore.Identity;
using School.Bussiness.Extension;
using School.DataBase;
using School.DataBase.Extension;
using School.DataBase.Models.BaseModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataBase();
builder.Services.AddBussiness();

builder.Services.AddIdentity<CommonUser, IdentityRole<int>>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
