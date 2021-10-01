# API com AspNet Core - Curso básico 

Desenvolvimento de uma Web API utilizando VSCode, abordando os conceitos básicos para se criar uma API.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 5
- Entity Framework Core
- C#
- MySQL
## Conceitos abordados no curso
- Model => Responsável pela criação da tabela no banco de dados e características no JSON.

- DataContext =>  Responsável pelas ações de banco de dados como: seleção, alteração, cadastramento e exclusão.

- Conexão c/ MySQL =>  Como fazer a conexão entre aplicação e o banco MySQL.

- Migrations => Criando tabelas através da model.

- Controllers => Criando as rotas da aplicação.

- ControllerBase =>  Responsável por diversas funcionalidades de uma API como por exemplo:
 * Especificar o status de uma requisição (200 Ok, 201 Criado, 404 Não encontrado)
 * Obter dados do front-end utilizando o FromBody (Necessário para cadastrar e alterar).

- Programação assincrona (async/await) => Quando há a necessidade de esperarmos determinadas partes do código executarem uma função especifica e que podem depender de um tempo maior de espera que o normal como por exemplo uma lista com milhões de registros, neste caso precisamos esperar ter a lista totalmente carregada para depois exibir no navegador.

- Método Find() => Responsável por retornar um objeto do banco de dados através de um identificador.

- Requisições HttpPost, HttpGet, HttpPut, HttpDelete

## Funcionalidades
- Cadastro, Listagem, Detalhes, Atualização e Remoção.

