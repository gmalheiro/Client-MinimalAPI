using ClientAPI.Context;
using ClientAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Endpoints
{
    public static class ClientEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/GetAllClients", async (AppDbContext db) =>
            {
                var clients =  await db?.Clients?.ToListAsync()!;

                if (clients is null)
                    return Results.NotFound("Clients not found");

                return Results.Ok(clients);

            } );

            app.MapGet("/GetClientById/{id:int}", async (int id,AppDbContext db) =>
            {
                var client = await db.Clients!.FindAsync(id);

                if (client is null)
                    return Results.NotFound("Client not found");

                return Results.Ok(client);

            });

            app.MapPost("/RegisterClient", async (Client client, AppDbContext db) =>
            {
                if (client is null)
                    return Results.BadRequest("Client is null");

                db.Clients?.AddAsync(client);
                await db?.SaveChangesAsync()!;
                return Results.Created($"/GetClientById/{client.Id}", client);

            });

            app.MapPut("/EditClient/{id:int}", async (Client client,int id,AppDbContext db) =>
            {
                if (client.Id != id)
                    return Results.NotFound("Client not found");

                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync()!;
                return Results.Ok(client);
            });

            app.MapDelete("/DeleteClient/{id:int}", async (int id, AppDbContext db) =>
            {
                var client = await db.Clients!.FindAsync(id);

                if (client is null)
                    return Results.NotFound("Client not found");

                db.Remove(client);
                await db.SaveChangesAsync();

                return Results.Ok(client);

            });


            app.MapPost("/CreateTenClients", async (AppDbContext db) =>
            {
                for (int i = 0; i <= 9; i++)
                {
                   string name =  await new HttpClient().GetStringAsync("https://gerador-nomes.wolan.net/nome");
                   string description = await new HttpClient().GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes");
                   Client client = new Client(name, description);
                    db.Clients?.AddAsync(client);
                }
                await db.SaveChangesAsync();
            });

        }
    }
}
