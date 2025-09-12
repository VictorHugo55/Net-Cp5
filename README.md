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
### Configure a string de coexão no arquivo appsettings.json:
  ```json
    "ConnectionStrings": {
    "MotoGridDB":"server=localhost;port=3306;database=MotoGridDB;user=root;password=SuaSenhaSegura;"
    }
  ```

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

## 👥 Integrantes

- **Gabriel Gomes Mancera** - RM: 555427  
- **Juliana de Andrade Sousa** - RM: 558834  
- **Victor Hugo Carvalho Pereira** - RM: 558550  

---

## 📌 Observações
- Este projeto é voltado para execução **local**.  
  
