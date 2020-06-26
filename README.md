# Avalia��o Manager
A API desenvolvida para avalia��o da empresa Manager tem o intuito de comparar dois valores (left e right) e retornar poss�veis diferen�as de tamanhos ou caracteres identificadas. O sistema possui um banco de dados local SQLite, que possibilita a grava��o dos dados sem que seja preciso criar e configurar uma nova instancia do banco de dados.
Autor: Lubert Henrique
Data: 26/06/2020

### Endpoints:

	1- https://localhost:44310/v1/diff/left : utilizado para gravar o par�metro left para sua posterior compara��o, passando como par�metro um objeto json que cont�m o par�metro "left". Ex:
		{
			"left": "Teste"
		}

	2- https://localhost:44310/v1/diff/right : utilizado para gravar o par�metro right para sua posterior compara��o, passando como par�metro um objeto json que cont�m o par�metro "right". Ex:
		{
			"right": "Teste"
		}

	3- https://localhost:44310/v1/diff : utilizado para identificar diferen�as ou n�o dos par�metros left e rigth bin�rios previamente cadastrados no sistema

	4- https://localhost:44310/v1/diff/comparacoes : utilizado para consultar todas os resultados de altera��es j� realizadas

### Execu��o do projeto

	1- Para visual studio:
		a. definir o projeto "Projeto_Manager.api" como projeto de inicializa��o, caso o mesmo ainda n�o estaja definido.
		b. executar o projeto com a tecla f5

	2- Para visual studio code:
		a. abrir o projeto em respectiva pasta.
		b. abrir o caminho da projeto "Projeto_Manager.api" atrav�s do console.
		c. executar o comando dotnet restore.
		d. executar o comando dotnet run.

### Execu��o dos testes

	1- Testes unit�rios : para execu��o dos testes, abrir o gerenciador de solu��es, clicar com o bot�o direito do mouse no projeto em "Projeto_Manager.test" e clicar em executar testes, ou executar o mesmo atrav�s do gerenciador de testes.

	2- Testes de integra��o : 
		a. executar o projeto de acordo com o item "Execu��o do projeto"
		b. na pasta raiz do projeto cont�m o arquivo "Manager.postman_collection" exportado do aplicativo postman. Para execu��o dos testes, pode se utilizar o mesmo para importa��es dos testes no aplicativo postman ou criar novos testes utilizando os endpoints e atributos descritos no item "Endpoints" 

### Arquiteruta

	Para o projeto atual, foi definido a cria��o da api em asp.net core 2.1 devido a ser uma vers�o n�o obsoleta em rela��o a vers�o 2.2 e ao maior entendimento da mesma, j� que tenho o costume de utiliza��o da mesma. 
	Em conjunto ao asp.net, foi utilizado um banco de dados local SQLite devido a interesse pessoal em armazenamento e consultas posteriores de compara��es efetuadas, junto com os par�metros enviados e a data da consulta. Esse banco de dados foi escolhido devido o mesmo j� estar integrado no sistema e n�o ter a necessidade de cria��o ou configura��o de um banco de dados, bastando que se execute o projeto para que se tenha acesso as informa��es. Para a pesist�ncia de dados, foi utilizado o "Entity Framework" devido a facilidade de execu��o e cria��o do banco de dados com o mesmo a a esse framework atender as demandas para o projeto atual.

	Para o c�digo, foram criadas duas classes: a de nome "Retorno" que ser� utilizada para retornar informa��es de sucesso ou erro ao tentar gravar um par�metro, e a classe "Dado", que ser� utilizada para entrada dos dados serializados em json, saida dos dados consutados e armazenamento das informa��es no banco de dados.

	Em rela��o aos testes, foi adotada a execu��o com a estrutura xUnit, devido a maior conhecimento pessoal sobra a mesma.
