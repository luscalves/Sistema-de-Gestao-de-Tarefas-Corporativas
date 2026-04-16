# Sistema de Gestão de Tarefas Corporativas 🚀

Este é um projeto de estudo guiado e prático focado no desenvolvimento de uma API robusta e escalável utilizando o ecossistema **.NET e C#**. O objetivo principal é simular o núcleo de um sistema de gestão de tarefas (semelhante ao Jira/Trello), saindo do modelo tradicional de tutoriais e aplicando padrões de projeto exigidos por empresas de ponta.

## 🎯 Foco Arquitetural e Boas Práticas

O projeto está sendo construído do zero com forte ênfase em design de software, evitando o "Modelo Anêmico" e o forte acoplamento com o banco de dados. Os seguintes conceitos estão sendo aplicados:

* **Clean Architecture (Arquitetura Limpa):** Separação clara de responsabilidades entre Domínio, Aplicação e Infraestrutura.
* **Domain-Driven Design (DDD):** Entidades ricas que encapsulam suas próprias regras de negócio e validações através de *Guard Clauses*, protegendo o estado da aplicação.
* **Padrão Repository:** Abstração da camada de persistência através de interfaces, permitindo que o Domínio desconheça a tecnologia de banco de dados.
* **Injeção de Dependência:** Desacoplamento de classes (como Casos de Uso e Repositórios) para facilitar a manutenção e futuros testes unitários.
* **Data Transfer Objects (DTOs):** Mapeamento seguro de dados entre as camadas da aplicação e a interface de saída, evitando vazamento do modelo de domínio.

## 📂 Estrutura do Projeto

A solução está dividida nas seguintes camadas lógicas principais:

```text
📁 SistemaDeGestaoDeTarefas
├── 📁 Domain
│   ├── 📁 Entities
│   └── 📁 Repositories
├── 📁 Application
│   ├── 📁 UseCases
│   └── 📁 DTOs
├── 📁 Infrastructure
│   ├── 📁 Migrations
│   ├── AppDbContext.cs
│   └── TarefaPostgresRepository.cs
└── 📁 Controllers
    └── TarefaController.cs
```

## ⚙️ Funcionalidades Implementadas (API REST)

A aplicação já possui um ciclo completo de gestão de estado das entidades no banco de dados:

* `POST /api/tarefa`: Criação de novas tarefas.
* `GET /api/tarefa`: Listagem de todas as tarefas cadastradas.
* `GET /api/tarefa/{id}`: Busca detalhada de uma tarefa específica.
* `PUT /api/tarefa/{id}`: Atualização de informações da tarefa (Título/Descrição).
* `PUT /api/tarefa/{id}/concluir`: Rota dedicada para transição de estado e aplicação de regras de negócio de conclusão.
* `DELETE /api/tarefa/{id}`: Remoção de tarefas do sistema.

## 🛠️ Tecnologias e Ferramentas

* **Linguagem:** C#
* **Framework:** .NET 10
* **Banco de Dados:** PostgreSQL
* **ORM:** Entity Framework Core (Code-First Migrations)

## 👤 Autor

**Lucas Alves de Souza**
* GitHub: [luscalves](https://github.com/luscalves)
* *Estudante de Engenharia de Computação em transição para desafios no ecossistema .NET.*

testando se vai pedir senha
