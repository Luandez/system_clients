using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated(); // cria o banco se não existir
        }

        int opcao = 0;
        while (opcao != 5)
        {
            Console.WriteLine("\n=== SISTEMA DE CLIENTES ===");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Editar Cliente");
            Console.WriteLine("4 - Excluir Cliente");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: Cadastrar(); break;
                case 2: Listar(); break;
                case 3: Editar(); break;
                case 4: Excluir(); break;
            }
        }
    }

    static void Cadastrar()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        using (var db = new AppDbContext())
        {
            var cliente = new Cliente { Nome = nome, Email = email, Telefone = telefone };
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }
        Console.WriteLine("✅ Cliente cadastrado com sucesso!");
    }

    static void Listar()
    {
        using (var db = new AppDbContext())
        {
            var clientes = db.Clientes.ToList();
            Console.WriteLine("\n--- Lista de Clientes ---");
            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.Id} - {c.Nome} ({c.Email}) - {c.Telefone}");
            }
        }
    }

    static void Editar()
    {
        Console.Write("Digite o ID do cliente que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        using (var db = new AppDbContext())
        {
            var cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                Console.WriteLine("⚠ Cliente não encontrado!");
                return;
            }

            Console.Write("Novo nome (deixe vazio para manter): ");
            string nome = Console.ReadLine();
            Console.Write("Novo email (deixe vazio para manter): ");
            string email = Console.ReadLine();
            Console.Write("Novo telefone (deixe vazio para manter): ");
            string telefone = Console.ReadLine();

            if (!string.IsNullOrEmpty(nome)) cliente.Nome = nome;
            if (!string.IsNullOrEmpty(email)) cliente.Email = email;
            if (!string.IsNullOrEmpty(telefone)) cliente.Telefone = telefone;

            db.SaveChanges();
        }
        Console.WriteLine("✅ Cliente atualizado com sucesso!");
    }

    static void Excluir()
    {
        Console.Write("Digite o ID do cliente que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        using (var db = new AppDbContext())
        {
            var cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                Console.WriteLine("⚠ Cliente não encontrado!");
                return;
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();
        }
        Console.WriteLine("✅ Cliente excluído com sucesso!");
    }
}