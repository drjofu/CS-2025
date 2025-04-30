using System.Net.Http.Json;
using WebApiBeispiel;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7100/personen/");

var data = await client.GetFromJsonAsync<Person>("Petra");

var alle = await client.GetFromJsonAsync<Person[]>("");


Console.ReadLine();