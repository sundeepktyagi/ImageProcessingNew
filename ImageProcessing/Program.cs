using ImageProcessing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IImageOperationService, Effect1OperationService>();
builder.Services.AddScoped<IImageOperationService, Effect2OperationService>();
builder.Services.AddScoped<IImageOperationService, Effect3OperationService>();
builder.Services.AddScoped<IImageOperationServiceCollection, ImageOperationServiceCollection>();


builder.Services.AddControllers();
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
