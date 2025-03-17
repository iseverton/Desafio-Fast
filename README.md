


# Como executar o projeto

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

1. Localize e abra o arquivo: **FastSolucoesWorkshopManager.sln**
2. Configurar a String de Conexão do Banco de Dados:
    - No arquivo **appsettings.json**, configure a string de conexão para o seu servidor SQL Server.
        ```bash
          {
      "ConnectionStrings": {
            "DefaultConnection": "Server=SEU_SERVIDOR;Database=fast_workshop_manage;TrustServerCertificate=True;Integrated Security=True;"
      }
   Atenção: Dependendo da configuração do seu SQL Server, a string de conexão pode variar. Certifique-se de substituir SEU_SERVIDOR pelo nome do seu servidor e ajustar outros parâmetros,       como autenticação (Integrated Security ou User ID e Password), conforme necessário.

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
  Abra o navegador e acesse: http://localhost:5124/swagger/index.html  ou https://localhost:7289/swagger/index.html
## FrontEnd
### Configuração e Execução (com Visual Studio Code)
1. Pelo Visual Studio Code, entre no diretório:

   ```bash
   cd Desafio-Fast/FrontEnd
2. Baixe a Extensão Live Server do Visual Studio Code e execute


## 🛠 Tecnologias Utilizadas no Backend
- **Entity Framework Core** -  ORM para mapeamento objeto-relacional.
-  **SQL Server** - Banco de dados utilizado para armazenamento de dados.
- **AutoMapper** - Biblioteca para mapeamento de objetos.
- **Fluent API** - Modelagem e relacionamentos de banco de dados.
- **FluentValidation** - Validação de modelo.
- **Swagger** - Documentação da Api.
- **JWT Authentication** - Autenticação via JWT (JSON Web Tokens).


🛠 Tecnologias Utilizadas no FrontEnd
- **HTML** 
- **Css** 
- **Javascript** 



