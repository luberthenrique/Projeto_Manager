# Avaliação Manager
A API desenvolvida para avaliação da empresa Manager tem o intuito de comparar dois valores (left e right) e retornar possíveis diferenças de tamanhos ou caracteres identificadas. O sistema possui um banco de dados local SQLite, que possibilita a gravação dos dados sem que seja preciso criar e configurar uma nova instancia do banco de dados.
Autor: Lubert Henrique
Data: 26/06/2020

### Endpoints:

	1- https://localhost:44310/v1/diff/left : utilizado para gravar o parâmetro left para sua posterior comparação, passando como parâmetro um objeto json que contém o parâmetro "left". Ex:
		{
			"left": "Teste"
		}

	2- https://localhost:44310/v1/diff/right : utilizado para gravar o parâmetro right para sua posterior comparação, passando como parâmetro um objeto json que contém o parâmetro "right". Ex:
		{
			"right": "Teste"
		}

	3- https://localhost:44310/v1/diff : utilizado para identificar diferenças ou não dos parâmetros left e rigth binários previamente cadastrados no sistema

	4- https://localhost:44310/v1/diff/comparacoes : utilizado para consultar todas os resultados de alterações já realizadas

### Execução do projeto

	1- Para visual studio:
		a. definir o projeto "Projeto_Manager.api" como projeto de inicialização, caso o mesmo ainda não estaja definido.
		b. executar o projeto com a tecla f5

	2- Para visual studio code:
		a. abrir o projeto em respectiva pasta.
		b. abrir o caminho da projeto "Projeto_Manager.api" através do console.
		c. executar o comando dotnet restore.
		d. executar o comando dotnet run.

### Execução dos testes

	1- Testes unitários : para execução dos testes, abrir o gerenciador de soluções, clicar com o botão direito do mouse no projeto em "Projeto_Manager.test" e clicar em executar testes, ou executar o mesmo através do gerenciador de testes.

	2- Testes de integração : 
		a. executar o projeto de acordo com o item "Execução do projeto"
		b. na pasta raiz do projeto contém o arquivo "Manager.postman_collection" exportado do aplicativo postman. Para execução dos testes, pode se utilizar o mesmo para importações dos testes no aplicativo postman ou criar novos testes utilizando os endpoints e atributos descritos no item "Endpoints" 

### Arquiteruta

	Para o projeto atual, foi definido a criação da api em asp.net core 2.1 devido a ser uma versão não obsoleta em relação a versão 2.2 e ao maior entendimento da mesma, já que tenho o costume de utilização da mesma. 
	Em conjunto ao asp.net, foi utilizado um banco de dados local SQLite devido a interesse pessoal em armazenamento e consultas posteriores de comparações efetuadas, junto com os parâmetros enviados e a data da consulta. Esse banco de dados foi escolhido devido o mesmo já estar integrado no sistema e não ter a necessidade de criação ou configuração de um banco de dados, bastando que se execute o projeto para que se tenha acesso as informações. Para a pesistência de dados, foi utilizado o "Entity Framework" devido a facilidade de execução e criação do banco de dados com o mesmo a a esse framework atender as demandas para o projeto atual.

	Para o código, foram criadas duas classes: a de nome "Retorno" que será utilizada para retornar informações de sucesso ou erro ao tentar gravar um parâmetro, e a classe "Dado", que será utilizada para entrada dos dados serializados em json, saida dos dados consutados e armazenamento das informações no banco de dados.

	Em relação aos testes, foi adotada a execução com a estrutura xUnit, devido a maior conhecimento pessoal sobra a mesma.
