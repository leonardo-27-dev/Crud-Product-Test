# Documentação do Projeto CrudProduct

## 1. Introdução
O **CrudProduct** é uma solução para o gerenciamento de produtos, composta por três projetos principais: 

- **CrudProduct**: API principal responsável pelo backend.
- **CrudProduct.Test**: Projeto de testes unitários.
- **CrudProductInterface**: Interface Blazor para interação com a API.

## 2. Estrutura do Projeto
A solução está organizada da seguinte forma:

### **CrudProduct** (API Backend)
Este projeto contém a lógica de backend e gerenciamento de dados.

- **Controllers/**: Responsável pelo tratamento das requisições HTTP.
- **Data/**: Configuração do banco de dados utilizando Entity Framework Core.
- **Migrations/**: Arquivos de migração do banco de dados.
- **Models/**: Definição das classes que representam as entidades do domínio.
- **Repositories/**: Camada de acesso a dados para interação com o banco.
- **Services/**: Contém as regras de negócio e lógica de processamento.
- **Validations/**: Classes para validação de dados.
- **appsettings.json**: Arquivo de configurações do sistema.
- **Dockerfile**: Arquivo de configuração para containerização.
- **Program.cs**: Ponto de entrada da aplicação.

### **CrudProduct.Test** (Testes Unitários)
Contém os testes unitários para validação da API.

- **ProductValidatorTest.cs**: Testes que validam as regras de negócio dos produtos.

### **CrudProductInterface** (Interface Blazor)
Interface do usuário para interagir com a API.

- **Pages/**: Páginas da aplicação Blazor.
- **wwwroot/**: Arquivos estáticos como CSS, JS e imagens.
- **appsettings.json**: Configurações específicas da interface.
- **Dockerfile**: Configuração para containerização.
- **Program.cs**: Ponto de entrada da aplicação Blazor.

## 3. Tecnologias Utilizadas
O projeto foi desenvolvido utilizando as seguintes tecnologias:

- **.NET 8.0**: Framework principal para desenvolvimento da API e interface Blazor.
- **Entity Framework Core**: ORM para interação com o banco de dados.
- **SQLite**: Banco de dados leve para armazenamento local.
- **Blazor**: Framework para desenvolvimento da interface do usuário.
- **xUnit**: Framework de testes unitários.
- **Docker**: Containerização para facilitar o deploy.
- **Docker Compose**: Gerenciamento dos containers.

## 4. Desafios Encontrados e Soluções

### **1. Gerenciamento de Dependências**
- **Problema**: Configurar a API e a interface Blazor para compartilharem as mesmas entidades e padrões de negócio.
- **Solução**: Implementamos uma camada de serviço que abstrai a lógica de negócio para reutilização entre projetos.

### **2. Integração com Banco de Dados**
- **Problema**: Definir a melhor abordagem para persistência de dados.
- **Solução**: Optamos pelo Entity Framework Core com migrações, garantindo flexibilidade na evolução do esquema do banco de dados.

### **3. Testes Unitários e Cobertura de Código**
- **Problema**: Garantir que a lógica de negócio seja testada corretamente.
- **Solução**: Implementamos testes unitários cobrindo os principais cenários da aplicação.

## 5. Uso com Docker

### Construir e Subir os Containers com Docker Compose
```bash
docker-compose -f docker-compose.fullstack.yml up --build
```

Esse comando irá:
1. Construir as imagens dos projetos.
2. Rodar as migrações automaticamente.
3. Inicializar o banco de dados SQLite.
4. Iniciar os containers da API e da interface Blazor.

### Acessando a Aplicação
- **API** disponível em: `http://localhost:8000`
- **Interface Blazor** disponível em: `http://localhost:8001`

