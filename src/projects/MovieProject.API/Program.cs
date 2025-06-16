using Microsoft.EntityFrameworkCore;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Categories;
using MovieProject.Service.Concretes;
using MovieProject.Service.Helpers;
using MovieProject.Service.Mappers.Categories;
using MovieProject.Service.Mappers.Profiles;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dependency ýnjection lifecycle(yaþam döngüsü)
//addScopped(): uygulama boyunca 1 tane nesne üretir.nesnenin ömrü ise istek cevaba dönene kadar.
//addsingleton(): uygulama boyunca 1 tane nesne üretir.
//addTransient():uygulamada her istenen nesne için ayrý bir nesne oluþturur.

builder.Services.AddScoped<ICategoryService,CategoryService>(); //IoC kaydý
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryMapper,CategoryAutoMapper>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddScoped<IMovieRepository,MovieRepository>(); 
builder.Services.AddScoped<ICloudinaryHelper,CloudinaryHelper>();   
builder.Services.AddScoped<CategoryBusinessRules>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));


builder.Services.AddControllers();

builder.Services.AddDbContext<BaseDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
