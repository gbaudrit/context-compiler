# .NET Core REST API Backend Blueprint

## Overview

The **ContextCompiler.Prompting.Blueprints.DotNet.Api.Backend** blueprint provides comprehensive, step-by-step guidance for building professional, production-ready REST API backends using .NET Core. It covers architecture, security, validation, documentation, testing, and deployment.

## What This Blueprint Provides

This blueprint guides you through **18 detailed steps** to build a complete API backend:

1. ✅ **Project Structure** - Layered architecture with clean separation
2. ✅ **Dependency Injection** - Service configuration and middleware pipeline
3. ✅ **Domain Models** - Entity design with proper OOP principles
4. ✅ **Entity Framework Core** - Database access with migrations
5. ✅ **Repository Pattern** - Data access abstraction
6. ✅ **DTOs** - API contracts decoupled from domain
7. ✅ **Service Layer** - Business logic orchestration
8. ✅ **API Controllers** - RESTful endpoints with proper HTTP semantics
9. ✅ **JWT Authentication** - Token-based security
10. ✅ **Authorization** - Role and policy-based access control
11. ✅ **Input Validation** - FluentValidation for robust validation
12. ✅ **Error Handling** - Global exception handling with ProblemDetails
13. ✅ **Swagger/OpenAPI** - Interactive API documentation
14. ✅ **Logging & Monitoring** - Structured logs with correlation IDs
15. ✅ **CORS & Security** - Cross-origin policies and security headers
16. ✅ **Health Checks** - Liveness and readiness probes
17. ✅ **Testing** - Unit and integration test strategies
18. ✅ **Production Config** - Deployment-ready configuration

## Key Features

### 🏗️ Architecture
- **Layered Architecture**: API → Application → Domain ← Infrastructure
- **Repository Pattern** with Unit of Work
- **Service Layer** for business logic
- **DTO Pattern** for API contracts

### 🔐 Security
- **JWT Bearer Authentication** with claims
- **Role-based** and **Policy-based** authorization
- **HTTPS enforcement** with HSTS
- **Security headers** (X-Frame-Options, CSP, etc.)
- **CORS configuration** for cross-origin requests

### ✅ Quality
- **FluentValidation** for comprehensive input validation
- **Global error handling** with RFC 7807 ProblemDetails
- **Structured logging** with ILogger
- **Health checks** for monitoring
- **Comprehensive testing** (unit + integration)

### 📚 Documentation
- **Swagger/OpenAPI** with interactive UI
- **XML comments** for rich documentation
- **Request/response examples**
- **Authentication support** in Swagger UI

## Installation

### NuGet Package
```bash
dotnet add package ContextCompiler.Prompting.Blueprints.DotNet.Api.Backend
```

### Configuration
Add to your `modules.config.json`:
```json
{
  "modules": [
    {
      "id": "dotnet-api-backend-blueprint",
      "package": "ContextCompiler.Prompting.Blueprints.DotNet.Api.Backend",
      "version": "1.0.0"
    }
  ]
}
```

## Example: Building a Product API

### Step 1-3: Initialize Project and Domain

```bash
dotnet new webapi -n ProductApi
cd ProductApi
dotnet new classlib -n ProductApi.Domain
dotnet new classlib -n ProductApi.Application
dotnet new classlib -n ProductApi.Infrastructure
```

**Domain Entity** (`Product.cs`):
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
```

### Step 4-5: EF Core and Repository

**DbContext** (`ApplicationDbContext.cs`):
```csharp
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.HasIndex(e => e.Name);
        });
    }
}
```

**Repository** (`IRepository.cs`):
```csharp
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
```

### Step 6-7: DTOs and Services

**DTOs**:
```csharp
public record ProductReadDto(int Id, string Name, decimal Price, string Description);

public record ProductCreateDto(string Name, decimal Price, string Description);

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
```

**Service**:
```csharp
public interface IProductService
{
    Task<IEnumerable<ProductReadDto>> GetAllProductsAsync();
    Task<ProductReadDto?> GetProductByIdAsync(int id);
    Task<ProductReadDto> CreateProductAsync(ProductCreateDto dto);
}

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IRepository<Product> repository, ILogger<ProductService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto dto)
    {
        _logger.LogInformation("Creating product {Name}", dto.Name);
        
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(product);
        return new ProductReadDto(product.Id, product.Name, product.Price, product.Description);
    }
}
```

### Step 8: Controller

```csharp
[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Get all products
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductReadDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// Get product by ID
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductReadDto>> GetById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();
        
        return Ok(product);
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductReadDto>> Create([FromBody] ProductCreateDto dto)
    {
        var product = await _productService.CreateProductAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}
```

### Step 9: JWT Authentication

**Program.cs**:
```csharp
var builder = WebApplication.CreateBuilder(args);

// JWT Configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

**appsettings.json**:
```json
{
  "JwtSettings": {
    "Secret": "your-256-bit-secret-key-here-minimum-32-characters",
    "Issuer": "ProductApi",
    "Audience": "ProductApiClients",
    "ExpirationMinutes": 60
  }
}
```

### Step 13: Swagger Configuration

```csharp
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Product API", 
        Version = "v1",
        Description = "REST API for product management"
    });

    // JWT Authentication in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    // XML Comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
```

## Project Structure

```
ProductApi/
├── ProductApi.Api/              # Controllers, Program.cs, Middleware
│   ├── Controllers/
│   │   └── ProductsController.cs
│   ├── Middleware/
│   │   └── ExceptionHandlingMiddleware.cs
│   └── Program.cs
├── ProductApi.Application/      # Services, DTOs, Interfaces
│   ├── DTOs/
│   │   ├── ProductReadDto.cs
│   │   └── ProductCreateDto.cs
│   ├── Services/
│   │   ├── IProductService.cs
│   │   └── ProductService.cs
│   └── Validators/
│       └── ProductCreateDtoValidator.cs
├── ProductApi.Domain/           # Entities, Value Objects
│   └── Entities/
│       └── Product.cs
├── ProductApi.Infrastructure/   # DbContext, Repositories, EF Config
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Repositories/
│   │   ├── IRepository.cs
│   │   └── Repository.cs
│   └── Configurations/
│       └── ProductConfiguration.cs
└── ProductApi.Tests/            # Unit and Integration Tests
    ├── Unit/
    │   └── ProductServiceTests.cs
    └── Integration/
        └── ProductsControllerTests.cs
```

## Benefits

✅ **Production-Ready**: All essential features for real-world APIs  
✅ **Best Practices**: Follows industry-standard patterns and conventions  
✅ **Secure**: JWT auth, authorization, HTTPS, security headers  
✅ **Scalable**: Layered architecture supports growth  
✅ **Testable**: DI and separation enable comprehensive testing  
✅ **Documented**: Swagger/OpenAPI for consumer onboarding  
✅ **Maintainable**: Clear structure and separation of concerns  
✅ **Observable**: Logging, monitoring, health checks

## Related Blueprints

- **ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor** - For Razor Pages frontend
- **ContextCompiler.Prompting.Blueprints.Agile.UserStory** - For requirements documentation

## Requirements

- .NET 8.0 or later
- Entity Framework Core 8.0+
- FluentValidation 11.0+
- Swashbuckle.AspNetCore 6.0+

## License

MIT License - See LICENSE.txt for details

## Support

For issues and questions, visit [GitHub Issues](https://github.com/gbaudrit/context-compiler/issues)

---

**Built with ContextCompiler** - Structured guidance for .NET development
