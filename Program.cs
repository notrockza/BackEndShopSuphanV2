using ShopSuphan.Installers;
using ShopSuphan.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.MyInstallerExtensions(builder);
// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();//

app.UseStaticFiles(); //อนุญาตเข้าหาไฟล์จากภายนอกได้
app.UseHttpsRedirection();

app.UseRouting();//

app.UseCors(CorsInstaller.MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
