create table Emprego
(
id int primary key,
trabalho varchar(30),
salario money,
cursoNecessario int,
constraint fkCurso2 foreign key (cursoNecessario) references Curso(id)
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