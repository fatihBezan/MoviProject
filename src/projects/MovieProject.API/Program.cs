using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;
using MovieProject.Service.Mappers;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dependency �njection lifecycle(ya�am d�ng�s�)
//addScopped(): uygulama boyunca 1 tane nesne �retir.nesnenin �mr� ise istek cevaba d�nene kadar.
//addsingleton(): uygulama boyunca 1 tane nesne �retir.
//addTransient():uygulamada her istenen nesne i�in ayr� bir nesne olu�turur.

builder.Services.AddScoped<ICategoryService,CategoryService>(); //IoC kayd�
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<CategoryMapper>();

builder.Services.AddControllers();

builder.Services.AddDbContext<BaseDbContext>();


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
