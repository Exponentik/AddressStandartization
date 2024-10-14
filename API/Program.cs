using AddressStandartization.Services.Settings;
using AddressStandartization.Services.DadataService.DTO;
using AddressStandartization.Api.Configuration;
using AddressStandartization.Api;
using AddressStandartization.Settings;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var dadataSettings = Settings.Load<DadataSettings>("DadataSettings");


var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);

builder.Services.AddSingleton(dadataSettings);

builder.Services.AddAppCors();

builder.Services.RegisterAppServices();

builder.Services.AddControllers();

builder.Services.AddAppHealthChecks();

builder.Services.AddAutoMapper(typeof(AddressProfile));


var app = builder.Build();

app.UseAppCors();

app.MapControllers();

app.UseAppHealthChecks();

app.Run();