using System;
using Microsoft.EntityFrameworkCore;

class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=clientes.db");
}

class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }
}