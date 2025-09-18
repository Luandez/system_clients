# Sistema de Clientes em C#  

Este é um **sistema simples de gerenciamento de clientes** feito em C# usando **Console App** e **SQLite** com **Entity Framework Core**.  
O projeto permite cadastrar, listar, editar e excluir clientes em um banco de dados local.

---

## Funcionalidades

- Cadastrar novos clientes (nome, email e telefone)  
- Listar todos os clientes cadastrados  
- Editar clientes existentes  
- Excluir clientes  
- Banco de dados SQLite (`clientes.db`)  

---

## Tecnologias utilizadas

- C# (.NET 7 ou superior)  
- SQLite (banco de dados local)  
- Entity Framework Core (ORM)  
- Console App  

---

## Como rodar o projeto

1. Clone este repositório:
```bash
git clone https://github.com/seuusuario/SistemaClientes.git
```

2. Entre na pasta do projeto:
```bash
cd SistemaClientes
```

3. Instale os pacotes do Entity Framework Core (se necessario):
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

4. Execute o programa:
```bash
dotnet run
```

5. Menu que cadastra, lista, edita e exclui clientes:
```bash
SistemaClientes/
│
├─ Program.cs          # Menu principal e lógica CRUD
├─ Cliente.cs          # Classe Cliente
├─ AppDbContext.cs     # Configuração do EF Core
├─ clientes.db         # Banco de dados SQLite (criado automaticamente)
└─ README.md
```

Feito com ❤️ por Luan de Souza.
