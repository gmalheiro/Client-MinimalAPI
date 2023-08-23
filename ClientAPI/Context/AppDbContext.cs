﻿using ClientAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<Client>? Clients { get; set; }
    }
}
