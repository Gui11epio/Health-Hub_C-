# Health Hub

### 👥 Nome e RM dos Integrantes

- Guilherme Camasmie Laiber de Jesus – RM554894

- Fernando Fernandes Prado – RM557982

- Pedro Manzo Yokoo – RM556115

### 📌 Descrição do Projeto

O Health Hub é uma API desenvolvida em ASP.NET Core que fornece funcionalidades para acompanhamento de bem-estar, gestão de usuários, respostas de questionários, comunicação com IA e suporte corporativo à saúde mental.

### 📌 Arquitetura do Projeto

A aplicação implementa operações básicas de CRUD (Create, Read, Update, Delete), segue uma arquitetura em camadas (Controllers, Application, Domain, Infrastructure), segue os príncipios de DDD e Clean Code.

Com o objetivo de deixar a aplicação mais organizada e destribuir as responsabilidades

## 🚀 Rotas Disponíveis

### 📍 Questionario (V1)
- `GET /api/v1/QuestionarioV1`  
  Retorna todos os questionários cadastrados.

- `GET /api/v1/QuestionarioV1/{id}`  
  Retorna um questionário específico pelo id.

- `GET /api/v1/QuestionarioV1/pagina`  
  Retorna questionários por meio de páginas.

- `POST /api/v1/QuestionarioV1`  
  Cria um novo questionário. Requer um corpo com os dados do questionário.

- `DELETE /api/v1/QuestionarioV1/{id}`  
  Deleta um questionário pelo id.


### 📍 Questionario (V2)

- `GET /api/v1/QuestionarioV2/{id}`  
  Retorna um questionário específico pelo id.

- `POST /api/v1/QuestionarioV2`  
  Cria um novo questionário. Requer um corpo com os dados do questionário.

- `DELETE /api/v1/QuestionarioV2/{id}`  
  Deleta um questionário pelo id.


### 📍 Usuário (V1)

- `GET /api/v1/UsuarioV1/{id}`
Obtém um usuário por ID

- `PUT /api/v1/UsuarioV1/{id}`
Atualiza um usuário existente

- `DELETE /api/v1/UsuarioV1/{id}`
Remove um usuário

- `GET /api/v1/UsuarioV1/email/{email}`
Obtém um usuário por email

- `GET /api/v1/UsuarioV1`
Obtém todos os usuários

- `POST /api/v1/UsuarioV1`
Cria um novo usuário

- `GET /api/v1/UsuarioV1/pagina`
Obtém usuários paginados


### 📍 Usuário (V2)

- `GET /api/v1/UsuarioV2/{id}`
Obtém um usuário por ID

- `PUT /api/v1/UsuarioV2/{id}`
Atualiza um usuário existente

- `DELETE /api/v1/UsuarioV2/{id}`
Remove um usuário

- `GET /api/v1/UsuarioV2`
Obtém todos os usuários

- `POST /api/v1/UsuarioV2`
Cria um novo usuário

## 🚀 Link para o Render(deploy da API na nuvem)
```bash
https://health-hub-c.onrender.com
````

- Pode ser usada pelo Postman, apenas use o link junto com **rotas** disponíveis acima. Está sendo usado o meu Banco de Dados

## 🚀 Rota dos Health Checks
- `/health`
  Vai mostrar o estado de tudo

- `/health/ready`
  Vai mostrar o estado do Banco de Dados apenas

- `/health/live`
  Vai mostrar o estado da Aplicação apenas


## 🛠️ Tecnologias Utilizadas

- [.NET 6 / ASP.NET Core](https://dotnet.microsoft.com/)
- C#
- Entity Framework Core
- Swagger (OpenAPI) para documentação
- Visual Studio 2022
- Oracle DataBase
- AutoMapper
- Migrations
- DataAnnotations
- Pagination
- HATEOAS
- JWT
- Health Check
- xUnit
- Versionamento de API

## ▶️ Instruções de Execução

1. **Clone o repositório:**
   ```bash
   https://github.com/Gui11epio/Health-Hub_C-.git
   

2. **Vá até "lauchSettings.json"**
   
   <img width="353" height="146" alt="image" src="https://github.com/user-attachments/assets/9f93d392-ad7a-4c23-be0b-7daa7fb815e4" />

   
- Nota: Clique com o botão direito em cima de **Health-Hub.API** e defina ele como projeto de inicialização, se ainda não estiver 


3. **Coloque suas informações do Banco de Dados Oracle**

   <img width="933" height="245" alt="image" src="https://github.com/user-attachments/assets/1fb21d85-9938-443e-8a1c-34daf11e7f18" />



4. **Abra a terminal da Infrastructure e coloque as mesmas informações do Oracle**
   ```bash
   $env:DEFAULT_CONNECTION = "User Id=xxxxxxx;Password=xxxxxx;Data Source=xxxxxxxxxxxx:1521/ORCL"

5. **Na terminal da Infrastructure, rode este comando para criar as tabelas em seu banco de dados:**
   
   - Para poder criar as tabelas
   ```bash
   dotnet ef database update
   ```

7. **Após tudo isso, rode o programa e o Swagger abrirá sozinho**
   ```bash
   https://localhost:7165/swagger/index.html

8. **Para rodar os Testes unitários**

   - Vá até a camada de testes
     
   <img width="217" height="102" alt="image" src="https://github.com/user-attachments/assets/9c53e928-0838-4fd4-b4d2-23b9e6818338" />



   - Clique com o botão direito em cima da camada e clique no executar testes
     
     <img width="634" height="38" alt="image" src="https://github.com/user-attachments/assets/f2663387-c1f8-4444-8a66-91b501bb72cc" />


   - Vai ir para uma tela onde vai rodar os testes
     
     <img width="519" height="331" alt="image" src="https://github.com/user-attachments/assets/11023bc5-5672-47dd-b018-eeee364fc976" />


## 📬JSON de Teste para o Swagger

- Questionário
  
```bash
{
  "usuarioId": 1,
  "nivelEstresse": 6,
  "qualidadeSono": 4,
  "ansiedade": 5,
  "sobrecarga": 2
}
```

#

- Usuário
```bash
{
  
  "emailCorporativo": "guilherme@gmail.com",
  "nome": "Guilherme",
  "senha": "GuiTatu0203!",
  "tipo": "ADMIN"

}
```
🔤 Tipo deve conter:

- Tipo: "ADMIN" ou "FUNCIONARIO"





  



   
