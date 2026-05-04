using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Prompt;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Blueprints.DotNet.Api.Backend;

internal sealed class DotNetApiBackendBlueprintComposerModule(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("blueprints.dotnet.api.backend", GlobalPipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("dotnet.api.backend")
            .WithName(".NET Core REST API Backend Development")
            .WithDescription("Comprehensive guide for building a professional, production-ready REST API backend using .NET Core with layered architecture, JWT authentication, comprehensive validation, and industry best practices.")

            .WithObjective(o => o
                .WithId("OBJ-API-1")
                .WithDescription("Build a scalable, maintainable API architecture that can grow with business needs")
                .WithRationale("Layered architecture with clear separation of concerns ensures long-term maintainability and allows independent scaling of components"))
            .WithObjective(o => o
                .WithId("OBJ-API-2")
                .WithDescription("Implement robust security measures including authentication, authorization, and data protection")
                .WithRationale("APIs are primary attack vectors; JWT authentication, authorization policies, and security best practices protect against common vulnerabilities"))
            .WithObjective(o => o
                .WithId("OBJ-API-3")
                .WithDescription("Ensure API reliability through proper error handling, validation, logging, and monitoring")
                .WithRationale("Production APIs must handle failures gracefully, provide actionable logs, and enable proactive monitoring"))
            .WithObjective(o => o
                .WithId("OBJ-API-4")
                .WithDescription("Provide comprehensive API documentation through OpenAPI/Swagger for developers and consumers")
                .WithRationale("Well-documented APIs accelerate integration, reduce support overhead, and improve developer experience"))
            .WithObjective(o => o
                .WithId("OBJ-API-5")
                .WithDescription("Design the API for testability with clear contracts and dependency injection")
                .WithRationale("Testable code enables rapid development cycles, reduces bugs, and increases confidence in changes"))

            .WithGlobalMustConstraint(m => m
                .WithId("MUST-ARCH-1")
                .WithText("Follow layered architecture: API/Controllers → Services → Repositories → Domain")
                .WithRationale("Separation of concerns improves maintainability, testability, and allows independent evolution of layers"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-DI-1")
                .WithText("Use dependency injection for all services, repositories, and cross-cutting concerns")
                .WithRationale("DI enables loose coupling, testability, and flexible configuration management"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-ASYNC-1")
                .WithText("Use async/await for all I/O operations (database, external APIs, file system)")
                .WithRationale("Asynchronous operations improve scalability and resource utilization under load"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-JWT-1")
                .WithText("Implement JWT Bearer authentication for protected endpoints")
                .WithRationale("JWT tokens provide stateless authentication, enabling horizontal scaling without session affinity"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-VALID-1")
                .WithText("Validate all input data using FluentValidation or Data Annotations before processing")
                .WithRationale("Input validation prevents invalid data from entering the system and provides clear error messages"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-ERROR-1")
                .WithText("Implement global error handling middleware for consistent error responses")
                .WithRationale("Consistent error responses improve API usability and prevent information leakage"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-LOG-1")
                .WithText("Use structured logging (ILogger) with appropriate log levels for diagnostics")
                .WithRationale("Structured logs enable efficient searching, filtering, and alerting in production environments"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-SWAGGER-1")
                .WithText("Configure Swagger/OpenAPI with detailed documentation, examples, and response types")
                .WithRationale("Interactive API documentation reduces integration time and serves as living documentation"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-VERSION-1")
                .WithText("Implement API versioning strategy (URL path or header-based) from the start")
                .WithRationale("Versioning enables non-breaking changes and smooth evolution of the API"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-DTO-1")
                .WithText("Use DTOs (Data Transfer Objects) to decouple API contracts from domain models")
                .WithRationale("DTOs provide control over what data is exposed and prevent over-posting vulnerabilities"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REPO-1")
                .WithText("Use Repository pattern to abstract data access and enable unit testing")
                .WithRationale("Repositories decouple business logic from data access implementation and enable in-memory testing"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-EF-1")
                .WithText("Use Entity Framework Core for data access with migrations for schema management")
                .WithRationale("EF Core provides type-safe database access, change tracking, and version-controlled schema evolution"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-HTTPS-1")
                .WithText("Enforce HTTPS for all endpoints using HSTS and automatic redirection")
                .WithRationale("HTTPS protects data in transit and is essential for secure authentication token transmission"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-CORS-1")
                .WithText("Configure CORS policies explicitly based on deployment environment")
                .WithRationale("Explicit CORS configuration prevents unauthorized cross-origin access while enabling legitimate clients"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-HEALTH-1")
                .WithText("Implement health check endpoints for database and external dependencies")
                .WithRationale("Health checks enable load balancers and orchestrators to detect and route around failures"))

            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-CTRL-1")
                .WithText("Do not put business logic in controllers - controllers should orchestrate only")
                .WithRationale("Controllers handle HTTP concerns; business logic in controllers leads to poor testability and duplication"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-DB-1")
                .WithText("Do not access DbContext directly from controllers - use repositories/services")
                .WithRationale("Direct database access in controllers violates separation of concerns and prevents proper testing"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-ENTITY-1")
                .WithText("Do not expose domain entities directly in API responses - use DTOs")
                .WithRationale("Exposing entities creates tight coupling, prevents API evolution, and may leak sensitive data"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-BLOCK-1")
                .WithText("Do not use .Result or .Wait() on async operations - use await")
                .WithRationale("Blocking async calls can cause deadlocks and reduces scalability"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-EX-1")
                .WithText("Do not catch generic Exception without re-throwing - catch specific exceptions")
                .WithRationale("Generic exception handling can hide bugs and prevent proper error reporting"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-LOG-1")
                .WithText("Do not log sensitive data (passwords, tokens, PII) even at debug level")
                .WithRationale("Logged sensitive data can be exposed through log aggregation tools or file access"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-SECRET-1")
                .WithText("Do not hardcode secrets or connection strings - use configuration and user secrets")
                .WithRationale("Hardcoded secrets in source code are security vulnerabilities and prevent environment-specific configuration"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-ANON-1")
                .WithText("Do not leave endpoints anonymous by default - explicitly mark [AllowAnonymous]")
                .WithRationale("Secure by default principle prevents accidentally exposing protected endpoints"))

            .WithAssumption(a => a
                .WithId("AS-NET-1")
                .WithDescription(".NET 8.0 or later with C# 12 features available")
                .WithRationale("Modern .NET features improve performance and developer productivity"))
            .WithAssumption(a => a
                .WithId("AS-DB-1")
                .WithDescription("Relational database (SQL Server, PostgreSQL, MySQL) is the primary data store")
                .WithRationale("EF Core and repository pattern are optimized for relational databases"))
            .WithAssumption(a => a
                .WithId("AS-REST-1")
                .WithDescription("API follows REST principles with resource-based URLs and HTTP verbs")
                .WithRationale("REST is widely understood and supported by client tools and frameworks"))
            .WithAssumption(a => a
                .WithId("AS-JSON-1")
                .WithDescription("JSON is the primary content type for request and response bodies")
                .WithRationale("JSON is standard for web APIs and has excellent tooling support"))
            .WithAssumption(a => a
                .WithId("AS-STATELESS-1")
                .WithDescription("API is stateless; no server-side session state")
                .WithRationale("Stateless design enables horizontal scaling and simplified deployment"))

            .WithGlossaryTerm(g => g
                .WithTerm("REST API")
                .WithDefinition("Representational State Transfer API - architectural style using HTTP methods (GET, POST, PUT, DELETE) on resources identified by URLs"))
            .WithGlossaryTerm(g => g
                .WithTerm("JWT (JSON Web Token)")
                .WithDefinition("Compact, self-contained token format for securely transmitting information between parties as a JSON object, commonly used for authentication"))
            .WithGlossaryTerm(g => g
                .WithTerm("DTO (Data Transfer Object)")
                .WithDefinition("Object that carries data between processes, specifically designed for API contracts and decoupled from domain models"))
            .WithGlossaryTerm(g => g
                .WithTerm("Repository Pattern")
                .WithDefinition("Design pattern that abstracts data access logic, providing a collection-like interface for accessing domain objects"))
            .WithGlossaryTerm(g => g
                .WithTerm("Dependency Injection")
                .WithDefinition("Design pattern where dependencies are provided to a class rather than created by the class, enabling loose coupling and testability"))
            .WithGlossaryTerm(g => g
                .WithTerm("Middleware")
                .WithDefinition("Software component in the request pipeline that can process HTTP requests and responses, enabling cross-cutting concerns like authentication, logging, error handling"))
            .WithGlossaryTerm(g => g
                .WithTerm("OpenAPI/Swagger")
                .WithDefinition("Specification and tools for describing REST APIs, enabling interactive documentation and client code generation"))
            .WithGlossaryTerm(g => g
                .WithTerm("Entity Framework Core")
                .WithDefinition("Object-Relational Mapper (ORM) for .NET, enabling developers to work with databases using .NET objects and LINQ queries"))
            .WithGlossaryTerm(g => g
                .WithTerm("FluentValidation")
                .WithDefinition("Popular .NET library for building strongly-typed validation rules in a fluent interface style"))
            .WithGlossaryTerm(g => g
                .WithTerm("CORS (Cross-Origin Resource Sharing)")
                .WithDefinition("Security feature that allows or restricts web applications running at one origin to access resources from a different origin"))
            .WithGlossaryTerm(g => g
                .WithTerm("HSTS (HTTP Strict Transport Security)")
                .WithDefinition("Security policy mechanism that protects against protocol downgrade attacks and cookie hijacking by forcing HTTPS"))
            .WithGlossaryTerm(g => g
                .WithTerm("Health Check")
                .WithDefinition("Endpoint that reports the health status of an application and its dependencies, used by load balancers and monitoring systems"))

            .WithCommand(c => c
                .WithName("create-api")
                .WithDescription("Create a new .NET Core Web API project with standard structure")
                .WithExample("dotnet new webapi -n MyApi --use-controllers"))
            .WithCommand(c => c
                .WithName("add-entity")
                .WithDescription("Add a new entity class to the Domain layer")
                .WithExample("Create Product.cs in Domain/Entities with properties and navigation properties"))
            .WithCommand(c => c
                .WithName("add-migration")
                .WithDescription("Create a new EF Core migration for database schema changes")
                .WithExample("dotnet ef migrations add AddProductTable"))
            .WithCommand(c => c
                .WithName("add-controller")
                .WithDescription("Add a new API controller with CRUD operations")
                .WithExample("Create ProductsController.cs with GET, POST, PUT, DELETE endpoints"))
            .WithCommand(c => c
                .WithName("add-validation")
                .WithDescription("Add FluentValidation rules for a DTO")
                .WithExample("Create ProductDtoValidator : AbstractValidator<ProductDto>"))
            .WithCommand(c => c
                .WithName("run-tests")
                .WithDescription("Execute unit and integration tests")
                .WithExample("dotnet test"))
            .WithCommand(c => c
                .WithName("generate-swagger")
                .WithDescription("Generate OpenAPI specification from API controllers")
                .WithExample("Access /swagger endpoint in development mode"))

            .WithStep(s => s
                .WithTitle("Initialize API Project Structure")
                .WithDescription("Create the .NET Core Web API project and establish the layered architecture with proper folder structure.")
                .WithExpectedOutcome("Solution with API, Domain, Application, and Infrastructure projects properly configured.")
                .WithMustConstraint(m => m
                    .WithId("STEP1-MUST-1")
                    .WithText("Use 'dotnet new webapi' template with controllers (not minimal APIs for complex scenarios)")
                    .WithRationale("Controllers provide better structure for complex APIs with many endpoints"))
                .WithMustConstraint(m => m
                    .WithId("STEP1-MUST-2")
                    .WithText("Create projects: MyApi.Api (controllers), MyApi.Domain (entities), MyApi.Application (services), MyApi.Infrastructure (repositories)")
                    .WithRationale("Clear project separation enforces architectural boundaries and enables independent testing")))
            .WithStep(s => s
                .WithTitle("Configure Program.cs and Dependency Injection")
                .WithDescription("Set up the application startup with service registrations, middleware pipeline, and cross-cutting concerns.")
                .WithExpectedOutcome("Program.cs configured with all necessary services, middleware, and proper order of operations.")
                .WithMustConstraint(m => m
                    .WithId("STEP2-MUST-1")
                    .WithText("Use minimal hosting model with WebApplication.CreateBuilder()")
                    .WithRationale("Minimal hosting model is the modern, recommended approach for .NET 6+"))
                .WithMustConstraint(m => m
                    .WithId("STEP2-MUST-2")
                    .WithText("Register services with appropriate lifetime: Singleton (stateless), Scoped (per-request), Transient (per-use)")
                    .WithRationale("Correct lifetime prevents memory leaks and ensures proper disposal")))
            .WithStep(s => s
                .WithTitle("Define Domain Models and Entities")
                .WithDescription("Create domain entities representing the core business concepts with proper OOP principles.")
                .WithExpectedOutcome("Domain entities with properties, navigation properties, and business logic methods.")
                .WithMustConstraint(m => m
                    .WithId("STEP3-MUST-1")
                    .WithText("Use singular nouns for entity names (Product, Order, Customer)")
                    .WithRationale("Singular names represent individual domain concepts clearly"))
                .WithMustConstraint(m => m
                    .WithId("STEP3-MUST-2")
                    .WithText("Include Id property (int or Guid) as primary key for each entity")
                    .WithRationale("Primary keys are required for EF Core and enable entity identification")))
            .WithStep(s => s
                .WithTitle("Configure Entity Framework Core and DbContext")
                .WithDescription("Set up EF Core with DbContext, entity configurations, and database connection.")
                .WithExpectedOutcome("DbContext configured with entity mappings, connection string from configuration, and ready for migrations.")
                .WithMustConstraint(m => m
                    .WithId("STEP4-MUST-1")
                    .WithText("Create ApplicationDbContext inheriting from DbContext with DbSet<T> properties")
                    .WithRationale("DbContext is the entry point for EF Core database operations"))
                .WithMustConstraint(m => m
                    .WithId("STEP4-MUST-2")
                    .WithText("Use Fluent API in OnModelCreating() for entity configurations (keys, indexes, relationships)")
                    .WithRationale("Fluent API provides more control than attributes and keeps domain clean")))
            .WithStep(s => s
                .WithTitle("Implement Repository Pattern")
                .WithDescription("Create generic repository interface and implementation for data access abstraction.")
                .WithExpectedOutcome("IRepository<T> interface and Repository<T> implementation for CRUD operations.")
                .WithMustConstraint(m => m
                    .WithId("STEP5-MUST-1")
                    .WithText("Create IRepository<T> with methods: GetByIdAsync, GetAllAsync, AddAsync, UpdateAsync, DeleteAsync")
                    .WithRationale("Generic repository provides consistent data access interface"))
                .WithMustConstraint(m => m
                    .WithId("STEP5-MUST-2")
                    .WithText("All repository methods must be async returning Task<T> or Task")
                    .WithRationale("Async methods prevent blocking and improve scalability")))
            .WithStep(s => s
                .WithTitle("Create DTOs (Data Transfer Objects)")
                .WithDescription("Define request and response DTOs for API contracts, separate from domain entities.")
                .WithExpectedOutcome("DTO classes for each endpoint with appropriate properties and validation attributes.")
                .WithMustConstraint(m => m
                    .WithId("STEP6-MUST-1")
                    .WithText("Use suffixes to distinguish DTOs: CreateDto, UpdateDto, ReadDto, ListDto")
                    .WithRationale("Clear naming indicates DTO purpose and prevents confusion with entities"))
                .WithMustConstraint(m => m
                    .WithId("STEP6-MUST-2")
                    .WithText("Add Data Annotations or FluentValidation attributes for validation rules")
                    .WithRationale("Validation attributes enable automatic model validation in controllers")))
            .WithStep(s => s
                .WithTitle("Implement Service Layer")
                .WithDescription("Create service classes containing business logic, orchestrating repositories and domain operations.")
                .WithExpectedOutcome("Service interfaces and implementations with business logic, validation, and repository coordination.")
                .WithMustConstraint(m => m
                    .WithId("STEP7-MUST-1")
                    .WithText("Define IService interface for each major business concept (IProductService, IOrderService)")
                    .WithRationale("Interfaces enable dependency injection and testing"))
                .WithMustConstraint(m => m
                    .WithId("STEP7-MUST-2")
                    .WithText("Encapsulate all business rules and domain logic in service methods")
                    .WithRationale("Services are the correct place for business logic, not controllers or repositories")))
            .WithStep(s => s
                .WithTitle("Create API Controllers")
                .WithDescription("Implement controllers with CRUD endpoints following REST conventions and proper HTTP semantics.")
                .WithExpectedOutcome("Controllers with GET, POST, PUT, DELETE endpoints, proper status codes, and action filters.")
                .WithMustConstraint(m => m
                    .WithId("STEP8-MUST-1")
                    .WithText("Add [ApiController], [Route(\"api/[controller]\")] attributes to controller classes")
                    .WithRationale("ApiController enables automatic model validation and conventional routing"))
                .WithMustConstraint(m => m
                    .WithId("STEP8-MUST-2")
                    .WithText("Use correct HTTP verb attributes: [HttpGet], [HttpPost], [HttpPut], [HttpDelete]")
                    .WithRationale("HTTP verbs convey intent and enable proper REST semantics")))
            .WithStep(s => s
                .WithTitle("Implement JWT Authentication")
                .WithDescription("Configure JWT Bearer authentication with token generation and validation.")
                .WithExpectedOutcome("JWT authentication configured with login endpoint generating tokens and protected endpoints validating them.")
                .WithMustConstraint(m => m
                    .WithId("STEP9-MUST-1")
                    .WithText("Store JWT settings (secret, issuer, audience, expiration) in appsettings.json")
                    .WithRationale("Configuration-based settings enable environment-specific JWT parameters"))
                .WithMustConstraint(m => m
                    .WithId("STEP9-MUST-2")
                    .WithText("Register JWT Bearer authentication in Program.cs with AddAuthentication().AddJwtBearer()")
                    .WithRationale("Service registration enables authentication middleware")))
            .WithStep(s => s
                .WithTitle("Configure Authorization Policies")
                .WithDescription("Set up role-based and policy-based authorization for fine-grained access control.")
                .WithExpectedOutcome("Authorization policies defined and applied to endpoints based on roles and claims.")
                .WithMustConstraint(m => m
                    .WithId("STEP10-MUST-1")
                    .WithText("Register authorization policies in Program.cs with AddAuthorization()")
                    .WithRationale("Policy registration enables declarative authorization"))
                .WithMustConstraint(m => m
                    .WithId("STEP10-MUST-2")
                    .WithText("Use [Authorize(Roles = \"Admin,Manager\")] for role-based authorization")
                    .WithRationale("Role-based authorization is simple and sufficient for basic scenarios")))
            .WithStep(s => s
                .WithTitle("Implement Input Validation")
                .WithDescription("Configure comprehensive input validation using FluentValidation or Data Annotations.")
                .WithExpectedOutcome("All DTOs have validation rules; invalid requests return 400 Bad Request with detailed error messages.")
                .WithMustConstraint(m => m
                    .WithId("STEP11-MUST-1")
                    .WithText("Install FluentValidation.AspNetCore and register validators in DI")
                    .WithRationale("FluentValidation provides powerful, testable validation rules"))
                .WithMustConstraint(m => m
                    .WithId("STEP11-MUST-2")
                    .WithText("Create AbstractValidator<T> for each DTO with RuleFor() chains")
                    .WithRationale("Validator classes encapsulate validation logic and enable reuse")))
            .WithStep(s => s
                .WithTitle("Configure Global Error Handling")
                .WithDescription("Implement global exception handling middleware for consistent error responses and security.")
                .WithExpectedOutcome("Global error handler that catches exceptions, logs them, and returns standardized error responses.")
                .WithMustConstraint(m => m
                    .WithId("STEP12-MUST-1")
                    .WithText("Create custom exception handling middleware or use app.UseExceptionHandler()")
                    .WithRationale("Centralized error handling ensures consistent error responses"))
                .WithMustConstraint(m => m
                    .WithId("STEP12-MUST-2")
                    .WithText("Return RFC 7807 ProblemDetails for errors with type, title, status, detail")
                    .WithRationale("ProblemDetails is a standard format recognized by client tools")))
            .WithStep(s => s
                .WithTitle("Configure Swagger/OpenAPI Documentation")
                .WithDescription("Set up comprehensive API documentation with Swagger UI and OpenAPI specification.")
                .WithExpectedOutcome("Interactive Swagger UI at /swagger with detailed endpoint documentation, request/response examples, and authentication support.")
                .WithMustConstraint(m => m
                    .WithId("STEP13-MUST-1")
                    .WithText("Register Swagger services with AddSwaggerGen() and detailed configuration")
                    .WithRationale("Swagger registration enables API documentation generation"))
                .WithMustConstraint(m => m
                    .WithId("STEP13-MUST-2")
                    .WithText("Enable XML documentation generation and include in Swagger with IncludeXmlComments()")
                    .WithRationale("XML comments populate Swagger with descriptions from code")))
            .WithStep(s => s
                .WithTitle("Implement Logging and Monitoring")
                .WithDescription("Configure structured logging and application insights for diagnostics and monitoring.")
                .WithExpectedOutcome("Structured logs with correlation IDs, log levels, and integration with monitoring tools.")
                .WithMustConstraint(m => m
                    .WithId("STEP14-MUST-1")
                    .WithText("Inject ILogger<T> into services and controllers for logging")
                    .WithRationale("ILogger enables consistent, framework-integrated logging"))
                .WithMustConstraint(m => m
                    .WithId("STEP14-MUST-2")
                    .WithText("Use appropriate log levels: Trace, Debug, Information, Warning, Error, Critical")
                    .WithRationale("Proper log levels enable filtering and alerting")))
            .WithStep(s => s
                .WithTitle("Configure CORS and Security Headers")
                .WithDescription("Set up Cross-Origin Resource Sharing and security headers for production security.")
                .WithExpectedOutcome("CORS policies configured for allowed origins; security headers (HSTS, CSP, X-Frame-Options) configured.")
                .WithMustConstraint(m => m
                    .WithId("STEP15-MUST-1")
                    .WithText("Define named CORS policies with AddCors() specifying allowed origins, methods, headers")
                    .WithRationale("Explicit CORS policies prevent unauthorized cross-origin access"))
                .WithMustConstraint(m => m
                    .WithId("STEP15-MUST-2")
                    .WithText("Use different CORS policies for Development (AllowAny) and Production (specific origins)")
                    .WithRationale("Loose CORS in development, restrictive in production")))
            .WithStep(s => s
                .WithTitle("Implement Health Checks")
                .WithDescription("Configure health check endpoints for liveness and readiness probes.")
                .WithExpectedOutcome("Health check endpoints at /health with status of application and dependencies.")
                .WithMustConstraint(m => m
                    .WithId("STEP16-MUST-1")
                    .WithText("Register health checks with AddHealthChecks() in Program.cs")
                    .WithRationale("Health check registration enables monitoring infrastructure integration"))
                .WithMustConstraint(m => m
                    .WithId("STEP16-MUST-2")
                    .WithText("Add database health check with AddDbContextCheck<TContext>()")
                    .WithRationale("Database health is critical for API operation")))
            .WithStep(s => s
                .WithTitle("Write Unit and Integration Tests")
                .WithDescription("Create comprehensive test suite covering business logic, controllers, and integration scenarios.")
                .WithExpectedOutcome("Test projects with unit tests for services, integration tests for controllers, and repository tests.")
                .WithMustConstraint(m => m
                    .WithId("STEP17-MUST-1")
                    .WithText("Create separate test projects: MyApi.UnitTests, MyApi.IntegrationTests")
                    .WithRationale("Separate projects enable running different test types independently"))
                .WithMustConstraint(m => m
                    .WithId("STEP17-MUST-2")
                    .WithText("Write unit tests for services using mocked repositories (Moq, NSubstitute)")
                    .WithRationale("Unit tests validate business logic in isolation")))
            .WithStep(s => s
                .WithTitle("Configure Production Settings")
                .WithDescription("Prepare the API for production deployment with environment-specific configuration.")
                .WithExpectedOutcome("Production-ready configuration with secrets management, environment variables, and deployment settings.")
                .WithMustConstraint(m => m
                    .WithId("STEP18-MUST-1")
                    .WithText("Create appsettings.Development.json and appsettings.Production.json for environment-specific settings")
                    .WithRationale("Environment-specific files enable configuration overrides"))
                .WithMustConstraint(m => m
                    .WithId("STEP18-MUST-2")
                    .WithText("Use User Secrets for local development with 'dotnet user-secrets set'")
                    .WithRationale("User secrets prevent committing sensitive data")))

            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];
        return await context.Success();
    }
}
