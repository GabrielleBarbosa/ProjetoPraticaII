--tabela qque mostar o parceiro do jogador/relacinamento amoroso

create table Parceiro(

id int IDENTITY(1,1) primary key,

nome ntext,
idade int,
sexo char(1)

-- 'H' pra hetero, 'G' pra homossexual e 'B' pra bissexual 
)

drop table Parceiro
select * from Parceiro
drop table Parceiro

--femininos
insert into Parceiro values('Sophia Leans',0,'F')
insert into Parceiro values('Rebeca Turner',0,'F')
insert into Parceiro values('Juliana Barbosa',0,'F')
insert into Parceiro values('Fernanda Tully',0,'F')
insert into Parceiro values('Isabela Sousa',0,'F')
insert into Parceiro values('Cecília da Silva',0,'F')
insert into Parceiro values('Gabriela Dias',0,'F')
insert into Parceiro values('Helena Machado',0,'F')
insert into Parceiro values('Lara Melchior',0,'F')
insert into Parceiro values('Ana Pires',0,'F')
insert into Parceiro values('Sura Stark',0,'F')
insert into Parceiro values('Camila Barbosa',0,'F')
insert into Parceiro values ('Daenerys Targaryen',0,'F')
insert into Parceiro values('Margaery Tyrell',0,'F')





--masculinos
insert into Parceiro values('Pedro Renó',0,'M')
insert into Parceiro values('Carlos de Andrade',0,'M')
insert into Parceiro values('Hércules Da Silva',0,'M')
insert into Parceiro values('Jamie Lannister',0,'M')
insert into Parceiro values('Leon Kennedy',0,'M')
insert into Parceiro values('Andersson Chucrutes',0,'M')
insert into Parceiro values('Whindersson de Azevedo',0,'M')
insert into Parceiro values('Robert Baratheon',0,'M')
insert into Parceiro values('Eduardo Bolsonaro',0,'M')
insert into Parceiro values('Jon Snow',0,'M')
insert into Parceiro values('Renly Baratheon',0,'M')

select * from Parceiro