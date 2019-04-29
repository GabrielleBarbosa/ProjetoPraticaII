create table Jogador
(
 nickName varchar(25) primary key,
 idade int not null,
 sexo char not null,
 pontosSaude int not null,
 pontosInteligencia int not null,
 pontosRelacionamento int not null,
 pontosFelicidade int not null, 
 dinheiro money,
 parceiro char not null,
 codEmprego int,
 constraint fkEmprego foreign key(codEmprego) references Emprego(codEmprego)
)
alter table Jogador alter column nickName varchar(25)
drop table Jogador



insert into Jogador values('Vinschers',0,'M',0,0,0,0,0,'S',1)
insert into Jogador values('Gabs123',0,'F',0,0,0,0,0,'S',1)
insert into Jogador values('Janies',0,'F',0,0,0,0,0,'S',1)

------------------------------------------------------------------------------------------------------------------------


create table Ranking
(
nickName varchar(25),
constraint fkJogador foreign key(nickName) references Jogador(nickName),
pontos int
)


alter table Ranking alter column nickName no check constraint


insert into Ranking values('Vinschers',120111)
insert into Ranking values('Gabs123', 9929)
insert into Ranking values('Janies', 543322)

alter table Ranking add id int identity(1,1) primary key 

drop table Ranking
------------------------------------------------------------------------------------------------------------------------

create table Escolha
(
codEscolha int primary key,
opcao1 varchar(50),
opcao2 varchar(50),
consequencia1 int,
constraint fkConsequencia1 foreign key(consequencia1) references Consequencia(codConsequencia),
consequencia2 int,
constraint fkConsequencia2 foreign key(consequencia2) references Consequencia(codConsequencia)

)
drop table Escolha
------------------------------------------------------------------------------------------------------------------------
create table Consequencia
(
codConsequencia int primary key,
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
codEmprego int primary key,
pontosNecessarios int,
trabalho varchar(30),
salario money
)
drop table Emprego
alter table Emprego alter column trabalho varchar(100)
select * from Emprego

insert into Emprego values (1, 60,'Atendente de Mercado',1143.50)
insert into Emprego values (2, 200,'Vendedor de Loja',1870.89 )
insert into Emprego values (3, 30,'Lixeiro',998.50)
insert into Emprego values (4, 200,'Pedreiro',1000)
insert into Emprego values (5, 400,'Policial',4500.47)
insert into Emprego values (6, 750,'Programador Iniciante',3345.43)
insert into Emprego values (7, 250,'Garçom',2200.56)
insert into Emprego values (8, 600,'Engenheiro',5000)
insert into Emprego values (9, 500,'Professor',3896.78)
insert into Emprego values (10, 900,'Piloto',8235.90)
insert into Emprego values (11, 860,'Gestor de Qualidade',11235.90)



------------------------------------------------------------------------------------------------------------------------

create table AcontecimentoFixo
(
codAcontecimentoFixo int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha foreign key(codEscolha) references Escolha(codEscolha)

)
drop table AcontecimentoFixo
------------------------------------------------------------------------------------------------------------------------

create table AcontecimentoAleatorio
(
codAcontecimentoAleatorio int primary key, 
acontecimento ntext,
codEscolha int,
constraint fkEscolha2 foreign key(codEscolha) references Escolha(codEscolha)
)
drop table AcontecimentoAleatorio
------------------------------------------------------------------------------------------------------------------------

create table Mercado
(
id int primary key, 
tipoProduto ntext,
descricao varchar(200),
preco float
)

drop table Mercado
select * from Mercado
alter table Mercado alter column descricao ntext
alter table Mercado add produto varchar(100) 


insert into Mercado values (1, 'Moradia', 'Casa','', 50000)
insert into Mercado values (2, 'Automovel', 'apzao','', 120000)
insert into Mercado values (3, 'Cachiorroi', 'dog','', 12)
------------------------------------------------------------------------------------------------------------------------


create table MercadoJogador
(
codJogador varchar(25),
constraint fkJogador2 foreign key(codJogador) references Jogador(id)
)
drop table MercadoJogador

select * from MercadoJogador
------------------------------------------------------------------------------------------------------------------------





