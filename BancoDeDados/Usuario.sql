create table Usuario
(
	id int identity primary key,
	nickname varchar(15) not null,
	senha varchar(15) not null
)

select * from Usuario
delete from Personagem
delete from Usuario
delete from CursoJogador
delete from MercadoJogador
