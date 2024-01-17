using Microsoft.EntityFrameworkCore;
using webapi.DB;
using webapi.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Default = builder.Configuration.GetConnectionString("Default");
builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddCors(option =>
// {
//     builder.AddPolicy("MyPolicy",builder=>
//     {
//         builder.AllowAnyOrigin()
//         .AllowAnyMethod()
//         .AllowAnyHeader();
//     });
// });

builder.Services.AddDbContext<AppDBContext>(options=>
options.UseSqlServer(Default));
var app = builder.Build();
//  builder.Services.AddControllers(Options =>
//  {
// Options.Filters.Add(new CustomExceptionFilterAttribute());   
//  });
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
     app.UseStatusCodePagesWithReExecute("/Error/{0}"); 



app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();//Attribute Routing 
app.MapControllerRoute( 
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");//Conventional routing
app.Run();
