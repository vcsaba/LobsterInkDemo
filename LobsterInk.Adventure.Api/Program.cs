using AutoMapper;
using LobsterInk.Adventure.Api.Extensions;
using LobsterInk.Adventure.Business.Mapper;
using LobsterInk.Adventure.Data.Database;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using LobsterInk.Adventure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configs = new Dictionary<string, string>
{
    { LobsterInk.Adventure.Shared.Constants.Configurations.StorageTypeKey, StorageType.ParentAssociation.ToString() }
};
var configuration = new ConfigurationBuilder().AddInMemoryCollection(configs).Build();
builder.Configuration.AddConfiguration(configuration);
builder.Services.AddSingleton(provider =>
new MapperConfiguration(c =>
{
    c.AddProfile(new ParentAssociationNodeProfile());
    c.AddProfile(new MaterializedPathNodeProfile());
    c.AddProfile(new NestedSetProfile());
    c.AddProfile(new AdventureEntityProfile());
    c.AddProfile(new GameEntityProfile());
    c.AddProfile(new GameStepEntityProfile());
})
.CreateMapper());

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
    });
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddLogging();
builder.Services.AddBusinessServices();
//builder.Services.AddDbContext<ParentAssociationContext>(opts => opts.UseSqlServer("$Data Source=sql-service,1433;Initial Catalog=LobsterInk;Persist Security Info=True;User ID=sa;Password=@Passw0rd"), ServiceLifetime.Transient, ServiceLifetime.Transient);
builder.Services.AddDbContext<LobsterInkContext>(opts => opts.UseSqlServer(@$"Data Source=LAPTOP-V8DIRJ4T\SQLEXPRESS;Initial Catalog=LobsterInk;Integrated Security=True"), ServiceLifetime.Transient, ServiceLifetime.Transient);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
