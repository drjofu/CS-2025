using WebApiBeispiel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IVerwaltung, Verwaltung>();

builder.Services.AddMyServices();

//builder.Services.AddTransient<Verwaltung>();
//builder.Services.AddScoped<Verwaltung>();

var app = builder.Build();

app.MapGet("/", () => "Hallo Welt");

app.MapGet("/personen", (IVerwaltung verwaltung) =>verwaltung.GetPersonen());
app.MapGet("/personen/{name}", (IVerwaltung verwaltung, string name) => verwaltung.GetPerson(name));
app.MapGet("/personen/length/{name}", (IVerwaltung verwaltung, string name) => verwaltung.GetLength(name));
app.Run();

