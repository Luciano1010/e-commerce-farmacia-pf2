
using e_commerce_farmacia_pf2.Data;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_farmacia_pf2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


           
            // Conex�o com o banco de Dados
            var connecetionString = builder.Configuration
               .GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connecetionString));




            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();




            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "My policy",
                    policy =>
                    {
                        policy.AllowAnyOrigin() // receber as requisi��es do front
                              .AllowAnyMethod() // receber os pots,get e delete
                              .AllowAnyHeader(); // para receber o token

                    });

            }); ;



            var app = builder.Build();



            using (var scope = app.Services.CreateAsyncScope()) // CreateasyScope cria o banco de dados e as tabelas e consulta os contextos
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Mypolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}