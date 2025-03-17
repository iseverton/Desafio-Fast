## Configuração do Backend

### Requisitos

- **.NET SDK 9.0 ou superior**
- **SQL Server** (ou uma instância local do SQL Server)
- **Visual Studio** (opcional, mas recomendado para desenvolvimento)

### Passos para Configuração

1. **Clone o Repositório:**

   ```bash
   git clone https://github.com/iseverton/Desafio-Fast.git
   cd Desafio-Fast
 ### Configuração e Execução (com Visual Studio)
 Abra a solução no Visual Studio:

1. Localize e abra o arquivo Ambev.DeveloperEvaluation.sln
2. Configurar a String de Conexão do Banco de Dados:
    - No arquivo appsettings.json, configure a string de conexão para o seu servidor SQL Server.
        ```bash
          {
      "ConnectionStrings": {
            "DefaultConnection": "Server=SEU_SERVIDOR;Database=fast_workshop_manage;TrustServerCertificate=True;Integrated Security=True;"
      }

4. Instalar o dotnet-ef (Entity Framework Core CLI):
   - Se ainda não tiver instalado, execute o seguinte comando para instalar a ferramenta globalmente:
      ```bash
      dotnet tool install --global dotnet-ef
5. Aplicar as Migrações e Atualizar o Banco de Dados:
  -  Execute o seguinte comando para aplicar as migrações e atualizar o banco de dados:
      ```bash
     dotnet ef database update
Executar o Projeto Backend:

6. Clique no botão de execução (▶️) no Visual Studio ou execute o seguinte comando no terminal:
      ```bash
     dotnet run
## Acessar a Documentação do Swagger:
  Abra o navegador e acesse: https://localhost:7289/swagger/index.html
## FrontEnd
### Configuração e Execução (com Visual Studio Code)
1. Pelo Visual Studio Code, entre no diretório:

   ```bash
   cd Desafio-Fast/FrontEnd
2. Baixe a Extensão Live Server do Visual Studio Code e execute
