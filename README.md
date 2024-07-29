
<h1 id="bem-ao-sistema-de-gerenciamento-tarefas">Bem ao Sistema de Gerenciamento de Tarefas!</h1>
<p>Você foi contratado para desenvolver um sistema de gerenciamento de tarefas para uma pequena empresa. A empresa precisa de um sistema onde os funcionários possam criar, 
editar, deletar e visualizar tarefas. As tarefas devem ser atribuídas a usuários específicos 
e ter um status (Pendente, Em Progresso, Concluído).</p>
<h1 id="requisitos-para-execução-do-projeto">Requisitos para execução do projeto</h1>
<p>Link para o visual studio: https://visualstudio.microsoft.com/pt-br/<br>
1-Instalar .Net FrameWork Core disponivel em <a href="https://dotnet.microsoft.com/download">https://dotnet.microsoft.com/download</a></p>
<h2 id="etapas-para-execução-do-projeto">Etapas para execução do projeto</h2>
<p>1- Abra seu visual studio<br>
2- Sete seu projeto <strong>GerenciadorTarefas.WebAPI.</strong>
![Captura de tela 2024-07-29 185421](https://github.com/user-attachments/assets/cf34f93a-6819-4400-8c2e-0067487089c6)
<br>
3- Start seu projeto, setando o seguinte projeto<strong> GerenciadorTarefas.WebAPI</strong> 
![Captura de tela 2024-07-29 190048](https://github.com/user-attachments/assets/7d6ffffd-86e5-4413-8302-98b2680d5c8e) 
<h2 id="etapas-para-execucao-projeto-docker">Etapas para execução do projeto no Docker</h2>
<strong>Orquestração com Docker</strong>
Este projeto utiliza Docker para orquestrar os containers da aplicação .NET Core Web API e do banco de dados SQL Server. 
<strong>Estrutura dos Containers</strong>
Aplicação .NET Core Web API: Este container executa a API desenvolvida em .NET Core. Ele é configurado para se comunicar com o banco de dados SQL Server.
SQL Server: Este container fornece o banco de dados SQL Server para armazenar os dados da aplicação.
Como Rodar
Certifique-se de ter o Docker instalado em sua máquina.
Construa e inicie os containers executando o comando: 
docker-compose up --build
Acesse a API em http://localhost:5010/swagger 
e o banco de dados SQL Server estará disponível para conexão no endereço localhost,5433
<h1 id="framework-e-banco-de-dados">Framework</h1>
EntityFrameworkCore ^8<br>
AutoMapper ^12<br>
Swashbuckle.AspNetCore ^6<br>
Microsoft.AspNetCore.Identity ^8<br>
EntityFramework Core ^8<br>
AutoMapper ^12<br>
JWT ^8<br>
Swagger<br>
X-UNIT<br>
Docker<br>
<h1 id="banco-de-dados">Banco de dados</h1>
<p>SQL SERVER</p>
<h1 id="linguagem">Linguagem</h1>
<p>C#</p>
<h1 id="rquitetura">Arquitetura</h1>
<p>DDD</p>
<h1 id="padrao">Padrão</h1>
<p>Repository</p>

