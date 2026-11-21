
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Todo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                                {
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Secret").Value)),
                                    ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                                    ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                                    ValidateAudience = true,
                                    ValidateIssuer = true,
                                    ClockSkew = TimeSpan.FromSeconds(10)
                                };
                                    
                                    
                            });

            builder.Services.AddInfrastructure(builder.Configuration);


            builder.Services.AddApplication();

            builder.Services.AddOpenApi();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDistributedMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
