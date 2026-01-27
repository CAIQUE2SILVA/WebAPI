# WebAPI – Projeto ASP.NET 8

![.NET](https://img.shields.io/badge/.NET-8.0-blue) ![C#](https://img.shields.io/badge/C%23-Latest-green) ![License](https://img.shields.io/badge/license-MIT-blue.svg)

API REST desenvolvida em **ASP.NET 8** com o objetivo de estudar e praticar a criação de serviços modernos, boas práticas de organização de código e consumo de métodos HTTP no back-end em C#.

## 🎯 Objetivo do projeto

- Praticar criação de APIs REST com **ASP.NET 8**
- Explorar métodos HTTP (GET, POST, PUT, DELETE)
- Organizar a solução em camadas de forma simples e didtica
- Implementar boas práticas de desenvolvimento
- Servir como base para futuros estudos (Clean Architecture, autenticação, etc.)

## 🛠️ Tecnologias utilizadas

- **ASP.NET 8 Web API**
- **C# 12**
- **.NET SDK 8**
- **Swagger / OpenAPI** (para documentação e teste dos endpoints)
- **Git** para controle de versão

## 🚀 Como executar o projeto

### Pré-requisitos

- .NET SDK 8 instalado (verifique com: `dotnet --version`)
- Git instalado (opcional, para clonar o repositório)
- Um editor como **VS Code**, **Visual Studio** ou similar

### Passos

1. **Clonar o repositório:**
   ```bash
   git clone https://github.com/CAIQUE2SILVA/WebAPI.git
   cd WebAPI
   ```

2. **Restaurar dependências:**
   ```bash
   dotnet restore
   ```

3. **Compilar o projeto:**
   ```bash
   dotnet build
   ```

4. **Executar a aplicação:**
   ```bash
   dotnet run
   ```

5. **Acessar o Swagger:**
   - `https://localhost:5001/swagger` ou
   - `http://localhost:5000/swagger`

> Dependendo de sua configuração LaunchSettings, a porta pode variar.

## 📄 Endpoints principais

Exemplos de estrutura de endpoints (ajuste conforme suas controllers):

| Método | Endpoint | Descrição |
|--------|----------|-------------|
| **GET** | `/api/values` | Retorna lista de valores |
| **GET** | `/api/values/{id}` | Retorna um valor pelo ID |
| **POST** | `/api/values` | Cria um novo registro |
| **PUT** | `/api/values/{id}` | Atualiza um registro |
| **DELETE** | `/api/values/{id}` | Remove um registro |

## 💾 Estrutura do projeto

```
WebAPI/
 ├── Controllers/
 │    └── ValuesController.cs
 ├── Program.cs
 ├── appsettings.json
 ├── appsettings.Development.json
 ├── .gitignore
 └── WebAPI.csproj
```

- **Controllers** – Onde ficam os endpoints da API
- **Program.cs** – Configuração principal da aplicação
- **appsettings.json** – Configurações da aplicação

## ✅ Próximos passos / Melhorias

- [ ] Implementar camada de serviços e repositórios
- [ ] Integração com banco de dados (SQL Server, PostgreSQL, SQLite)
- [ ] Validação de entrada com FluentValidation
- [ ] Autenticação/Autorização com JWT
- [ ] Testes unitários com xUnit
- [ ] CI/CD com GitHub Actions
- [ ] Docker para containerização
- [ ] Logging e Monitoring

## 🤝 Contribuindo

Este é um projeto pessoal de estudos. Sinta-se livre para:

- Clonar o repositório
- Estudar o código
- Fazer melhorias e adaptações
- Sugerir contribuições via Pull Requests

## 📄 Licença

Este projeto está sob a licença **MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

## 📧 Contato

- **GitHub:** [@CAIQUE2SILVA](https://github.com/CAIQUE2SILVA)
- **LinkedIn:** [Seu LinkedIn]

---

**Desenvolvido com ❤️ por Caique Silva**

## 🔄 Sincronização com Banco de Dados

O projeto agora conta com sincronização completa com banco de dados, permitindo:

- **Persistência de dados**: Armazenamento seguro de informações em banco de dados SQL
- **Operações CRUD**: Create, Read, Update e Delete totalmente funciais
- **Entity Framework**: Utilizando EF Core para ORM (Object-Relational Mapping)
- **Migrations**: Controle de versão do esquema do banco de dados
- **Connection String**: Configuração flexível de conexão com diferentes SGBDs

### Configuração do Banco de Dados

Para configurar o banco de dados em seu ambiente, edite o arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=WebAPI;User Id=seu_usuario;Password=sua_senha;"
  }
}
```

### Executar Migrations

Para aplicar as migrations e criar/atualizar o esquema do banco:

```bash
dotnet ef database update
```
