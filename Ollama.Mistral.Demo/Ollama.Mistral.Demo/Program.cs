namespace Ollama.Mistral.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // B — Typed client
            //builder.Services.AddHttpClient<MistralController>(client =>
            //{
            //    client.BaseAddress = new Uri("http://localhost:11434/");
            //});

            // A — Named client (Register for Ollama model server)
            builder.Services.AddHttpClient("ollama", client =>
            {
                client.BaseAddress = new Uri("http://localhost:11434/");
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AuthPolicy", builder => builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseCors("AuthPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
