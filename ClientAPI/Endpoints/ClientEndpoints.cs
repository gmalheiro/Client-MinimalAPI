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

        }
    }
}
