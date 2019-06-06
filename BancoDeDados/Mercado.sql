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

insert into Mercado values (1, 'Moradia', 'Casa pequena, 1 banheiro, 1 quarto, 1 sala, 1 cozinha, 1 Lavanderia', 1500000,'Casa')

insert into Mercado values (2, 'Automovel', 'Carro para 4 pessoas, popular', 40690,'Chelovret Jonix')

insert into Mercado values (3, 'Moradia', 'Apartamento médio, 2 quartos, 2 banheiros, 1 Cozinha, 1 Lavanderia,1 sala', 100000,'Apartamento')

insert into Mercado values (4, 'Automovel', 'Carro para 4 pessoas, popular', 54450,'Zolksvagem Golo ')

insert into Mercado values (5, 'Moradia', 'Casa grande, 4 banheiros, 3 quartos, 1 sala, 1 escritório, 1 cozinha, 1 Lavanderia, Quintal com jardim, estacionamento para 2 carros', 1100000,'Casa')

insert into Mercado values (6, 'Automovel', 'Carro para 4 pessoas, esportivo', 84490,'Revault Sombrero ')

insert into Mercado values (7,'Moradia', 'Apartamento pequeno, 1 cozinha, 1 um quarto, 1 banheiro',50000,'Apartamento')

insert into Mercado values (8,'Automovel', 'Carro esportivo, 4 pessoas',127900,'BWM 320I')

insert into Mercado values (9,'Moradia', 'Apartamento grande, 2 suítes, lavabo, 1 cozinha, 1 sala com sacada, um escritório',350000,'Apartamento')

insert into Mercado values (10,'Automovel', '4x4 para 2 pessoas, automático',54900,'Subitsumishi Parrero')

insert into Mercado values (11,'Moradia', 'Casa pequena , 1 banheiro, 1 quarto, 1 sala, 1 cozinha, ',90000,'Casa')

insert into Mercado values (12,'Automovel', 'Carro esportivo, 4 pessoas',238990,'Maguar F-Paze ')

insert into Mercado values (13,'Moradia', '5 suítes, 8 banheiros, 6 vagas, cozinha, 3 salas, quintal com piscina',1900000,'Casa')

insert into Mercado values (14,'Automovel', '4x4 para 4 pessoas, automático',92890,'Tayoto RAV4')

insert into Mercado values (15,'Moradia', 'Apartamento grande, 3 suítes, 1 banheiros, 2 vagas pra carro, cozinha e lavabo',820000,'Apartamento')

insert into Mercado values (16,'Automovel', 'Carro para 4 pessoas, automático, popular',60000,'Kord Fusion')

insert into Mercado values (17,'Moradia', 'Casa média, 2 suítes, 2 banheiros, 2 vagas pra carro, cozinha e lavabo',850000,'Casa')

insert into Mercado values (18,'Automovel', 'Carro para 4 pessoas, automático,16V popular',25000,'Zonda Acordd')

insert into Mercado values (19,'Moradia', 'Casa grande, 3 suítes, 2 banheiros, 2 vagas, cozinha, 2 salas',999000,'Casa')

insert into Mercado values (20,'Automovel', 'Carro para 4 pessoas, automático,24V 4x4, popular,',130980,'Subitsumishi Outlander')

insert into Mercado values (21,'Moradia', 'Casa média, 3 suítes, 2 banheiros, 2 vagas, cozinha, 1 sala',500000,'Casa')



select * from Mercado
delete from Mercado 