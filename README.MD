# 📝 CrudProduct

&#x20;

O **CrudProduct** é uma solução para o gerenciamento de produtos, composta por três projetos principais:

- **CrudProduct**: API principal responsável pelo backend.
- **CrudProduct.Test**: Projeto de testes unitários.
- **CrudProductInterface**: Interface Blazor para interação com a API.

---

## 🚀 Como usar

### 1️⃣ Clonar o repositório

```bash
  git clone https://github.com/leonardo-27-dev/Crud-Product-Test.git
  cd Crud-Product-Test
```

### 2️⃣ Executando o Projeto

1. Navegue até o diretório do projeto:

```bash
  cd CrudProduct
```

2. Aplique as migrações:

```bash
  dotnet ef database update
```

3. Execute o projeto:

```bash
  dotnet run
```

### 3️⃣ Rodando os Testes Unitários

1. Navegue até o diretório do projeto de testes:

```bash
  cd CrudProduct.Test
```

2. Execute os testes:

```bash
  dotnet test
```

### 4️⃣ Rodando a Interface

1. Navegue até o diretório da interface:

```bash
  cd CrudProductInterface
```

2. Execute o projeto:

```bash
  dotnet run
```

---

## 📁 Estrutura do Projeto

```
📦 Crud-Product-Test
 ┣ 📂 CrudProduct          # API Backend
 ┃ ┣ 📂 Controllers        # Controladores das requisições HTTP
 ┃ ┣ 📂 Data               # Configuração do banco de dados
 ┃ ┣ 📂 Migrations         # Arquivos de migração do banco
 ┃ ┣ 📂 Models            # Classes de entidades do domínio
 ┃ ┣ 📂 Repositories      # Camada de acesso a dados
 ┃ ┣ 📂 Services          # Regras de negócio e processamento
 ┃ ┣ 📂 Validations       # Classes para validação de dados
 ┃ ┣ 📜 appsettings.json  # Arquivo de configurações do sistema
 ┃ ┣ 📜 Dockerfile        # Arquivo de configuração para containerização
 ┃ ┗ 📜 Program.cs        # Ponto de entrada da aplicação
 ┣ 📂 CrudProduct.Test     # Projeto de Testes Unitários
 ┃ ┗ 📜 ProductValidatorTest.cs # Testes das regras de negócio
 ┣ 📂 CrudProductInterface # Interface Blazor
 ┃ ┣ 📂 Pages             # Páginas da aplicação Blazor
 ┃ ┣ 📂 wwwroot           # Arquivos estáticos como CSS e JS
 ┃ ┣ 📜 appsettings.json  # Configurações da interface
 ┃ ┣ 📜 Dockerfile        # Configuração para containerização
 ┃ ┗ 📜 Program.cs        # Ponto de entrada da interface Blazor
 ┣ 📜 docker-compose.fullstack.yml # Configuração do Docker Compose
 ┗ 📜 README.md           # Documentação do projeto
```

---

## 🛠️ Tecnologias Utilizadas

- 🌐 **.NET 8.0** - Framework principal para API e interface Blazor.
- 🗄️ **Entity Framework Core** - ORM para interação com o banco de dados.
- 🗃️ **SQLite** - Banco de dados leve para armazenamento local.
- 💻 **Blazor** - Framework para desenvolvimento da interface.
- 🧪 **xUnit** - Framework de testes unitários.
- 🐳 **Docker** - Containerização para facilitar o deploy.
- 🛠️ **Docker Compose** - Gerenciamento dos containers.

---

## 🔥 Uso com Docker

Você pode rodar o projeto de forma completa utilizando Docker Compose:

```bash
  docker-compose -f docker-compose.fullstack.yml up --build
```

Esse comando irá:

1. Construir as imagens dos projetos.
2. Rodar as migrações automaticamente.
3. Inicializar o banco de dados SQLite.
4. Iniciar os containers da API e da interface Blazor.

### 📡 Acessando a Aplicação

- **API** disponível em: [http://localhost:8000](http://localhost:8000)
- **Interface Blazor** disponível em: [http://localhost:8001](http://localhost:8001)

---

## 📌 Observações

- Certifique-se de ter o **.NET 8.0 SDK**, **Docker** e **Docker Compose** instalados.
- A API e a interface Blazor precisam estar rodando simultaneamente para um funcionamento completo.
- As migrações do banco serão aplicadas automaticamente ao iniciar os containers.

---

## 📜 Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo `LICENSE` para mais detalhes.

---

💡 **Contribuições são bem-vindas!** Se encontrar algum problema ou quiser sugerir melhorias, fique à vontade para abrir uma issue ou pull request.

✨ *Happy coding!* 🚀

