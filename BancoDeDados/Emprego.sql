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

insert into emprego values (0, 'Sem Emprego', 0, 0)
insert into Emprego values (1,'Atendente de Mercado',10143.50,0)
insert into Emprego values (2,'Vendedor de Loja',10870.89,0)
insert into Emprego values (3,'Lixeiro',9098.50,0)
insert into Emprego values (4,'Pedreiro',10000,0)
insert into Emprego values (5,'Garçom',20200.56,0)
insert into Emprego values (6,'Programador junior',30345.43,1)

--os de cima já existem, os abaixo não existem ainda

insert into Emprego values (7,'Policial',40500.47,444)/**/
insert into Emprego values (8,'Engenheiro',50000,555)/**/
insert into Emprego values (9,'Professor',30896.78,19)
insert into Emprego values (10,'Piloto',80235.90,999)/**/
insert into Emprego values (11,'Gestor de Qualidade',110235.90,22)
insert into Emprego values (12,'Advogado',100000.67,12)
insert into Emprego values (13,'Juiz', 300000,12)/**/
insert into Emprego values (14,'Médico',900908.50,6)
insert into Emprego values (15,'Programador sênior',100000.50,11)
insert into Emprego values (16,'Biólogo',70000.50,8)
insert into Emprego values (17,'Professor',50000.50,0)/**/
insert into Emprego values (18,'Artista',40000.50,23)
insert into Emprego values (19,'Ator de cinema',30000.50,14)
insert into Emprego values (20,'Gerente',110000.50,16)/**/
insert into Emprego values (21,'Enfermeiro',35000.50,7)
insert into Emprego values (22,'Mecânico',30000.50,4)
insert into Emprego values (23,'Fotógrafo',22980.50,13)
insert into Emprego values (24,'Chefe de culinária',30000.50,18)
insert into Emprego values (25,'Cozinheiro',9980.50,17)
insert into Emprego values (26,'Matemático',9980.50,21)
insert into Emprego values (27,'Editor',23098.50,20)
insert into Emprego values (28,'Eletricista',9980.50,2)
insert into Emprego values (29,'Engenheiro de Alimentos',32000.50,24)


select * from Emprego