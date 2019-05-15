create table Mercado
(
id int primary key, 
tipoProduto varchar (30),
descricao ntext,
preco money,
produto varchar(100)
)

drop table Mercado
select * from Mercado
alter table Mercado alter column descricao ntext
alter table Mercado add produto varchar(100) 
alter table Mercado alter column preco money
alter table Mercado alter column tipoProduto varchar(30)

insert into Mercado values (1, 'Moradia', 'Casa pequena, 1 banheiro, 1 quarto, 1 sala, 1 cozinha, 1 Lavanderia', 50000,'Casa')
insert into Mercado values (2, 'Automovel', 'Carro para 4 pessoas, popular', 46690,'Chelovret Jonix')
insert into Mercado values (3, 'Moradia', 'Apartamento médio, 2 quartos, 2 banheiros, 1 Cozinha, 1 Lavanderia,1 sala', 100000,'Apartamento')
insert into Mercado values (4, 'Automovel', 'Carro para 4 pessoas, popular', 54450,'Zolksvagem Golo ')
insert into Mercado values (5, 'Moradia', 'Casa grande, 4 banheiros, 3 quartos, 1 sala, 1 escritório, 1 cozinha, 1 Lavanderia, Quintal com jardim, estacionamento para 2 carros', 1100000,'Casa')
insert into Mercado values (6, 'Automovel', 'Carro para 4 pessoas, esportivo', 84490,'Revault Sombrero ')

select * from Mercado