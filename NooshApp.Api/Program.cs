using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using NooshApp.Api.Data;
using NooshApp.Api.Repositories;
using NooshApp.Api.Repositories.Interfaces;
using NooshApp.Api.Services;
using NooshApp.Api.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ICateringRepository, CateringRepository>();
builder.Services.AddScoped<ICateringService, CateringService>();
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
builder.Services.AddScoped<ICareersService, CareersService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRewardRuleRepository, RewardRuleRepository>();
builder.Services.AddScoped<IPointsRepository, PointsRepository>();
builder.Services.AddScoped<IScanTokenRepository, ScanTokenRepository>();
builder.Services.AddScoped<IReceiptSubmissionRepository, ReceiptSubmissionRepository>();
builder.Services.AddScoped<IAppSettingsRepository, AppSettingsRepository>();
builder.Services.AddScoped<IRewardsService, RewardsService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<NooshApp.Api.Auth.FirebaseAuthFilter>();
builder.Services.AddScoped<NooshApp.Api.Auth.StaffPinFilter>();
builder.Services.AddScoped<NooshApp.Api.Auth.AdminKeyFilter>();
builder.Services.AddScoped<ISupportingDocumentRepository, SupportingDocumentRepository>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024;
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 25 * 1024 * 1024;
});

var firebaseKeyPath = builder.Configuration["Firebase:ServiceAccountPath"];
if (!string.IsNullOrEmpty(firebaseKeyPath) && File.Exists(firebaseKeyPath))
{
    FirebaseApp.Create(new AppOptions { Credential = GoogleCredential.FromFile(firebaseKeyPath) });
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("AdminKey", new OpenApiSecurityScheme
    {
        Name = "X-Admin-Key",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Enter the admin API key."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "AdminKey"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebFrontend", policy =>
        policy.WithOrigins("https://localhost:5181")  
              .AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); 
    DbSeeder.Seed(db);
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowWebFrontend");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();