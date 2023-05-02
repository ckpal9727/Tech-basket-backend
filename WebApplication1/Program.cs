using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Practice.API.DbContexts;
using Practice.API.Services;
using System.Text;
using WebApplication1.Service;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
	setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new OpenApiSecurityScheme()
	{
		Type = SecuritySchemeType.Http,
		Scheme = "Bearer",
		Description = "input valid token to access this API"
	});

	setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference= new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id="CityInfoApiBearerAuth"
				}
			},new List<string>()
		}
	});
}
);
builder.Services.AddDbContext<InfoContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Practice"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Adding Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService,CartServices>();
builder.Services.AddScoped<IOrderService, OrderService>();

//Adding Authentication token
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
	options.TokenValidationParameters = new()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Authentication:Issuer"],
		ValidAudience = builder.Configuration["Authentication:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
	};
});
builder.Services.AddCors(option =>
{
	option.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
