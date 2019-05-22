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
insert into Emprego values (1,'Atendente de Mercado',1143.50,0)
insert into Emprego values (2,'Vendedor de Loja',1870.89,0)
insert into Emprego values (3,'Lixeiro',998.50,0)
insert into Emprego values (4,'Pedreiro',1000,0)
insert into Emprego values (5,'Garçom',2200.56,0)

insert into Emprego values (6,'Programador junior',3345.43,1)
insert into Emprego values (7,'Policial',4500.47,444)/**/
insert into Emprego values (8,'Engenheiro',5000,555)/**/
insert into Emprego values (9,'Professor',3896.78,19)
insert into Emprego values (10,'Piloto',8235.90,999)/**/
insert into Emprego values (11,'Gestor de Qualidade',11235.90,22)
insert into Emprego values (12,'Advogado',10000.67,12)
insert into Emprego values (13,'Juiz', 30.000,12)/**/
insert into Emprego values (14,'Médico',998.50,6)
insert into Emprego values (15,'Programador sênior',998.50,11)
insert into Emprego values (16,'Biólogo',998.50,8)
insert into Emprego values (17,'Professor',998.50,0)/**/
insert into Emprego values (18,'Artista',998.50,23)
insert into Emprego values (19,'Ator de cinema',998.50,14)
insert into Emprego values (20,'Gerente',998.50,16)/**/
insert into Emprego values (21,'Enfermeiro',998.50,7)
insert into Emprego values (22,'Mecânico',998.50,4)
insert into Emprego values (23,'Fotógrafo',998.50,13)
insert into Emprego values (24,'Chefe de culinária',998.50,18)
insert into Emprego values (25,'Cozinheiro',998.50,17)
insert into Emprego values (26,'Matemático',998.50,21)
insert into Emprego values (27,'Editor',998.50,20)
insert into Emprego values (28,'Eletricista',998.50,2)
insert into Emprego values (29,'Engenheiro de Alimentos',998.50,24)
