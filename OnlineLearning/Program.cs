﻿using Microsoft.EntityFrameworkCore;
using OnlineLearning.AutoMapper;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;
using OnlineLearning.Services;

namespace OnlineLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OnlineLearningContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
            builder.Services.AddTransient<IQuizRepository, QuizRepository>();


            // khi dùng DI ở các class thì phải thêm file config (program.cs)
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<CourseService>();
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
        }
    }
}