# 🚀 Projeto Challenger API (.NET)

Este repositório contém a implementação de uma **API desenvolvida em .NET 8**, estruturada em camadas de acordo com princípios de **Domain-Driven Design (DDD)**.  
O projeto foi criado como parte do CP4 com objetivo de aplicar boas práticas de desenvolvimento, versionamento e arquitetura de software.

---

## 🎯 Objetivos do Projeto
- Implementar uma API REST em **.NET** com arquitetura organizada em camadas.
- Aplicar conceitos de **Domain-Driven Design (DDD) e SOLID**.
- Estruturar as camadas **Domain, Application, Infrastructure e API**.
- Permitir fácil execução local para testes e evolução da aplicação.

---

## 🛠️ Estrutura do Projeto

```
NET-MOTTU-main/
│
├── Challenger.API/            # Camada de apresentação (Controllers e Startup)
├── Challenger.Application/    # Casos de uso e regras de aplicação
├── Challenger.Domain/         # Entidades e regras de negócio
├── Challenger.Infrastructure/ # Persistência e integrações externas
│
├── Challenger.sln             # Arquivo da solução .NET
├── global.json
└── .gitignore
```

---

## ▶️ Como Rodar Localmente

### 📌 Pré-requisitos
- [.NET SDK 8+](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- Banco de dados MySql disponível

### 📥 Clonar o repositório
```bash
git clone <url-do-repo>
cd NET-MOTTU-main
```

### ⚙️ Restaurar dependências
```bash
dotnet restore
```
---
###⚙️ Configurar Banco de Dados
##🗄️ MySQL (Padrão)
## Configure a string de conexão no arquivo appsettings.json:
  ```json
    "ConnectionStrings": {
    "MotoGridDB":"server=localhost;port=3306;database=MotoGridDB;user=root;password=SuaSenhaSegura;"
    }
  ```
##🍃 MongoDB (Apenas para a entidade User)
##Para usar o MongoDB, configure o bloco no appsettings.json:
```json
  "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "MotoGridDb"
  },
```
---
### ▶️ Executar a API
```bash
cd Challenger.API
dotnet run
```

A API ficará disponível por padrão em:
```
https://localhost:5001
http://localhost:5000
```

### ✅ Testar a aplicação
Você pode testar os endpoints usando:
- [Postman](https://www.postman.com/)
- `curl` no terminal
- Navegador para os endpoints GET

### 📦 Exemplos de Requisição

## POST /api/patios
  ```json
  {
    "nome": "Pátio Centro",
    "cidade": "São Paulo",
    "capacidade": 50
  }
  ```
## GET /api/patios/cidade/São Paulo
    Retorna todos os pátios localizados na cidade de São Paulo.

---

## POST /api/motos
```json
  {
  "placa": "XYZ-1234",
  "modelo": "1, 2 ou 3 ",
  "patioId": "GUID_DO_PATIO"
}
```
## GET /api/motos/placa/XYZ1234
      Retorna os dados da moto com a placa especificada.
---

**POST /api/users**

```json
{
  "username": "DustSams",
  "email" : "victorhugo@gmail.com",
  "senha" : "Fiapm1234"
}
```
---
###🧩 Versionamento de API
- O projeto possui suporte a múltiplas versões de API, configuradas via Asp.Versioning.
- A versão padrão é v1.0
- A versão v2.0 inclui novos endpoints(Ainda sem muita modificação), como o MotoV2Controller e UserController.
##Acesso via Swagger:
```bash
  /swagger/v1/swagger.json → Versão 1
  /swagger/v2/swagger.json → Versão 2
```
## 👥 Integrantes

- **Gabriel Gomes Mancera** - RM: 555427  
- **Juliana de Andrade Sousa** - RM: 558834  
- **Victor Hugo Carvalho Pereira** - RM: 558550  

---

## 📌 Observações
O MongoDB é usado apenas na entidade User, sem impactar outras partes do sistema.

Se a conexão com o MongoDB não estiver configurada, o restante do sistema (MySQL) funcionará normalmente.

O Swagger exibirá automaticamente as versões da API (v1 e v2) detectadas. 
  
