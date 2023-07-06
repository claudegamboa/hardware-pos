using hardware_pos.Application;
using hardware_pos.Domain.AggregatesModel.CategoryAggregate;
using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate;
using hardware_pos.Domain.SeedWork;
using hardware_pos.Infrastructure;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using UnitOfMeasure = hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects.UnitOfMeasure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var documentStore = new DocumentStore
{
    Urls = new[] { builder.Configuration["ravenDb:server"] },
    Database = builder.Configuration["ravenDb:database"]
};

documentStore.Initialize();

builder.Services.AddScoped(c => documentStore.OpenAsyncSession());

builder.Services.AddSingleton<IQrCodeGenerate, QrCodeGenerator>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ItemApplicationService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
builder.Services.AddScoped<CategoryApplicationService>();
builder.Services.AddScoped<UnitOfMeasureApplicationService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
