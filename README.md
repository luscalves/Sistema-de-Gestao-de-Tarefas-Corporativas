# Sistema de Gestão de Tarefas Corporativas 🚀

Este é um projeto de estudo guiado e prático focado no desenvolvimento de uma API robusta e escalável utilizando o ecossistema **.NET e C#**. O objetivo principal é simular o núcleo de um sistema de gestão de tarefas corporativo (semelhante ao Jira/Trello), saindo do modelo tradicional de tutoriais e aplicando padrões de projeto, segurança e arquitetura exigidos por empresas de ponta.

## 🎯 Foco Arquitetural e Boas Práticas

O projeto foi construído do zero com forte ênfase em design de software, evitando o "Modelo Anêmico" e o forte acoplamento com o banco de dados. Os seguintes conceitos foram aplicados:

* **Clean Architecture (Arquitetura Limpa):** Separação clara de responsabilidades entre Domínio, Aplicação e Infraestrutura.
* **Domain-Driven Design (DDD):** Entidades ricas (`Tarefa`, `Usuario`) que encapsulam suas próprias regras de negócio e validações através de *Guard Clauses*, protegendo o estado da aplicação (ex: `tarefa.Bloquear(motivo)` ou `usuario.Desativar()`).
* **Segurança e Identidade:** Implementação de Autenticação via **JWT (JSON Web Token)** e proteção de dados sensíveis utilizando Hash criptográfico avançado com **BCrypt**.
* **Integridade Referencial e Transações:** Regras de negócio complexas aplicadas de forma atômica no banco de dados (ex: ao desativar um usuário, todas as suas tarefas "Em Andamento" retornam automaticamente para "Pendentes").
* **Padrão Repository:** Abstração da camada de persistência através de interfaces, permitindo que o Domínio desconheça a tecnologia de banco de dados.
* **Injeção de Dependência:** Desacoplamento de classes (como Casos de Uso e Repositórios) para facilitar a manutenção e testes.

## 📂 Estrutura do Projeto

A solução está dividida nas seguintes camadas lógicas principais:

```text
📁 SistemaDeGestaoDeTarefas
├── 📁 Domain
│   ├── 📁 Entities (Tarefa.cs, Usuario.cs)
│   └── 📁 Repositories (ITarefaRepository.cs, IUsuarioRepository.cs)
├── 📁 Application
│   ├── 📁 UseCases (DesativarUsuarioUseCase, FazerLoginUseCase, BloquearTarefaUseCase...)
│   └── 📁 DTOs
├── 📁 Infrastructure
│   ├── 📁 Migrations
│   ├── AppDbContext.cs
│   ├── TarefaPostgresRepository.cs
│   └── UsuarioPostgresRepository.cs
└── 📁 Controllers
    ├── AuthController.cs
    ├── TarefaController.cs
    └── UsuarioController.cs

```

## ⚙️ Funcionalidades Implementadas (API REST)

A aplicação possui um ciclo completo de gestão de estado e relacionamentos:

### 🔐 Autenticação e Usuários (`/api/auth` e `/api/usuario`)

* `POST /api/auth/login`: Autenticação de usuários com emissão de token JWT.
* `POST /api/usuario`: Cadastro de novos usuários com criptografia de senha (BCrypt).
* `GET /api/usuario`: Listagem de equipe (retornando apenas dados públicos e usuários ativos).
* `PUT /api/usuario/{id}/desativar`: Soft-delete do usuário, acionando o retorno automático de suas tarefas ativas para o *Backlog*.

### 📋 Gestão de Tarefas (`/api/tarefa`)

* `POST /api/tarefa`: Criação de novas tarefas.
* `GET /api/tarefa`: Listagem do Kanban.
* `PUT /api/tarefa/{id}`: Atualização de informações base.
* `PUT /api/tarefa/{id}/atribuir`: Associação de um usuário à tarefa (transição automática para "Em Andamento").
* `PUT /api/tarefa/{id}/bloquear`: Bloqueio da tarefa mediante justificativa obrigatória (`MotivoBloqueio`).
* `PUT /api/tarefa/{id}/concluir`: Transição de estado validada por regras de negócio.
* `DELETE /api/tarefa/{id}`: Remoção de tarefas do sistema.

## 🛠️ Tecnologias e Ferramentas

* **Linguagem:** C#
* **Framework:** .NET 10
* **Banco de Dados:** PostgreSQL
* **ORM:** Entity Framework Core (Code-First Migrations)
* **Segurança:** BCrypt.Net-Next, System.IdentityModel.Tokens.Jwt
* **Integração Front-end:** Configuração de políticas de CORS ativas para consumo via React/Vite.

## 👤 Autor

**Lucas Alves de Souza**

* GitHub: [luscalves](https://github.com/luscalves)
* *Estudante de Engenharia de Computação focado em arquitetura de software e no ecossistema .NET.*
