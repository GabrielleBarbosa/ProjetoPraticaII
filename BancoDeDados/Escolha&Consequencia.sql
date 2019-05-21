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

insert into Escolha values(1, 'Ir à festa', 'Estudar', 1, 2)
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

insert into Consequencia values(1, 'festa', 50, 'Felicidade', 50, 'Inteligencia')
insert into Consequencia values(1, 'escola', 50, 'Inteligencia', 50, 'Felicidade')

