using ContextCompilerUI.Api.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Context Compiler UI API", Version = "v1" });
});

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICatalogService, CatalogService>();
builder.Services.AddSingleton<IArtifactsService, ArtifactsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
        policy.WithOrigins(
                builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                    ?? ["http://localhost:5173"])
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// --- App pipeline ---
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("frontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
