using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TwitterCloneBackend.Context;
using TwitterCloneBackend.NewFolder;
using TwitterCloneBackend.Repositories;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddDbContext<DataContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

app.MapHub<MessagesHub>("/messagehub");

app.Run();
