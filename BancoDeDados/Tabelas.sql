create table Jogador
(
 id int identity(1,1) primary key,
 senha varchar(20), 
 nickname varchar(25),
 idade int not null,
 sexo char not null,
 pontosSaude int not null,
 pontosInteligencia int not null,
 pontosRelacionamento int not null,
 pontosFelicidade int not null, 
 dinheiro money,
 parceiro char not null,
 codEmprego int,
 constraint fkEmprego foreign key(codEmprego) references Emprego(id)
)
select * from Jogador
alter table Jogador alter column codEmprego int null
drop table Jogador

insert into Jogador values('123','Vinchers',0,'M',0,0,0,0,0,'S',0)
insert into Jogador values('Gabs123',0,'F',0,0,0,0,0,'S',1)
insert into Jogador values('Janies',0,'F',0,0,0,0,0,'S',1)

------------------------------------------------------------------------------------------------------------------------


create table Ranking
(
id int identity(1,1) primary key,
nickName varchar(25),
pontos int
)

select * from Ranking
insert into Ranking values('Vinschers',120111)
insert into Ranking values('Gabs123', 9929)
insert into Ranking values('Janies', 543322)

alter table Ranking add id int identity(1,1) primary key 

drop table Ranking
------------------------------------------------------------------------------------------------------------------------

create table Escolha
(
id int primary key,
opcao1 varchar(50),
opcao2 varchar(50),
consequencia1 int,
constraint fkConsequencia1 foreign key(consequencia1) references Consequencia(id),
consequencia2 int,
constraint fkConsequencia2 foreign key(consequencia2) references Consequencia(id)
)
drop table Escolha
------------------------------------------------------------------------------------------------------------------------
create table Consequencia
(
id int primary key,
cenario varchar(20),
pontosGanhos int,
tipoDoPontoGanho varchar(20),
tipoDoPontoPerdido varchar(20),
pontosPerdidos int
)
drop table Consequencia
------------------------------------------------------------------------------------------------------------------------
create table Emprego
(
id int primary key,
pontosNecessarios int,
trabalho varchar(30),
salario money,
restricao int, 
anosExperiencia int
)
drop table Emprego
alter table Emprego alter column trabalho varchar(100)
select * from Emprego

--essa coluna restrição é pra definir o que a pessoa precisa ter de formação acadêmica para ter acesso a esse emprego. Exemplo:
-- Se a pessoa for formada como um professor, ela vai possuir acesso a todos os empregos relacionados a essa área, no caso '111', o código do emprego
--quantos anos trabalhando que o jogador precisa ter pra ter acesso a esse emprego?

insert into emprego values (0, 0, 'Sem Emprego', 0, 0, 0)
insert into Emprego values (1, 60,'Atendente de Mercado',1143.50,888,0)
insert into Emprego values (2, 200,'Vendedor de Loja',1870.89,888,0 )
insert into Emprego values (3, 30,'Lixeiro',998.50,888,0)
insert into Emprego values (4, 200,'Pedreiro',1000,888,0)
insert into Emprego values (5, 400,'Policial',4500.47,444,0)
insert into Emprego values (6, 750,'Programador Iniciante',3345.43,222,0)
insert into Emprego values (7, 250,'Garçom',2200.56,888,0)
insert into Emprego values (8, 600,'Engenheiro',5000,555,0)
insert into Emprego values (9, 500,'Professor',3896.78,111,0)
insert into Emprego values (10, 900,'Piloto',8235.90,999,0)
insert into Emprego values (11, 860,'Gestor de Qualidade',11235.90,222,20)
insert into Emprego values (12, 700,'Advogado',10000.67,666,0)
insert into Emprego values (13, 750,'Juiz', 30.000,666,30)

------------------------------------------------------------------------------------------------------------------------
create table Curso(
id int primary key,
nome varchar(20),
descricao ntext
)
------------------------------------------------------------------------------------------------------------------------
create table CursoJogador(
id int identity(1,1) primary key,
codCurso int, 
constraint fkCurso foreign key(codCurso) references Curso(id),
codJogador int
constraint fkJogador1 foreign key(codJogador) references Jogador(id)
)
------------------------------------------------------------------------------------------------------------------------
create table AcontecimentoFixo
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoFixo
drop table AcontecimentoFixo


-- 1 a 15

insert into AcontecimentoFixo values ()
------------------------------------------------------------------------------------------------------------------------

create table AcontecimentoAleatorio
(
id int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha2 foreign key(codEscolha) references Escolha(id)
)
select * from AcontecimentoAleatorio
drop table AcontecimentoAleatorio
------------------------------------------------------------------------------------------------------------------------

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
------------------------------------------------------------------------------------------------------------------------


create table MercadoJogador
(
codJogador int,
constraint fkJogador foreign key(codJogador) references Jogador(id),
codMercado int,
constraint fkMercado foreign key (codMercado) references Mercado(id)
)
drop table MercadoJogador

select * from MercadoJogador
------------------------------------------------------------------------------------------------------------------------





