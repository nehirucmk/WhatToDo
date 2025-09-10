var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllers();

// Swagger/OpenAPI ekle
builder.Services.AddEndpointsApiExplorer(); // Endpoint keşfi
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    // Swagger UI'yi sadece geliştirme ortamında göster
    app.MapOpenApi();
    app.UseSwagger();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
