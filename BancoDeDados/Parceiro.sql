--tabela qque mostar o parceiro do jogador/relacinamento amoroso

create table Parceiro(

id int primary key,
nome ntext,
idade int,
sexo char(1)
)
-- 'H' pra hetero, 'G' pra homossexual e 'B' pra bissexual 
drop table Personagem
drop table Parceiro
select * from Parceiro



--femininos
insert into Parceiro values(1,'Sophia Leans',0,'F')
insert into Parceiro values(2,'Rebeca Turner',0,'F')
insert into Parceiro values(3,'Juliana Barbosa',0,'F')
insert into Parceiro values(4,'Fernanda Tully',0,'F')
insert into Parceiro values(5,'Isabela Sousa',0,'F')
insert into Parceiro values(6,'Cecília da Silva',0,'F')
insert into Parceiro values(7,'Gabriela Dias',0,'F')
insert into Parceiro values(8,'Helena Machado',0,'F')
insert into Parceiro values(9,'Lara Melchior',0,'F')
insert into Parceiro values(10,'Ana Pires',0,'F')
insert into Parceiro values(11,'Sura Stark',0,'F')
insert into Parceiro values(12,'Camila Barbosa',0,'F')
insert into Parceiro values (13,'Daenerys Targaryen',0,'F')
insert into Parceiro values(14,'Margaery Tyrell',0,'F')





--masculinos
insert into Parceiro values(31,'Pedro Renó',0,'M')
insert into Parceiro values(32,'Carlos de Andrade',0,'M')
insert into Parceiro values(33,'Hércules Magaldi',0,'M')
insert into Parceiro values(34,'Jamie Lannister',0,'M')
insert into Parceiro values(35,'Leon Kennedy',0,'M')
insert into Parceiro values(36,'Andersson Chucrutes',0,'M')
insert into Parceiro values(37,'Whindersson de Azevedo',0,'M')
insert into Parceiro values(38,'Robert Baratheon',0,'M')
insert into Parceiro values(39,'Eduardo Bolsonaro',0,'M')
insert into Parceiro values(40,'Jon Snow',0,'M')
insert into Parceiro values(41,'Renly Baratheon',0,'M')

insert into parceiro values (0, 'Nenhum', 0, 'I')
select * from Parceiro