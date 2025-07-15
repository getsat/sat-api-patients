var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

List<Patient> patients = new List<Patient>();

app.MapPost("/patients", (Patient patient) =>
{
    patients.Add(patient);
    return Results.Created($"/patients/{patient.Id}", patient);
});

app.MapGet("/patients", () => patients);

app.Run();

record Patient(int Id, string Nom, string Prenom, string DateNaissance);