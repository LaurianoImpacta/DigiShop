/*
---Armando: Cria��o do Banco de Dados da Loja DigiShop

		create database DIGISHOP

		GO

*/

---Armando: Conex�o ao banco da loja DigiShop
/*
	USE DIGISHOP

	GO
*/
/*
---Armando: Scrip para cria��o da TABELA CLIENTE da loja DigiShop

		create table CLIENTE(
			Id varchar(50) primary key,
			Nome varchar(100),
			Email varchar(100),
			Telefone varchar(100)
		)
		
		GO

*/

---Armando: Scrip para cria��o da TABELA PRODUTO da loja DigiShop (03/05/2023)
/*
create table PRODUTO (
			Id varchar(50) primary key,
			Nome varchar(100),
			Preco decimal (38),
			Estoque int,
		)
		
GO
*/
