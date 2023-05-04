--Armando Criando a Prodedures
/*
---Armando: Scrip para criação da PROCEDURE CLIENTE_OBTER_POR_ID da loja DigiShop
create procedure CLIENTE_OBTER_POR_ID

@Id varchar(50)
as

select Id, Nome, Email, Telefone
from CLIENTE
where Id = @Id

GO
*/

/*
---Armando: Scrip para criação da PROCEDURE CLIENTE_ALTERAR da loja DigiShop
create procedure CLIENTE_ALTERAR

@Id varchar (50),
@Nome varchar(100),
@Email varchar(100),
@Telefone varchar(100)

as
update CLIENTE
set Nome=@Nome, Email=@Email, Telefone=@Telefone
where Id=@Id
*/

/*
---Armando: Scrip para criação da PROCEDURE CLIENTE_INCLUIR da loja DigiShop

		create procedure CLIENTE_INCLUIR(
			@Id varchar(50),
			@Nome varchar(100),
			@Email varchar(100),
			@Telefone varchar(100)
		)
			as 
			insert into CLIENTE(Id, Nome, Email, Telefone)
				values(@Id, @Nome, @Email, @Telefone)

		GO
*/
---Armando: Scrip para criação da PROCEDURE CLIENTE_EXCLUIR da loja DigiShop
/*
		create procedure CLIENTE_EXCLUIR 
		@Id varchar (50)
		as
		delete from CLIENTE where Id=@Id

		GO
*/

/*
---Armando: Script para Criação da PROCEDURE CLIENTE_LISTAR da Loja DigiShop

		create procedure CLIENTE_LSITAR 
		as
		select Id, Nome, Email, Telefone
		from CLIENTE

		GO

---Armando: Scrip para criação da PROCEDURE PRODUTO_EXCLUIR da loja DigiShop (03-05-2023)		
create procedure PRODUTO_EXCLUIR 
		@Id varchar (50)
		as
		delete from CLIENTE where Id=@Id

GO


---Armando: Scrip para criação da PROCEDURE PRODUTO_INCLUIR da loja DigiShop (03-05-2023)
create procedure [dbo].[PRODUTO_INCLUIR](
	@Id varchar(50),
	@Nome varchar(100),
	@Preco decimal(38),
	@Estoque int
)
	as 

	insert into PRODUTO(Id, Nome, Preco, Estoque)
		values(@Id, @Nome, @Preco, @Estoque)
GO
	
		

--Armando: Script para Criação da PROCEDURE PRODUTO_ALTERAR da Loja DigiShop (03-05-2023)
create procedure PRODUTO_ALTERAR

@Id varchar (50),
@Nome varchar(100),
@Preco decimal(38),
@Estoque int

as

update PRODUTO
set Nome=@Nome, Preco=@Preco, Estoque=@Estoque
where Id=@Id

GO
*/



--Armando: Script para Criação da PROCEDURE PRODUTO_OBTER_POR_ID da Loja DigiShop (03-05-2023)

create procedure [dbo].[PRODUTO_OBTER_POR_ID]

@Id varchar(50)
as

select Id, Nome, Preco, Estoque
from PRODUTO
where Id = @Id
GO


